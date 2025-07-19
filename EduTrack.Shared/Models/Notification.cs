using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EduTrack.Shared.Models
{
	public class Notification
	{
		public int Id { get; init; }

		[Required]
		[JsonPropertyName("user_id")]
		public int UserId { get; init; }

		[Required]
		[StringLength(500)]
		public string Message { get; init; } = string.Empty;

		[Required]
		[StringLength(50)]
		[JsonPropertyName("notification_type")]
		public string NotificationType { get; init; } = string.Empty;

		[JsonPropertyName("is_read")]
		public bool IsRead { get; init; }

		[StringLength(255)]
		[JsonPropertyName("last_modified_by")]
		public string? LastModifiedBy { get; set; }
	}

}
