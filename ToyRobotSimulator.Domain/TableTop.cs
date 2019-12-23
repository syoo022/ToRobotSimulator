using System;
using ToyRobotSimulator.Entities;
using ToyRobotSimulator.Domain.Interfaces;

namespace ToyRobotSimulator.Domain
{
	public class TableTop : ITableTop
	{
		private readonly int _vertical = 5;

		private readonly int _horizontal = 5;

		public bool IsValid(Position position)
		{
			if (position.Vertical <= _vertical &&
				   position.Vertical >= 0 &&
				   position.Horizontal <= _horizontal &&
				   position.Horizontal >= 0)
				return true;

			throw new ArgumentException("The command will be disgarded as the position is invalid. " +
				$"Valid position is within ({_horizontal},{_vertical}), " +
				$"commnand position was ({position.Horizontal},{position.Vertical}).");
		}
	}
}
