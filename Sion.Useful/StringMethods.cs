using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sion.Useful {
	public static class StringMethods {
		public static string Base64ToUtf8(string base64) {
			byte[] raw = Convert.FromBase64String(base64);
			return Encoding.UTF8.GetString(raw);
		}
	}
}
