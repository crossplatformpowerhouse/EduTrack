﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Shared.Modules
{
	public class ExamType
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public bool IsDeleted { get; set; }
		public string? CreatedBy { get; set; }
		public string CreatedDate { get; set; }
		public string? LastModifiedBy { get; set; }
		public string LastModifiedDate { get; set; }
	}
}
