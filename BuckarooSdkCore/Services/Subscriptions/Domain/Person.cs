using System;

namespace BuckarooSdk.Services.Subscriptions.Domain
{
	public class Person : ParameterGroup
	{
		public string Initials { get; set; }
		public string Title { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string LastNamePrefix { get; set; }
		public int Gender { get; set; }
		public string Culture { get; set; }
		public DateTime BirthDate { get; set; }
		public string PlaceOfBirth { get; set; }
	}
}
