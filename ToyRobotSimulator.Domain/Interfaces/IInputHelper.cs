using ToyRobotSimulator.Entities;

namespace ToyRobotSimulator.Domain.Interfaces
{
	public interface IInputHelper
	{
		Commands GetCommand(string input);

		Position GetPosition(string input);

		Directions GetDirection(string input);
	}
}
