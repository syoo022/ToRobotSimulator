using System;
using NUnit.Framework;
using ToyRobotSimulator.Domain;
using ToyRobotSimulator.Entities;


namespace ToyRobotSimulator.Test
{
	public class TestToyRobot
	{
		private ToyRobot _toyRobot;


		[SetUp]
		public void Setup()
		{
			_toyRobot = new ToyRobot();
		}

		[Test]
		public void Place_SetPositionAndDirection()
		{
			//arrange
			var position = new Position
			{
				Horizontal = 1,
				Vertical = 2
			};

			var direction = Directions.East;
			var report = $"Output: {position.Horizontal},{position.Vertical},{direction}";

			//act
			_toyRobot.Place(direction, position);
			var currentReport = _toyRobot.GetCurrentReport();

			//assert
			Assert.That(currentReport, Is.EqualTo(report));
		}

		[Test]
		public void GetNewPosition_East()
		{
			//arrange
			var position = new Position
			{
				Horizontal = 2,
				Vertical = 2
			};

			var direction = Directions.East;
			

			//act
			_toyRobot.Place(direction, position);
			var newPosition = _toyRobot.GetNewPosition();

			//assert
			Assert.AreEqual(3, newPosition.Horizontal);
			Assert.AreEqual(2, newPosition.Vertical);
		}

		[Test]
		public void GetNewPosition_West()
		{
			//arrange
			var position = new Position
			{
				Horizontal = 2,
				Vertical = 2
			};

			var direction = Directions.West;


			//act
			_toyRobot.Place(direction, position);
			var newPosition = _toyRobot.GetNewPosition();

			//assert
			Assert.AreEqual(1, newPosition.Horizontal);
			Assert.AreEqual(2, newPosition.Vertical);
		}

		[Test]
		public void GetNewPosition_South()
		{
			//arrange
			var position = new Position
			{
				Horizontal = 2,
				Vertical = 2
			};

			var direction = Directions.South;


			//act
			_toyRobot.Place(direction, position);
			var newPosition = _toyRobot.GetNewPosition();

			//assert
			Assert.AreEqual(2, newPosition.Horizontal);
			Assert.AreEqual(1, newPosition.Vertical);
		}

		[Test]
		public void GetNewPosition_North()
		{
			//arrange
			var position = new Position
			{
				Horizontal = 2,
				Vertical = 2
			};

			var direction = Directions.North;


			//act
			_toyRobot.Place(direction, position);
			var newPosition = _toyRobot.GetNewPosition();

			//assert
			Assert.AreEqual(2, newPosition.Horizontal);
			Assert.AreEqual(3, newPosition.Vertical);
		}

		[Test]
		public void Rotate_East_Left()
		{
			//arrange
			var position = new Position
			{
				Horizontal = 4,
				Vertical = 4
			};

			var direction = Directions.East;
			var report = $"Output: {position.Horizontal},{position.Vertical},{Directions.North}";

			//act
			_toyRobot.Place(direction, position);
			_toyRobot.Rotate(Commands.Left);
			var currentReport = _toyRobot.GetCurrentReport();

			//assert
			Assert.That(currentReport, Is.EqualTo(report));
		}

		[Test]
		public void Rotate_East_Right()
		{
			//arrange
			var position = new Position
			{
				Horizontal = 4,
				Vertical = 4
			};

			var direction = Directions.East;
			var report = $"Output: {position.Horizontal},{position.Vertical},{Directions.South}"; 

			//act
			_toyRobot.Place(direction, position);
			_toyRobot.Rotate(Commands.Right);
			var currentReport = _toyRobot.GetCurrentReport();

			//assert
			Assert.That(currentReport, Is.EqualTo(report));
		}
	}
}
