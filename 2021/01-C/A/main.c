#include <stdlib.h>
#include <stdio.h>
#include <stdbool.h>

#include "../../C-Helpers/ReadFile.c"

int main() {
#if 0
	char *pointerChar = (char*) malloc(12*sizeof(char));
	pointerChar = "testingonly";
	printf("%s\n", pointerChar);
#else
	int increases = 0;
	File_ read_file = ReadFile("input.txt");

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
			previous[previousSize + 1] = '\0';
			current[currentSize + 1] = '\0';
			int current_i = atoi(current);
			int previous_i = atoi(previous);
			if (current_i > previous_i) {
				increases++;
			}
		}
	}
	printf("Increases: %d\n", increases);
	return 0;
#endif
}