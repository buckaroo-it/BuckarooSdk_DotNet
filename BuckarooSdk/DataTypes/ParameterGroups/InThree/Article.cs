using BuckarooSdk.Services;

namespace BuckarooSdk.DataTypes.ParameterGroups.InThree
{
    /// <summary>
    /// Represents an article with description, gross unit price, and quantity.
    /// </summary>
    public class Article : ParameterGroup
    {
        /// <summary>
        /// GroupType: Article. Description of the article.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// GroupType: Article. Gross unit price of the article.
        /// </summary>
        public string GrossUnitPrice { get; set; }

        /// <summary>
        /// GroupType: Article. Quantity of the article.
        /// </summary>
        public int Quantity { get; set; }
    }
}
