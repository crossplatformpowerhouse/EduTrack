using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Shared.Models
{
	public class About
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public string Bio { get; set; }
		public string AppVersion { get; set; }
		public string LastUpdated { get; set; }
		public string LastModifiedBy { get; set; }
	}

}
