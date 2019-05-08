namespace BuckarooSdk.Services.CreditManagement.Constants
{
	public static class MaxReminderLevel
	{
		/// <summary>
		/// No reminders will be send to the consumer
		/// </summary>
		public static int NoReminders = 0;

		/// <summary>
		/// One reminder email will be send to the consumer
		/// </summary>
		public static int SingleReminder = 1;

		/// <summary>
		/// Two reminder emails will be send to the consumer
		/// </summary>
		public static int DoubleReminder = 2;

		/// <summary>
		/// Three reminder emails will be send to the consumer
		/// </summary>
		public static int TripleReminder = 3;

		/// <summary>
		/// Three reminder emails will be send to the consumer. After that, if the invoice 
		/// still isn't paid by the consumer, it will be send to a collecting agency.
		/// </summary>
		public static int TripleReminderWithTransferToCollectionAgency = 4;
	}
}
