using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Shared.Modules
{
	public class Assignment
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public int SubjectId { get; set; }
		public int AssignmentTypeId { get; set; }
		public int? ExamTypeId { get; set; }
		public string Title { get; set; }
		public string? Deadline { get; set; }
		public string Semester { get; set; }
		public bool IsDeleted { get; set; }
		public string? CreatedBy { get; set; }
		public string CreatedDate { get; set; }
		public string? LastModifiedBy { get; set; }
		public string LastModifiedDate { get; set; }
	}
}
