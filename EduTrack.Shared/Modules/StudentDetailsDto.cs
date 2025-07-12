using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Shared.Modules
{
	public class StudentDetailsDto
	{
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
		public string? Email { get; set; }
		public string CourseType { get; set; }
		public string Course { get; set; }
		public int AcademicYear { get; set; }
		public string Subject { get; set; }
		public float PassMark { get; set; }
		public float ClassTestWeight { get; set; }
		public float SemesterTestWeight { get; set; }
		public float ClassAssignmentWeight { get; set; }
		public float SemesterAssignmentWeight { get; set; }
		public float ExamWeight { get; set; }
		public float? Grade { get; set; }
		public string AssignmentTitle { get; set; }
		public string AssignmentType { get; set; }
		public string? ExamType { get; set; }
		public string Semester { get; set; }
		public float? ClassTestAvg { get; set; }
		public float? SemesterTestAvg { get; set; }
		public float? ClassAssignmentAvg { get; set; }
		public float? SemesterAssignmentAvg { get; set; }
		public float? ExamMark { get; set; }
		public float? FinalMark { get; set; }
		public string? Predicate { get; set; }
	}
}
