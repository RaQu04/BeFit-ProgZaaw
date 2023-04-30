﻿using System;
using Microsoft.AspNetCore.Identity;

namespace BeFit.Models
{
	public class ApplicationUser : IdentityUser
	{
		public string? FirstName { get; set; }
		public string? Role { get; set; }
	}
}

