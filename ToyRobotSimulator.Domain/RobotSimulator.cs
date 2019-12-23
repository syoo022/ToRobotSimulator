using ToyRobotSimulator.Entities;
using ToyRobotSimulator.Domain.Interfaces;

namespace ToyRobotSimulator.Domain
{
	public class RobotSimulator : IRobotSimulator
	{
		private readonly ITableTop _tableTop;
		private readonly IToyRobot _toyRobot;
		private readonly IInputHelper _inputHelper;

		public RobotSimulator(IToyRobot toyRobot, ITableTop tableTop, IInputHelper inputHelper)
		{
			_tableTop = tableTop;
			_toyRobot = toyRobot;
			_inputHelper = inputHelper;
		}

		public string ProcessSimulation(string input)
		{
			var command = _inputHelper.GetCommand(input);

			switch (command)
			{
				case Commands.Place:
					var position = _inputHelper.GetPosition(input);
					if (_tableTop.IsValid(position))
					{
						var direction = _inputHelper.GetDirection(input);
						_toyRobot.Place(direction, position);
					}
					break;
				case Commands.Move:
					var newPosition = _toyRobot.GetNewPosition();
					if (_tableTop.IsValid(newPosition))
						_toyRobot.SetNewPosition(newPosition);
					break;
				case Commands.Left:
					_toyRobot.Rotate(Commands.Left);
					break;
				case Commands.Right:
					_toyRobot.Rotate(Commands.Right);
					break;
				case Commands.Report:
					return _toyRobot.GetCurrentReport();
			}
			return string.Empty;
		}
	}
}
