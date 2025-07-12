using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Shared.Modules
{

	public class Course
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public int CourseTypeId { get; set; }
		public string Name { get; set; }
		public int? DurationYears { get; set; }
		public bool IsDeleted { get; set; }
		public string? CreatedBy { get; set; }
		public string CreatedDate { get; set; }
		public string? LastModifiedBy { get; set; }
		public string LastModifiedDate { get; set; }
	}
}
