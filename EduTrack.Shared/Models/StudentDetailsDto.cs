using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EduTrack.Shared.Models
{
	public class StudentResultDto
	{
		public string Username { get; init; } = string.Empty;

		[JsonPropertyName("first_name")]
		public string? FirstName { get; init; }

		[JsonPropertyName("last_name")]
		public string? LastName { get; init; }

		public string? Email { get; init; }

		public string School { get; init; } = string.Empty;

		[JsonPropertyName("course_code")]
		public string CourseCode { get; init; } = string.Empty;

		[JsonPropertyName("course_description")]
		public string CourseDescription { get; init; } = string.Empty;

		[JsonPropertyName("course_type")]
		public string CourseType { get; init; } = string.Empty;

		[JsonPropertyName("subject_code")]
		public string SubjectCode { get; init; } = string.Empty;

		[JsonPropertyName("subject_description")]
		public string SubjectDescription { get; init; } = string.Empty;

		[JsonPropertyName("academic_year")]
		public int AcademicYear { get; init; }

		[JsonPropertyName("pass_mark")]
		public decimal PassMark { get; init; }

		[JsonPropertyName("assessment_code")]
		public string AssessmentCode { get; init; } = string.Empty;

		[JsonPropertyName("assessment_description")]
		public string AssessmentDescription { get; init; } = string.Empty;

		public decimal? Mark { get; init; }

		[JsonPropertyName("final_mark")]
		public decimal? FinalMark { get; init; }

		public string? Predicate { get; init; }
	}
}
