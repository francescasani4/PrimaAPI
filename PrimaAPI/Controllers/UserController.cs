using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc; 
using PrimaAPI.Database;
using PrimaAPI.Model.Request;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PrimaAPI.Controllers
{
    [Route("api/[controller]")] // permette di affermare che questa classe è un controller
    [ApiController] //direttiva usata per sviluppare API
    public class UserController : ControllerBase
    {
        //private static FakeDatabase database = new FakeDatabase();
        private readonly FakeDatabase database = DatabaseSingleton.Instance;

        [HttpGet("id")]
        public IActionResult GetUser(int idUser)
        {
            var user = database.Users.FirstOrDefault(u => u.IdUser == idUser);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpDelete]
        public IActionResult DeleteUser(int idUser)
        {
            var user = database.Users.FirstOrDefault(u => u.IdUser == idUser);

            if (user == null)
                return NotFound();

            database.Users.Remove(user);

            return Ok(user);
        }


        [HttpPost]
        public IActionResult AddUser([FromBody] UserRequest user)
        {
            database.AddUser(new Database.User
            {
                IdUser = 0,
                UserName = user.UserName,
                Password = user.Password,
                Name = user.Name,
                Surname = user.SurName
            });

            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateUser([FromBody] UserRequest user)
        {
            var currentUser = database.Users.FirstOrDefault(u => u.IdUser == user.IdUser);

            if (user == null)
                return NotFound();

            currentUser.UserName = user.UserName;
            currentUser.Password = user.Password;
            currentUser.Name = user.Name;
            currentUser.Surname = user.SurName;

            return Ok(user);
        }

        [HttpGet("all")] //permette di definire il tipo di richiesta HTTP
        public IActionResult AllUser()
        {
            return Ok(database.Users); 
        }

        
        
    }
}

