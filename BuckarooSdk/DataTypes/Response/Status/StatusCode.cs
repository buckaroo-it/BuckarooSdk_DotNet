namespace BuckarooSdk.DataTypes.Response.Status
{
    /// <summary>
    /// Statussubcode class provides a code and description of the current status.
    /// </summary>
    public class StatusCode
    {
        /// <summary>
        /// The code corresponding to the current status.
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// The description corresponding to the current statuscode.
        /// </summary>
        public string Description { get; set; }
    }
}