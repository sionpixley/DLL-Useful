using System;
using System.Globalization;

namespace Sion.Useful.Math {
	public static class NumberManipulation {
		public static float Truncate(this float f, int precision) {
			string strF = f.ToString(CultureInfo.InvariantCulture);
			int index = strF.IndexOf('.');

			if(index == -1) {
				return f;
			}
			else if((index + precision + 1) >= strF.Length) {
				return f;
			}
			else {
				return Convert.ToSingle(strF[..(index + precision + 1)]);
			}
		}

		public static double Truncate(this double d, int precision) {
			string strD = d.ToString(CultureInfo.InvariantCulture);
			int index = strD.IndexOf('.');

			if(index == -1) {
				return d;
			}
			else if((index + precision + 1) >= strD.Length) {
				return d;
			}
			else {
				return Convert.ToDouble(strD[..(index + precision + 1)]);
			}
		}

		public static decimal Truncate(this decimal d, int precision) {
			string strD = d.ToString(CultureInfo.InvariantCulture);
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
