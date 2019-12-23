using System;
using NUnit.Framework;
using ToyRobotSimulator.Domain;
using ToyRobotSimulator.Entities;

namespace ToyRobotSimulator.Test
{
	public class TestTableTop
	{
		private TableTop _tableTop;

		[SetUp]
		public void Setup()
		{
			_tableTop = new TableTop();
		}

		[Test]
		public void IsValid_ThrowExceptionWhenNotValid()
		{
			//arrange
			var position = new Position
			{
				Horizontal = 6,
				Vertical = 5
			};


			//act
			var action = new TestDelegate(() => _tableTop.IsValid(position));

			//assert
			Assert.That(action, Throws.TypeOf<ArgumentException>().With.Message.StartsWith("The command will be disgarded as the position is invalid."));
		}

		[Test]
		public void IsValid_ReturnsTrueWhenValid()
		{
			//arrange
			var position = new Position
			{
				Horizontal = 5,
				Vertical = 5
			};

			//act
			var response = _tableTop.IsValid(position);

			//assert
			Assert.IsTrue(response);
		}
	}
}