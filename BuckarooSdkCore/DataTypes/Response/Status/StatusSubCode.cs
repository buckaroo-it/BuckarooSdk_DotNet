namespace BuckarooSdk.DataTypes.Response.Status
{
    /// <summary>
    /// Statussubcode class provides a code and description of the current substatus.
    /// </summary>
    public class StatusSubCode
    {
        /// <summary>
        /// The code corresponding to the current substatus.
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// The description corresponding to the current statuscode.
        /// </summary>
        public string Description { get; set; }
    }
}