namespace BuckarooSdk.DataTypes.Response
{
	/// <summary>
	/// The date corresponding with the consumer message within the response
	/// </summary>
    public class ConsumerMessage
    {
		/// <summary>
		/// boolean that specifies if the message is must read
		/// </summary>
        public bool MustRead { get; set; }
		/// <summary>
		/// The name of the culture that needs to be used for the message
		/// </summary>
        public string CultureName { get; set; }
		/// <summary>
		/// The title of the message
		/// </summary>
        public string Title { get; set; }
		/// <summary>
		/// the text that is used for the message
		/// </summary>
        public string PlainText { get; set; }
		/// <summary>
		/// the html text that is used for the message.
		/// </summary>
        public string HtmlText { get; set; }
    }
}