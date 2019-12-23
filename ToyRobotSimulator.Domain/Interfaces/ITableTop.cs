using ToyRobotSimulator.Entities;

namespace ToyRobotSimulator.Domain.Interfaces
{
	public interface ITableTop
	{
		bool IsValid(Position position);
	}
}
