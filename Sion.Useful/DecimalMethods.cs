using System;

namespace Sion.Useful {
	[Obsolete("Please use Sion.Useful.Math.NumberManipulation instead. This will be removed in a future version.")]
	public static class DecimalMethods {
		// Drops decimal points without rounding.
		public static decimal Truncate(decimal d, int precision) {
			string strD = d.ToString();
			int index = strD.IndexOf('.');

			if(index == -1) {
				return d;
			}
			else if((index + precision + 1) >= strD.Length) {
				return d;
			}
			else {
				return Convert.ToDecimal(strD[..(index + precision + 1)]);
			}
		}
	}
}
