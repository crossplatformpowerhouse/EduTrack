using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EduTrack.Shared.Models
{
	public class Result
	{
		public int Id { get; init; }

		[Required]
		[JsonPropertyName("user_id")]
		public int UserId { get; init; }

		[Required]
		[JsonPropertyName("course_id")]
		public int CourseId { get; init; }

		[Required]
		[JsonPropertyName("subject_id")]
		public int SubjectId { get; init; }

		[Required]
		[JsonPropertyName("assessment_id")]
		public int AssessmentId { get; init; }

		public decimal? Mark { get; init; }

		[JsonPropertyName("final_mark")]
		public decimal? FinalMark { get; init; }

		[StringLength(50)]
		public string? Predicate { get; init; }

		[StringLength(255)]
		[JsonPropertyName("last_modified_by")]
		public string? LastModifiedBy { get; set; }
	}
}
