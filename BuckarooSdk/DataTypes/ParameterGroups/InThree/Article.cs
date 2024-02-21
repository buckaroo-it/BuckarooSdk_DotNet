namespace BuckarooSdk.DataTypes.ParameterGroups.InThree
{
    /// <summary>
    /// Represents an article with description, gross unit price, and quantity.
    /// </summary>
    public class Article
    {
        /// <summary>
        /// Gets or sets the description of the article.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the gross unit price of the article.
        /// </summary>
        public string GrossUnitPrice { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the article.
        /// </summary>
        public int Quantity { get; set; }
    }
}
