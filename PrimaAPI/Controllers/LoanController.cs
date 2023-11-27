using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PrimaAPI.Database;
using PrimaAPI.Model.Request;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PrimaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private readonly FakeDatabase database = DatabaseSingleton.Instance;

        [HttpGet("id")]
        public IActionResult GetLoan(int idLoan)
        {
            var loan = database.Loans.FirstOrDefault(l => l.IdLoan == idLoan);

            if (loan == null)
                return NotFound();

            return Ok(loan);
        }

        [HttpDelete]
        public IActionResult DeleteLoan(int idLoan)
        {
            var loan = database.Loans.FirstOrDefault(l => l.IdLoan == idLoan);

            if (loan == null)
                return NotFound();

            database.Loans.Remove(loan);

            return Ok(loan);
        }

        [HttpPost]
        public IActionResult AddLoan(int idBook, int idUser, int day)
        {
            database.AddLoan(idBook, idUser, day);

            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateBook([FromBody] LoanRequest loan)
        {
            var currentLoan = database.Loans.FirstOrDefault(b => b.IdLoan == loan.IdLoan);

            if (loan == null)
                return NotFound();

            currentLoan.IdBook = loan.IdBook;
            currentLoan.IdUser = loan.IdUser;
            currentLoan.LoanDate = loan.LoanDate;
            currentLoan.DueDate = loan.DueDate;
            currentLoan.IsReturned = loan.IsReturned;

            return Ok(loan);
        }

        [HttpGet("all")]
        public IActionResult AllLoan()
        {
            return Ok(database.Loans);
        }
    }
}

