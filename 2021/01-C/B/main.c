#include <stdlib.h>
#include <stdio.h>
#include <stdbool.h>
#include <math.h>

#include "../../C-Helpers/ReadFile.c"

int getSize(File_ *file) {
	int size = 0;
	for (int i = 0; i < file->size; i++) {
		if (file->content[i] == '\n') {
			size++;
		}
	}
	return size;
}

int main() {
#if 0
	char *pointerChar = (char*) malloc(12*sizeof(char));
	pointerChar = "testingonly";
	printf("%s\n", pointerChar);
#else
	int increases = 0;
	File_ read_file = ReadFile("input.txt");
	int *data = (int*)calloc(sizeof(int), getSize(&read_file));
	int dataN;

	for (int i = 0; i < read_file.size; i++) {
		if (read_file.content[i] == '\n') {
			int previousSize = 0;
			int currentSize = 0;
			for (int k = i - 1; k >= 0; k--) {
				if (read_file.content[k] != '\n') {
					previousSize++;
				} else {
					break;
				}
			}
			for (int k = i + 1; k < read_file.size; k++) {
				if (read_file.content[k] != '\n') {
					currentSize++;
				} else {
					break;
				}
			}
			char *previous = calloc(sizeof(char), previousSize + 1);
			char *current = calloc(sizeof(char), currentSize + 1);
			int n = 0;
			for (int k = i - previousSize; k != i; k++) {
				if (read_file.content[k] != '\n') {
					previous[n] = read_file.content[k];
					// printf("PREV: Putthing %c at %i\n", read_file.content[k], previousSize - n);
					n++;
				} else {
					break;
				}
			}
			n = 0;
			for (int k = i + 1; k < read_file.size; k++) {
				if (read_file.content[k] != '\n') {
					current[n] = read_file.content[k];
					n++;
				} else {
					break;
				}
			}
			data[dataN++] = atoi(previous);
		}
	}
	int *total = calloc(sizeof(int), dataN - 2);
	int totalN = 0;
	for (int i = 0; i < dataN; i++) {
		if (i + 3 > dataN) {
			break;
		}
		int sumCur = data[i] + data[i + 1] + data[i + 2];
		total[totalN++] = sumCur;
	}
	for (int i = 1; i < totalN; i++) {
		if (total[i] > total[i-1]) {
			increases++;
		}
	}
	printf("Increases: %d\n", increases);
	return 0;
#endif
}