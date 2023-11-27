using System;
namespace PrimaAPI.Model.Request
{
	public class BookRequest
	{
        public int? IdBook { get; set; }

        public string? Title { get; set; }

        public string? Author { get; set; }

        public DateTime PublicationDate { get; set; }
    }
}

