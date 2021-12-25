#include <stdlib.h>
#include <stdio.h>

typedef struct {
		char *content;
		uint size;
} File_;

File_ ReadFile(const char* file_name) {
	FILE *fp;
	long lSize;
	char *buffer;

	fp = fopen (file_name , "rb");
	if(!fp) {
		perror("Error opening file.");
		exit(1);
	}

	fseek(fp, 0L, SEEK_END);
	lSize = ftell(fp);
	rewind(fp);

	/* allocate memory for entire content */
	buffer = calloc(1, lSize + 1);
	if(!buffer) {
		fclose(fp);
		fputs("Memory allocation failed", stderr);
		exit(1);
	}

	/* copy the file into the buffer */
	if(fread(buffer, lSize, 1, fp) != 1) {
		fclose(fp);
		free(buffer);
		fputs("File read fail.\n", stderr);
		exit(1);
	}

	fclose(fp);

	File_ read_file;
	read_file.size = lSize;
	read_file.content = buffer;
	return read_file;
}
