using FlightSchoolPro.UserAPI.Controllers;
using FlightSchoolPro.UserAPI.Models;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Linq;

namespace FlightSchoolPro.Users.UnitTests
{
	public class Tests
	{
		IUsersController usersController;
		[SetUp]
		public void Setup()
		{
			var options = new DbContextOptionsBuilder<UserContext>().UseInMemoryDatabase(databaseName: "Users").Options;
			usersController = new UsersController(
				new UserContext(options));
		}

		[Test]
		public void TestGetUsers()
		{
			var users = usersController.GetUsers();
			Assert.IsNotNull(users);
		}

		[Test]
		public void TestCreateUser()
		{
			var user = new User()
			{
				FirstName = "Test",
				LastName = "User",
				EmailAddress = "testuser@domain.com"
			};
			var result = usersController.PostUser(user).Result;
			Assert.IsNotNull(result);
		}

		[Test]
		public void TestUpdateUser()
		{
			//create user
			var userToCreate = new User()
			{
				FirstName = "Test",
				LastName = "User",
				EmailAddress = "testuser@domain.com"
			};
			var result = usersController.PostUser(userToCreate).Result;
			Assert.IsNotNull(result);

			//get all users
			var users = usersController.GetUsers().Result.Value;
			Assert.IsNotNull(users);

			//take id from first user
			var firstUser = users.First();
			var userToUpdate = usersController.GetUser(firstUser.Id).Result.Value;
			Assert.IsNotNull(userToUpdate);

			var newEmailAddress = "testuserupdated@domain.com";
			userToUpdate.EmailAddress = newEmailAddress;
			var putResult = usersController.PutUser(userToUpdate.Id, userToUpdate).Result;
			Assert.IsNotNull(putResult);

			//get user by id
			var getResult = usersController.GetUser(userToUpdate.Id).Result.Value;
			Assert.IsTrue(getResult.EmailAddress.Equals(newEmailAddress));
		}
	}
}