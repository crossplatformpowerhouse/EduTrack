using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EduTrack.Shared.Models
{
	public class Assessment
	{
		public int Id { get; init; }

		[Required]
		[JsonPropertyName("subject_id")]
		public int SubjectId { get; init; }

		[Required]
		[StringLength(5)]
		public string Code { get; init; } = string.Empty;

		[Required]
		[StringLength(255)]
		[JsonPropertyName("description")]
		public string Description { get; init; } = string.Empty;

		[StringLength(255)]
		[JsonPropertyName("last_modified_by")]
		public string? LastModifiedBy { get; set; }
	}
}
