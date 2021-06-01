using NCKH.Infrastruture.Binding.Constans;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Models
{
	public class ResourcePermission
	{
		public string Id { get; set; }
		public string TenantId { get; set; }
		public int PageId { get; set; }
		public TypeRole Type { get; set; }
		public string ObjectId { get; set; }
		public int Permissions { get; set; }
	}
}
