using System;

namespace AdventOfCode.Day1
{

	class Init {
		static void Main() 
		{
			String[] moduleMassList = Util.LoadInput ("input.txt");
			int fuelRequirementSum = 0;

			foreach (String mass in moduleMassList )
				fuelRequirementSum += 
					RocketEquation.CalcRequiredFuel (Convert.ToInt32 (mass));
			Console.WriteLine 
				($"The total required fuel is {fuelRequirementSum}");

			fuelRequirementSum = 0;

			foreach (String mass in moduleMassList)
				fuelRequirementSum += 
					RocketEquation.CalcRequiredFuelForFuel (
						RocketEquation.CalcRequiredFuel(Convert.ToInt32 (mass)));
			Console.WriteLine
				($"The total required fuel (with fuel weight considered is {fuelRequirementSum}");
		}
	}

	class RocketEquation
	{

		public static int CalcRequiredFuel (int mass)
		{
			return mass / 3 - 2;
		}

		public static int CalcRequiredFuelForFuel (int mass)
		{
			if (mass <= 0) return 0;
			return 
				mass + CalcRequiredFuelForFuel (CalcRequiredFuel(mass));
		}



	}

	static class Util 
	{
		public static String[] LoadInput(String inputPath)
		{
			return System.IO.File.ReadAllLines (@inputPath);
		}
	}
}