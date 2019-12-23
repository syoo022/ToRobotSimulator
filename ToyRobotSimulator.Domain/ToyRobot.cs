using System;
using ToyRobotSimulator.Entities;
using ToyRobotSimulator.Domain.Interfaces;

namespace ToyRobotSimulator.Domain
{
	public class ToyRobot : IToyRobot
	{
		private Position _position;
		private Directions _direction;

		public void Place(Directions direction, Position position)
		{
			_direction = direction;
			_position = position;
		}

		public Position GetNewPosition()
		{
			if (_position == null)
				throw new ArgumentException("Please place the robot first.");

			var newPosition = new Position
			{
				Horizontal = _position.Horizontal,
				Vertical = _position.Vertical
			};

			switch (_direction)
			{
				case Directions.East:
					newPosition.Horizontal += 1;
					break;
				case Directions.West:
					newPosition.Horizontal -= 1;
					break;
				case Directions.South:
					newPosition.Vertical -= 1;
					break;
				case Directions.North:
					newPosition.Vertical += 1;
					break;
			}

			return newPosition;
		}

		public void SetNewPosition(Position position)
		{
			_position = position;
		}

		public void Rotate(Commands command)
		{
			switch (command)
			{
				case Commands.Left:
					if (_direction == Directions.East)
						_direction = Directions.North;
					else if (_direction == Directions.West)
						_direction = Directions.South;
					else if(_direction == Directions.South)
						_direction = Directions.East;
					else if(_direction == Directions.North)
						_direction = Directions.West;
					return;
				case Commands.Right:
					if (_direction == Directions.East)
						_direction = Directions.South;
					else if(_direction == Directions.West)
						_direction = Directions.North;
					else if(_direction == Directions.South)
						_direction = Directions.West;
					else if(_direction == Directions.North)
						_direction = Directions.East;
					return;
			}
		}

		public string GetCurrentReport()
		{
			if (_position == null)
				throw new ArgumentException("Robot has not been placed on the table top.");

			return $"Output: {_position.Horizontal},{_position.Vertical},{_direction}";
		}
	}
}
