using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EduTrack.Shared.Models
{
	public class Subject
	{
		public int Id { get; init; }

		[Required]
		[JsonPropertyName("course_id")]
		public int CourseId { get; init; }

		[Required]
		[StringLength(5)]
		public string Code { get; init; } = string.Empty;

		[Required]
		[StringLength(255)]
		[JsonPropertyName("description")]
		public string Description { get; init; } = string.Empty;

		[Required]
		[JsonPropertyName("academic_year")]
		public int AcademicYear { get; init; }

		[Required]
		[JsonPropertyName("pass_mark")]
		public decimal PassMark { get; init; }

		[StringLength(255)]
		[JsonPropertyName("last_modified_by")]
		public string? LastModifiedBy { get; set; }
	}
}
