import { assert } from "console";
import fs from "fs";

const Input: string = fs.readFileSync("input.txt").toString();

const Calls = Input.split("\n")[0].split(",").map(StrNum => parseInt(StrNum));
const SplitAtNewLine = Input.split("\n");
const BoardsCount = Math.round((SplitAtNewLine.length - 2) / 6);
let Boards = new Array<number[][]>();

for (let i = 0; i < BoardsCount; i++) {
	const Start = 2 + (6 * i);
	const End = Start + 5;
	const Board: number[][] = [];
	for (let k = Start; k < End; k++) {
		if (k < SplitAtNewLine.length) {
			const Line = SplitAtNewLine[k];
			Board[Board.length] = [];
			for (let n = 0; n < Line.length; n += 3) {
				const Number = parseInt(Line.substring(n, n + 2));
				Board[Board.length - 1].push(Number);
			}
		} else {
			console.warn("!!");
		}
	}
	Boards.push(Board);
}

const xA = [
	[1, 0, 0, 0, 0],
	[0, 1, 0, 0, 0],
	[0, 0, 1, 0, 0],
	[0, 0, 0, 1, 0],
	[0, 0, 0, 0, 1]
];
const xB = [
	[0, 0, 0, 0, 1],
	[0, 0, 0, 1, 0],
	[0, 0, 1, 0, 0],
	[0, 1, 0, 0, 0],
	[1, 0, 0, 0, 0]
];
function CheckForPattern(Board: number[][], Pattern: number[][]) {
	for (let y = 0; y < Pattern.length; y++) {
		for (let x = 0; x < Pattern[y].length; x++) {
			if (Pattern[y][x] === 1 && Board[y][x] > 0) {
				return false;
			}
		}
	}
	return true;
}
function CheckForWinner(): { Board: number[][], Patterns: number[][][] } | null {
	const Checked = (num: number) => num >= 0;
	for (const Board of Boards) {
		const PatternsMatched: number[][][] = [];
		if (CheckForPattern(Board, xA)) {
			PatternsMatched.push(xA);
		} else if (CheckForPattern(Board, xB)) {
			PatternsMatched.push(xB);
		} else {
			// Check x
			for (let y = 0; y < Board.length; y++) {
				let Passed = true;
				for (let x = 0; x < Board.length; x++) {
					if (Board[y][x] > 0) {
						Passed = false;
						break;
					}
				}
				if (Passed) {
					const Pattern: number[][] = [];
					for (let k = 0; k < 5; k++) {
						if (y === k) {
							Pattern[k] = [1, 1, 1, 1, 1];
						} else {
							Pattern[k] = [0, 0, 0, 0, 0];
						}
					}
					PatternsMatched.push(Pattern);
				}
			}
			// Check y
			for (let x = 0; x < Board.length; x++) {
				let Passed = true;
				for (let y = 0; y < Board.length; y++) {
					if (Board[y][x] > 0) {
						Passed = false;
						break;
					}
				}
				if (Passed) {
					const Pattern: number[][] = [];
					for (let _y = 0; _y < Board.length; _y++) {
						if (!Pattern[_y])
							Pattern[_y] = [];
						for (let _x = 0; _x < Board.length; _x++) {
							Pattern[_y][_x] = _x === x ? 1 : 0;
						}
					}
					PatternsMatched.push(Pattern);
				}
			}
		}
		if (PatternsMatched.length > 0) {
			return { Board: Board, Patterns: PatternsMatched }
		}
	}
	return null;
}

const Completed = [];

for (let CallCount = 0; CallCount < Calls.length; CallCount++) {
	const Call = Calls[CallCount];
	// negate all the boards in which the call occurs
	for (const Board of Boards) {
		for (let y = 0; y < Board.length; y++) {
			for (let x = 0; x < Board[y].length; x++) {
				if (Board[y][x] === Call) {
					Board[y][x] = -Call;
				}
			}
		}
	}

	let PatternsMatched = CheckForWinner();
	while (PatternsMatched) {
		if (PatternsMatched) {
			const UnmarkedNumbers: number[][] = PatternsMatched.Board;

			for (let y = 0; y < UnmarkedNumbers.length; y++) {
				for (let x = 0; x < UnmarkedNumbers[y].length; x++) {
					if (UnmarkedNumbers[y][x] < 0) {
						UnmarkedNumbers[y][x] = 0;
					}
				}
			}
			// Add
			let Total = 0;
			for (let y = 0; y < UnmarkedNumbers.length; y++) {
				const len = UnmarkedNumbers[y].length;
				for (let x = 0; x < len; x++) {
					Total += UnmarkedNumbers[y][x];
				}
			}
			Completed.push({
				PatternsMatched: PatternsMatched,
				Score: Total * Call
			});
			let SizeBefore = Boards.length;
			Boards = Boards.filter(Board => {
				if (PatternsMatched) {
					return Board != PatternsMatched.Board;
				} else {
					return true;
				}
			});
			assert(Boards.length < SizeBefore);
		}
		PatternsMatched = CheckForWinner();
	}
}

console.log("First to finish:");
console.log(Completed.shift());
console.log("Last to finish:");
console.log(Completed.pop());