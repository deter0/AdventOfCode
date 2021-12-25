package main

import (
	"fmt"
	"io/ioutil"
	"log"
	"strconv"
	"strings"
)

func getFish() []int8 {
	contentBytes, err := ioutil.ReadFile("./input.txt");
	if (err != nil) {
		log.Fatal(err);
	}
	var content string = string(contentBytes);
	fishStr := strings.Split(content, ",");
	var fish[]int8;
	for _, v := range fishStr {
		num, err := strconv.Atoi(v);
		if (err != nil) {
			log.Fatal(err);
		}
		fish = append(fish, int8(num));
	}
	return fish;
}

func main() {
	fish := getFish();
	var fishTracker [8]int;
	for _, v := range fish {
		fishTracker[v]++;
	}
	
	fmt.Println("Initial state: ", fishTracker);
	
	DAYS := int16(19);
	for i := int16(0); i < DAYS; i++ {
		var atZero int = int(fishTracker[0]);
		// Shift everything to the left
		for j := int16(0); j < 7; j++ {
			fishTracker[j] = fishTracker[j+1];
		}
		fishTracker[7] = atZero;
		fishTracker[5] += atZero;

		// Print
		fmt.Printf("Day %d: ", i + 1);
		for j := int16(0); j < 8; j++ {
			fmt.Printf("%d ", fishTracker[j]);
		}
		fmt.Printf("\n");
	}
	
	var total int = 0;
	for _, v := range fishTracker {
		total += v;
	}
	log.Printf("Total fish: %d", total);
}