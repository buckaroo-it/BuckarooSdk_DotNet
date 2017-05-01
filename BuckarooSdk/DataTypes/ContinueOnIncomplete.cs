using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuckarooSdk.DataTypes
{
	/// <summary>
	/// Enum with options for the continue on incomplete.
	/// </summary>
    public enum ContinueOnIncomplete
    {
		/// <summary>
		/// do not continue on incomplete.
		/// </summary>
        No,
		/// <summary>
		/// Redirect to HTML page on incpmplete.
		/// </summary>
        RedirectToHTML
    }
}
