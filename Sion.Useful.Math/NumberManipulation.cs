using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sion.Useful.Math {
	public static class NumberManipulation {
		public static float Truncate(float f, int precision) {
			string strF = f.ToString();
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

		public static double Truncate(double d, int precision) {
			string strD = d.ToString();
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
