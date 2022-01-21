using FlightSchoolPro.UserAPI.Controllers;
using FlightSchoolPro.UserAPI.Models;
using NUnit.Framework;

namespace FlightSchoolPro.Users.UnitTests
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void TestGetUsers()
		{
			var controll = new UsersController(new UserContext(null));

			//Assert.DoesNotThrow(x=> controll.GetUsers());
		}
	}
}