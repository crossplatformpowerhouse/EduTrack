using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EduTrack.Shared.Models
{
	public class School
	{
		public int Id { get; init; }

		[Required]
		[StringLength(50)]
		[JsonPropertyName("emis_number")]
		public string EMISNumber { get; init; } = string.Empty;

		[Required]
		[StringLength(255)]
		[JsonPropertyName("description")]
		public string Description { get; init; } = string.Empty;

		[Required]
		[JsonPropertyName("school_type_id")]
		public int SchoolTypeId { get; init; }

		[StringLength(100)]
		public string? Phase { get; init; }

		[StringLength(50)]
		public string? Level { get; init; }

		[Required]
		[StringLength(255)]
		public string Country { get; init; } = string.Empty;

		[Required]
		[StringLength(255)]
		public string Province { get; init; } = string.Empty;

		[Required]
		[StringLength(255)]
		public string District { get; init; } = string.Empty;

		[Required]
		[StringLength(255)]
		public string Circuit { get; init; } = string.Empty;

		[StringLength(255)]
		public string? Municipality { get; init; }

		[StringLength(50)]
		[JsonPropertyName("urban_rural")]
		public string? UrbanRural { get; init; }

		[StringLength(255)]
		[JsonPropertyName("address_line1")]
		public string? AddressLine1 { get; init; }

		[StringLength(255)]
		[JsonPropertyName("address_line2")]
		public string? AddressLine2 { get; init; }

		[StringLength(255)]
		[JsonPropertyName("town_city")]
		public string? TownCity { get; init; }

		[StringLength(10)]
		[JsonPropertyName("postal_code")]
		public string? PostalCode { get; init; }

		[StringLength(50)]
		[JsonPropertyName("phone_number")]
		public string? PhoneNumber { get; init; }

		[StringLength(100)]
		public string? Email { get; init; }

		public decimal? Latitude { get; init; }

		public decimal? Longitude { get; init; }

		[StringLength(255)]
		[JsonPropertyName("last_modified_by")]
		public string? LastModifiedBy { get; set; }
	}
}
