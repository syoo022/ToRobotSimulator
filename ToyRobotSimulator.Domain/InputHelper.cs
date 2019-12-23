using System;
using System.Linq;
using ToyRobotSimulator.Entities;
using ToyRobotSimulator.Domain.Interfaces;

namespace ToyRobotSimulator.Domain
{
	public class InputHelper : IInputHelper
	{
		public Commands GetCommand(string input)
		{
			if (!Enum.GetNames(typeof(Commands)).Any(c => string.Equals(input.Split(' ')[0], c, StringComparison.OrdinalIgnoreCase)) ||
				!Enum.TryParse(input.Split(' ')[0], true, out Commands command))
				throw new ArgumentException("Please enter valid command.");

			return command;
		}

		public Directions GetDirection(string input)
		{
			Validate(input);

			if (!Enum.TryParse(input.Split(' ')[1].Split(',')[2], true, out Directions direction))
				throw new ArgumentException("Please enter valid direction.");

			return direction;
		}

		public Position GetPosition(string input)
		{
			Validate(input);

			return new Position
			{
				Horizontal = int.Parse(input.Split(' ')[1].Split(',')[0]),
				Vertical = int.Parse(input.Split(' ')[1].Split(',')[1])
			};
		}

		private void Validate(string input)
		{
			var inputs = input.Split(' ');
			if(inputs.Length != 2)
				throw new ArgumentException("Please enter valid input. Cannot get X, Y or Direction");

			if(inputs[1].Split(',').Length != 3)
				throw new ArgumentException("Please enter valid input. Cannot get X, Y or Direction");

			if (!int.TryParse(inputs[1].Split(',')[0], out _))
				throw new ArgumentException("Please enter valid input. X has to be an interger");

			if (!int.TryParse(inputs[1].Split(',')[1], out _))
				throw new ArgumentException("Please enter valid input. Y has to be an interger");

			if (!Enum.GetNames(typeof(Directions)).Any(d => string.Equals(inputs[1].Split(',')[2], d, StringComparison.OrdinalIgnoreCase)))
				throw new ArgumentException("Please enter valid input. Direction has to be North, South, East or West");

		}
	}
}
