using System;
using BuckarooSdk.Services;

namespace BuckarooSdk.DataTypes.ParameterGroups.Capayable
{
	public class Person : ParameterGroup
	{
		public string LastName { get; set; }
		public string Initials { get; set; }
		public int Gender { get; set; }
		public string Culture { get; set; }
		public DateTime BirthDate { get; set; }
	}
}
