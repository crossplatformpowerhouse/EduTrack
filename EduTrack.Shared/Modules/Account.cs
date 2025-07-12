using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Shared.Modules
{
	public class Account
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public bool ReceiveEmailNotifications { get; set; }
		public bool ReceivePushNotifications { get; set; }
		public string? ThemePreference { get; set; }
		public string? LastLogin { get; set; }
		public bool IsDeleted { get; set; }
		public string? CreatedBy { get; set; }
		public string CreatedDate { get; set; }
		public string? LastModifiedBy { get; set; }
		public string LastModifiedDate { get; set; }
	}
}
