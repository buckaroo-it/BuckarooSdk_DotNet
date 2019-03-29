using System;

namespace BuckarooSdk.Services.Notification
{
	public class NotificationExtraInfoRequest
	{
		public DateTime SendDatetime { get; set; }

		public string NotificationType { get; set; }

		public string RecipientLastName { get; set; }

		public string RecipientGender { get; set; }

		public string CommunicationMethod { get; set; }

		public string RecipientEmail { get; set; }

		public string Attachment { get; set; }

		public string RecipientFirstName { get; set; }
	}
}
