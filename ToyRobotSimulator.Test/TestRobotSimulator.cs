using System;
using NUnit.Framework;
using ToyRobotSimulator.Domain;
using ToyRobotSimulator.Domain.Interfaces;
using ToyRobotSimulator.Entities;

namespace ToyRobotSimulator.Test
{
	public class TestRobotSimulator
	{
		private ITableTop _tableTop;
		private IToyRobot _toyRobot;
		private IInputHelper _inputHelper;
		private RobotSimulator _robotSimulator; 

		[SetUp]
		public void Setup()
		{
			_tableTop = new TableTop();
			_toyRobot = new ToyRobot();
			_inputHelper = new InputHelper();

			_robotSimulator = new RobotSimulator(_toyRobot, _tableTop, _inputHelper);
		}

		[Test]
		public void ProcessSimulation_Place()
		{
			//arrage
			var input = "Place 1,2,North";
			var expectedReport = "Output: 1,2,North";

			//act
			_robotSimulator.ProcessSimulation(input);
			var report = _toyRobot.GetCurrentReport();

			//assert
			Assert.AreEqual(expectedReport, report);
		}

		[Test]
		public void ProcessSimulation_Move()
		{
			//arrage
			var input = "Place 1,2,North";
			var move = "Move";
			var expectedReport = "Output: 1,3,North";

			//act
			_robotSimulator.ProcessSimulation(input);
			_robotSimulator.ProcessSimulation(move);
			var report = _toyRobot.GetCurrentReport();

			//assert
			Assert.AreEqual(expectedReport, report);
		}

		[Test]
		public void ProcessSimulation_Left()
		{
			//arrage
			var input = "Place 1,2,North";
			var move = "Left";
			var expectedReport = "Output: 1,2,West";

			//act
			_robotSimulator.ProcessSimulation(input);
			_robotSimulator.ProcessSimulation(move);
			var report = _toyRobot.GetCurrentReport();

			//assert
			Assert.AreEqual(expectedReport, report);
		}

		[Test]
		public void ProcessSimulation_Right()
		{
			//arrage
			var input = "Place 1,2,North";
			var move = "Right";
			var expectedReport = "Output: 1,2,East";

			//act
			_robotSimulator.ProcessSimulation(input);
			_robotSimulator.ProcessSimulation(move);
			var report = _toyRobot.GetCurrentReport();

			//assert
			Assert.AreEqual(expectedReport, report);
		}

		[Test]
		public void ProcessSimulation_Reposrt()
		{
			//arrage
			var input = "Place 5,2,East";
			var expectedReport = "Output: 5,2,East";

			//act
			_robotSimulator.ProcessSimulation(input);
			var report = _toyRobot.GetCurrentReport();

			//assert
			Assert.AreEqual(expectedReport, report);
		}

	}
}
