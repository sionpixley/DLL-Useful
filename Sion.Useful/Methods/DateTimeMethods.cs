using System;

namespace Sion.Useful.Methods {
	public static class DateTimeMethods {
		public static long ConvertToUnixMilliseconds(DateTime date) {
			DateTimeOffset offset = new(date);
			return offset.ToUnixTimeMilliseconds();
		}

		public static long ConvertToUnixSeconds(DateTime date) {
			DateTimeOffset offset = new(date);
			return offset.ToUnixTimeSeconds();
		}

		public static long GetUnixMillisecondsNow() {
			return ConvertToUnixMilliseconds(DateTime.Now);
		}

		public static long GetUnixSecondsNow() {
			return ConvertToUnixSeconds(DateTime.Now);
		}
	}
}
