filename = "input.txt"

lines: list[str] = [];
with open(filename) as f:
	lines = f.read().splitlines()

averageInput:str = "";
inputsBitSize:int = len(lines[0]);
for i in range(inputsBitSize):
	zeroCount: int = 0;
	oneCount: int = 0;
	for k in range(len(lines)):
		if (lines[k][i] == '0'):
			zeroCount += 1;
		else:
			oneCount += 1;
	averageInput += "1" if oneCount > zeroCount else "0";

gammaRate: str = averageInput;
epsilonRate: str = "";

for j in range(inputsBitSize):
	epsilonRate += "1" if gammaRate[j] == "0" else "0";

print(int(gammaRate, 2) * int(epsilonRate, 2));