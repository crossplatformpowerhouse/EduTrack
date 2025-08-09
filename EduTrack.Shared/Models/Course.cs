using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EduTrack.Shared.Models
{

	public class Course
	{
		public int Id { get; init; }

		[Required]
		[JsonPropertyName("course_type_id")]
		public int CourseTypeId { get; init; }

		[Required]
		[StringLength(20)]
		public string Code { get; init; } = string.Empty;

		[Required]
		[StringLength(255)]
		[JsonPropertyName("description")]
		public string Description { get; init; } = string.Empty;

		public int? Duration { get; init; }

		[StringLength(255)]
		[JsonPropertyName("last_modified_by")]
		public string? LastModifiedBy { get; set; }
	}
}
