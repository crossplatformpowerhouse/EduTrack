using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EduTrack.Shared.Models
{
	public class User
	{
		public int Id { get; init; }

		[Required]
		[JsonPropertyName("user_type_id")]
		public int UserTypeId { get; init; }

		[Required]
		[JsonPropertyName("course_id")]
		public int CourseId { get; init; }

		[Required]
		[JsonPropertyName("school_id")]
		public int SchoolId { get; init; }

		[Required]
		[StringLength(255)]
		public string Username { get; init; } = string.Empty;

		[StringLength(255)]
		[JsonPropertyName("first_name")]
		public string? FirstName { get; init; }

		[StringLength(255)]
		[JsonPropertyName("last_name")]
		public string? LastName { get; init; }

		[StringLength(255)]
		[JsonPropertyName("password_hash")]
		public string? PasswordHash { get; init; }

		[StringLength(255)]
		public string? Email { get; init; }

		[StringLength(255)]
		public string? Cellphone { get; init; }

		[Required]
		[JsonPropertyName("receive_email_notifications")]
		public bool ReceiveEmailNotifications { get; init; } = true;

		[Required]
		[JsonPropertyName("receive_push_notifications")]
		public bool ReceivePushNotifications { get; init; } = true;

		[StringLength(50)]
		[JsonPropertyName("theme_preference")]
		public string ThemePreference { get; init; } = "System";

		[JsonPropertyName("last_login")]
		public DateTime? LastLogin { get; init; }

		[StringLength(255)]
		[JsonPropertyName("last_modified_by")]
		public string? LastModifiedBy { get; set; }
	}
}
