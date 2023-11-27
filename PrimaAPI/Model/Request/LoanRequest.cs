using System;
namespace PrimaAPI.Model.Request
{
	public class LoanRequest
	{
        public int? IdLoan { get; set; }

        public int IdBook { get; set; }

        public int IdUser { get; set; }

        public DateTime LoanDate { get; set; }

        public DateTime DueDate { get; set; }

        public bool IsReturned { get; set; }
    }
}

