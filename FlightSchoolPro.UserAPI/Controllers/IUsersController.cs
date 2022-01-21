using FlightSchoolPro.UserAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlightSchoolPro.UserAPI.Controllers
{
	public interface IUsersController
	{
		Task<ActionResult<User>> DeleteUser(long id);
		Task<ActionResult<User>> GetUser(long id);
		Task<ActionResult<IEnumerable<User>>> GetUsers();
		Task<ActionResult<User>> PostUser(User user);
		Task<IActionResult> PutUser(long id, User user);
	}
}