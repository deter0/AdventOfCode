// * Failed CS Code
// * Overcomplicated it

// private static void plotLineLow(int x0, int y0, int x1, int y1, int[,] Grid) {
// 	int dx = x1 - x0;
// 	int dy = y1 - y0;
// 	int yi = 1;
// 	if (dy < 0) {
// 		yi = -1;
// 		dy = -dy;
// 	}
// 	int D = (2 * dy) - dx;
// 	int y = y0;

// 	if (x0 < x1) {
// 		for (int x = x0; x < x1; x++) {
// 			Grid[x, y]++;
// 			Console.WriteLine("Filled in: {0} {1}", x, y);
// 			if (D > 0) {
// 				y = y + yi;
// 				D = D + (2 * (dy - dx));
// 			} else {
// 				D = D + 2 * dy;
// 			}
// 		}
// 	} else {
// 		for (int x = y0; x > y1; x--) {
// 			Grid[x, y]++;
// 			Console.WriteLine("Filled in: {0} {1}", x, y);
// 			if (D > 0) {
// 				y = y + yi;
// 				D = D + (2 * (dy - dx));
// 			} else {
// 				D = D + 2 * dy;
// 			}
// 		}
// 	}
// }
// private static void plotLineHigh(int x0, int y0, int x1, int y1, int[,] Grid) {
// 	int dx = x1 - x0;
// 	int dy = y1 - y0;
// 	int xi = 1;
// 	if (dx < 0) {
// 		xi = -1;
// 		dx = -dx;
// 	}
// 	int D = (2 * dx) - dy;
// 	int x = x0;

// 	if (y0 < y1) {
// 		for (int y = y0; y < y1; y++) {
// 			Grid[x, y]++;
// 			Console.WriteLine("Filled in: {0} {1}", x, y);
// 			if (D > 0) {
// 				x = x + xi;
// 				D = D + (2 * (dx - dy));
// 			} else {
// 				D = D + 2 * dx;
// 			}
// 		}
// 	} else {
// 		for (int y = y0; y > y1; y--) {
// 			Grid[x, y]++;
// 			Console.WriteLine("Filled in: {0} {1}", x, y);
// 			if (D > 0) {
// 				x = x + xi;
// 				D = D + (2 * (dx - dy));
// 			} else {
// 				D = D + 2 * dx;
// 			}
// 		}
// 	}
// }
// ...
// int PreviousToAt = Grid[Line.From.x, Line.From.y];
// int PreviousFromAt = Grid[Line.To.x, Line.To.y];
// if (Math.Abs(Line.To.y - Line.From.y) < Math.Abs(Line.To.x - Line.From.x)) {
// 	if (Line.From.x > Line.To.x) {
// 		plotLineLow(Line.To.x, Line.To.y, Line.From.x, Line.From.y, Grid);
// 	} else {
// 		plotLineLow(Line.From.x, Line.From.y, Line.To.x, Line.To.y, Grid);
// 		}
// } else {
// 	if (Line.From.y > Line.To.y) {
// 		plotLineLow(Line.To.x, Line.To.y, Line.From.x, Line.From.y, Grid);
// 	} else {
// 		plotLineLow(Line.From.x, Line.From.y, Line.To.x, Line.To.y, Grid);
// 	}
// }
// if (Grid[Line.To.x, Line.To.y] == PreviousToAt) {
// 	Grid[Line.To.x, Line.To.y]++;
// 	Console.WriteLine("After Filled in: {0} {1}", Line.To.x, Line.To.y);
// }
// if (Grid[Line.From.x, Line.From.y] == PreviousFromAt) {
// 	Grid[Line.From.x, Line.From.y]++;
// 	Console.WriteLine("After Filled in: {0} {1}", Line.From.x, Line.From.y);
// }