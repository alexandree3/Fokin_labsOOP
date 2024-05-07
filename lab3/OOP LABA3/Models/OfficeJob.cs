using System.ComponentModel.DataAnnotations.Schema;

namespace OOP_LABA3.Models
{
	public class OfficeJob
	{
		public int Id { get; set; }
		public int OfficeId { get; set; }
		[ForeignKey(nameof(OfficeId))]
		public Office? Office { get; set; }
		public int JobId { get; set; }
		[ForeignKey(nameof(JobId))]
		public Job? Job { get; set; }
	}
}