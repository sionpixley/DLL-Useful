using System;
using System.Text;

namespace Sion.Useful {
	public static class StringMethods {
		public static string Base64ToUtf8(string base64) {
			byte[] raw = Convert.FromBase64String(base64);
			return Encoding.UTF8.GetString(raw);
		}

		public static string Utf8ToBase64(string utf8) {
			byte[] raw = Encoding.UTF8.GetBytes(utf8);
			return Convert.ToBase64String(raw);
		}
	}
}
