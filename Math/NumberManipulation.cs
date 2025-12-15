using System;
using System.Globalization;

namespace Sion.Useful.Math
{
    /// <summary>
    /// Static class with methods to manipulate number types.
    /// </summary>
    public static class NumberManipulation
    {
        extension(float f)
        {
            /// <summary>
            /// Trims decimal places off a float value.
            /// </summary>
            /// <param name="f">The float value being truncated.</param>
            /// <param name="precision">Number of decimal places that you want to keep.</param>
            /// <returns>A truncated float trimmed to a specified number of decimal places.</returns>
            public float Truncate(int precision)
            {
                string strF = f.ToString(CultureInfo.InvariantCulture);
                int index = strF.IndexOf('.');

                if (index == -1)
                {
                    return f;
                }
                else if ((index + precision + 1) >= strF.Length)
                {
                    return f;
                }
                else
                {
                    return Convert.ToSingle(strF[..(index + precision + 1)]);
                }
            }
        }

        extension(double d)
        {
            /// <summary>
            /// Trims decimal places off a double value.
            /// </summary>
            /// <param name="d">The double value being truncated.</param>
            /// <param name="precision">Number of decimal places that you want to keep.</param>
            /// <returns>A truncated double trimmed to a specified number of decimal places.</returns>
            public double Truncate(int precision)
            {
                string strD = d.ToString(CultureInfo.InvariantCulture);
                int index = strD.IndexOf('.');

                if (index == -1)
                {
                    return d;
                }
                else if ((index + precision + 1) >= strD.Length)
                {
                    return d;
                }
                else
                {
                    return Convert.ToDouble(strD[..(index + precision + 1)]);
                }
            }
        }

        extension(decimal d)
        {
            /// <summary>
            /// Trims decimal places off a decimal value.
            /// </summary>
            /// <param name="d">The decimal value being truncated.</param>
            /// <param name="precision">Number of decimal places that you want to keep.</param>
            /// <returns>A truncated decimal trimmed to a specified number of decimal places.</returns>
            public decimal Truncate(int precision)
            {
                string strD = d.ToString(CultureInfo.InvariantCulture);
                int index = strD.IndexOf('.');

                if (index == -1)
                {
                    return d;
                }
                else if ((index + precision + 1) >= strD.Length)
                {
                    return d;
                }
                else
                {
                    return Convert.ToDecimal(strD[..(index + precision + 1)]);
                }
            }
        }
    }
}
