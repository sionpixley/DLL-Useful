using System;

namespace Sion.Useful {
	public static class DecimalMethods {
		// Drops decimal points without rounding.
		public static decimal Truncate(decimal d, int precision = 4) {
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
