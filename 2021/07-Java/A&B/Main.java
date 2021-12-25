import java.io.*;
import java.util.ArrayList;
import java.util.Scanner;
import java.util.concurrent.atomic.AtomicInteger;

public class Main {
	static Integer FactorialButAddAndZeroWeirdFunction(Integer n) {
		if (n == 0) {
			return 0;
		}
		return n + FactorialButAddAndZeroWeirdFunction(n - 1);
	}
	public static void main(String[] args) {
		File inputFile = new File("input.txt");
		try (Scanner myReader = new Scanner(inputFile)) {
			while (myReader.hasNextLine()) {
				String data = myReader.nextLine();
				String[] crabPositionsString = data.split(",");
				ArrayList<Integer> Positions = new ArrayList<Integer>();
				for (String position : crabPositionsString) {
					Integer positionI = Integer.parseInt(position);
					Positions.add(positionI);
				}
				Integer maxFishPosition = 0;
				for (Integer fishPosition : Positions) {
					if (fishPosition > maxFishPosition) {
						maxFishPosition = fishPosition;
					}
				}
				Integer minFuelA = Integer.MAX_VALUE;
				Integer minFuelB = Integer.MAX_VALUE;
				for (Integer i = 0; i < maxFishPosition; i++) {
					// Calculate fuel taken to get to i
					Integer fuelTakenA = 0;
					Integer fuelTakenB = 0;
					for (Integer fishPosition : Positions) {
						Integer Difference = Math.abs(fishPosition - i);
						Integer DifferenceFactorial = FactorialButAddAndZeroWeirdFunction(Difference);

						fuelTakenA += Difference;
						fuelTakenB += DifferenceFactorial;
						if (fuelTakenA > minFuelA && fuelTakenB > minFuelB) {
							break;
						}
					}
					if (fuelTakenA < minFuelA) {
						minFuelA = fuelTakenA;
					}
					if (fuelTakenB < minFuelB) {
						minFuelB = fuelTakenB;
					}
				}
				System.out.println("Part A:");
				System.out.println(minFuelA);
				System.out.println("Part B:");
				System.out.println(minFuelB);
			}
		} catch (FileNotFoundException e) {
			e.printStackTrace();
		}
	}
}