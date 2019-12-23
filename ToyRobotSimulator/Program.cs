using System;
using ToyRobotSimulator.Domain;
using ToyRobotSimulator.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ToyRobotSimulator
{
	class Program
	{
		static void Main(string[] args)
		{
			var service = new ServiceCollection()
				.AddSingleton<IInputHelper, InputHelper>()
				.AddSingleton<IToyRobot, ToyRobot>()
				.AddSingleton<ITableTop, TableTop>()
				.AddSingleton<IRobotSimulator, RobotSimulator>()
				.BuildServiceProvider();

			Console.WriteLine("Toy Robot Simulator");
			Console.WriteLine("Place the toy robot on 5 x 5 tabletop by following command");
			Console.WriteLine("Place X,Y,Facing. (Where X and Y are integers and Facing must be East, West, South or North. ie: Place 1,2,North)");
			Console.WriteLine("After placing please use following commands");
			Console.WriteLine("Move : Moves the toy robot by 1 unit from facing direction");
			Console.WriteLine("Left : Rotate left (90 degrees) from facing direction");
			Console.WriteLine("Right : Rotate right (90 degrees) from facing direction");
			Console.WriteLine("Report : Shows where toy robot is placed");
			Console.WriteLine("Exit : Exits the toy robot simulator");

			var stop = false;
			var robotSimulator = service.GetService<IRobotSimulator>();
			do
			{
				var input = Console.ReadLine();
				if (string.IsNullOrWhiteSpace(input)) 
					continue;

				if (string.Equals("exit", input, StringComparison.OrdinalIgnoreCase))
				{
					stop = true;
				}
				else
				{
					try
					{
						var output = robotSimulator.ProcessSimulation(input);
						if (!string.IsNullOrWhiteSpace(output))
							Console.WriteLine(output);
					}
					catch (ArgumentException exception)
					{
						Console.WriteLine(exception.Message);
					}
				}
			} while (!stop);
		}
	}
}
