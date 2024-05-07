using System.ComponentModel.DataAnnotations.Schema;

namespace OOP_LABA3.Models
{
	public class Human
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public string Address { get; set; }
		public int OfficeId { get; set; }
		[ForeignKey(nameof(OfficeId))]
		public Office? Office { get; set; }
	}
}