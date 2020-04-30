
using System;
using System.Collections.Generic;


namespace AdventOfCode.Chemistry
{
	public class ChemicalReaction
	{
		public ChemicalReaction(string input)
		{
			InputString = input;

			string[] io = input.Split("=>", StringSplitOptions.RemoveEmptyEntries);

			if (io.Length != 2)
				throw new ArgumentException($"The input was not valid: {input}");

			string[] inputs = io[0].Split(',', StringSplitOptions.RemoveEmptyEntries);

			foreach (var item in inputs)
			{
				var kv = ParsePart(item.Trim());
				Inputs.Add(kv);
			}

			Output = ParsePart(io[1].Trim());
		}

		public string InputString { get; }

		public IDictionary<string, int> Inputs { get; private set; } = new Dictionary<string, int>();

		public KeyValuePair<string, int> Output { get; private set; }

		public double ExactOreRequirement { get; set; }

		/// <summary>
		/// Parse the amount and name of the element: '3 ABCD' -> {3} {ABCD}
		/// </summary>
		/// <param name="part">The part</param>
		/// <returns>A keyvaluepair with the amount and the name of the element</returns>
		private KeyValuePair<string, int> ParsePart(string part)
		{
			string[] split = part.Split(' ', StringSplitOptions.RemoveEmptyEntries);

			if (split.Length != 2)
				throw new ArgumentException($"The input was not valid: {part}");

			if (!int.TryParse(split[0].Trim(), out int amount))
				throw new ArgumentException($"The input was not valid: {part}");

			return new KeyValuePair<string, int>(split[1].Trim(), amount);
		}
	}
}
