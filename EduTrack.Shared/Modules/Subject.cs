using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Shared.Modules
{
	public class Subject
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public int CourseId { get; set; }
		public string Name { get; set; }
		public int AcademicYear { get; set; }
		public float PassMark { get; set; }
		public float ClassTestWeight { get; set; }
		public float SemesterTestWeight { get; set; }
		public float ClassAssignmentWeight { get; set; }
		public float SemesterAssignmentWeight { get; set; }
		public float ExamWeight { get; set; }
		public bool IsDeleted { get; set; }
		public string? CreatedBy { get; set; }
		public string CreatedDate { get; set; }
		public string? LastModifiedBy { get; set; }
		public string LastModifiedDate { get; set; }
	}
}
