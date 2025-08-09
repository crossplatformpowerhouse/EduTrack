using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Shared.Models
{
	public class Account
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public string ReceiveEmailNotifications { get; set; }
		public string ReceivePushNotifications { get; set; }
		public DateTime LastLogin { get; set; }
		public string LastModifiedBy { get; set; }
	}
}
