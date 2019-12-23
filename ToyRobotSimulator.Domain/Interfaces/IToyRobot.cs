using ToyRobotSimulator.Entities;

namespace ToyRobotSimulator.Domain.Interfaces
{
	public interface IToyRobot
	{
		void Place(Directions direcrtion, Position position);

		Position GetNewPosition();

		void SetNewPosition(Position position);

		void Rotate(Commands command);

		string GetCurrentReport();
	}
}
