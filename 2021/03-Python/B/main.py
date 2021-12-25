filename = "input.txt"

lines: list[str] = [];
with open(filename) as f:
	lines = f.read().splitlines()
inputsBitSize:int = len(lines[0]);

def getCommon(bits:list[str], index:int) -> str:
	zeroCount:int = 0;
	oneCount:int = 0;
	for bit in bits:
		if (bit[index] == "0"):
			zeroCount += 1;
		else:
			oneCount += 1;
	return "1" if oneCount >= zeroCount else "0";

def leastCommonify(mostCommon:str) -> str:
	opposite:str = "";
	for letter in mostCommon:
		opposite += "1" if letter == "0" else "0";
	return opposite;

# Oxygen generator rating
# -30 minutes of my life
oxygenGeneratorRating:str = "";
def getOxygenRating(i: int, allBits: list[str]):
	assert(i < inputsBitSize);
	listOfAllBits: list[str] = allBits.copy();
	mostCommonBit:str = getCommon(listOfAllBits, i);
	def filterFN(bits:str):
		return bits[i] == mostCommonBit;
	filteredBits = list(filter(filterFN, listOfAllBits));
	assert(len(filteredBits) > 0);
	if (len(filteredBits) == 1):
		return filteredBits[0];
	else:
		return getOxygenRating(i + 1, filteredBits);
oxygenGeneratorRating = getOxygenRating(0, lines);
# print(oxygenGeneratorRating);

cO2ScrubberRating:str = "";
def getCO2ScrubberRating(i: int, allBits: list[str]):
	assert(i < inputsBitSize);
	listOfAllBits: list[str] = allBits.copy();
	mostCommonBit:str = getCommon(listOfAllBits, i);
	leastCommonBit:str = leastCommonify(mostCommonBit);
	def filterFN(bits:str):
		return bits[i] == leastCommonBit;
	filteredBits = list(filter(filterFN, listOfAllBits));
	assert(len(filteredBits) > 0);
	if (len(filteredBits) == 1):
		return filteredBits[0];
	else:
		return getCO2ScrubberRating(i + 1, filteredBits);
cO2ScrubberRating = getCO2ScrubberRating(0, lines);

print(int(oxygenGeneratorRating, 2) * int(cO2ScrubberRating, 2));