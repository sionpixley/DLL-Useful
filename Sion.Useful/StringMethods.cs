using System;
using System.Text;

namespace Sion.Useful {
	/// <summary>
	/// Static class with methods to manipulate string types.
	/// </summary>
	public static class StringMethods {
		/// <summary>
		/// Takes a Base64 formatted string and returns the Unicode representation.
		/// </summary>
		/// <param name="base64">The Base64 string.</param>
		/// <returns>The Unicode string representation of the Base64 string.</returns>
		public static string Base64ToUtf8(this string base64) {
			byte[] raw = Convert.FromBase64String(base64);
			return Encoding.UTF8.GetString(raw);
		}

		/// <summary>
		/// Takes a Unicode string and returns the Base64 representation.
		/// </summary>
		/// <param name="utf8">The Unicode string.</param>
		/// <returns>The Base64 string representation of the Unicode string.</returns>
		public static string Utf8ToBase64(this string utf8) {
			byte[] raw = Encoding.UTF8.GetBytes(utf8);
			return Convert.ToBase64String(raw);
		}
	}
}
