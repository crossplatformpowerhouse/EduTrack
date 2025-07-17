using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Shared.Modules
{
	public class Notification
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public string Message { get; set; }
		public string NotificationType { get; set; }
		public DateTime CreatedDate { get; set; }
		public bool IsRead { get; set; }
	}
}
