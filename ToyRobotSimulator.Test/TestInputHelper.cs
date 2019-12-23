using System;
using NUnit.Framework;
using ToyRobotSimulator.Domain;
using ToyRobotSimulator.Entities;

namespace ToyRobotSimulator.Test
{
	public class TestInputHelper
	{
		private InputHelper _inputHelper;


		[SetUp]
		public void Setup()
		{
			_inputHelper = new InputHelper();
		}

		[Test]
		public void GetCommand_ThrowExceptionWhenNotValid()
		{
			//arrange
			var input = "Palce ";

			//act
			var action = new TestDelegate(() => _inputHelper.GetCommand(input));

			//assert
			Assert.That(action, Throws.TypeOf<ArgumentException>().With.Message.StartsWith("Please enter valid command."));
		}

		[Test]
		public void GetCommand_ReturnValidCommand()
		{
			//arrange
			var input = "Place ";

			//act
			var command = _inputHelper.GetCommand(input);

			//assert
			Assert.That(command, Is.EqualTo(Commands.Place));
		}

		[Test]
		public void GetDirection_ThorwExceptionWhenInValidLengthInput()
		{
			//arrange
			var input = "Place";

			//act
			var action = new TestDelegate(() => _inputHelper.GetDirection(input));

			//assert
			Assert.That(action, Throws.TypeOf<ArgumentException>().With.Message.StartsWith("Please enter valid input."));
		}

		[Test]
		public void GetDirection_ThorwExceptionWhenInValidLengthInputPosition()
		{
			//arrange
			var input = "Place 1,";

			//act
			var action = new TestDelegate(() => _inputHelper.GetDirection(input));

			//assert
			Assert.That(action, Throws.TypeOf<ArgumentException>().With.Message.StartsWith("Please enter valid input."));
		}

		[Test]
		public void GetDirection_ThorwExceptionWhenInValidPositionInputType()
		{
			//arrange
			var input = "Place a,a,north";

			//act
			var action = new TestDelegate(() => _inputHelper.GetDirection(input));

			//assert
			Assert.That(action, Throws.TypeOf<ArgumentException>().With.Message.StartsWith("Please enter valid input."));
		}

		[Test]
		public void GetDirection_ThorwExceptionWhenInValidDirectionInputType()
		{
			//arrange
			var input = "Place 1,1,N";

			//act
			var action = new TestDelegate(() => _inputHelper.GetDirection(input));

			//assert
			Assert.That(action, Throws.TypeOf<ArgumentException>().With.Message.StartsWith("Please enter valid input."));
		}

		[Test]
		public void GetDirection_ReturnsDirection()
		{
			//arrange
			var input = "Place 1,1,North";

			//act
			var direction =  _inputHelper.GetDirection(input);

			//assert
			Assert.That(direction, Is.EqualTo(Directions.North));
		}

		[Test]
		public void GetPosition_ReturnsPosition()
		{
			//arrange
			var input = "Place 1,1,North";

			//act
			var position = _inputHelper.GetPosition(input);

			//assert
			Assert.AreEqual(1, position.Horizontal);
			Assert.AreEqual(1, position.Vertical);
		}

	}
}
