using System;

namespace Sion.Useful {
	/// <summary>
	/// Static class with methods to manipulate DateTime objects.
	/// </summary>
	public static class DateTimeMethods {
		/// <summary>
		/// Returns the Unix milliseconds equivalent of a provided DateTime.
		/// </summary>
		/// <param name="date">The DateTime provided.</param>
		/// <returns>The Unix milliseconds equivalent.</returns>
		public static long ConvertToUnixMilliseconds(DateTime date) {
			DateTimeOffset offset = new(date);
			return offset.ToUnixTimeMilliseconds();
		}

		/// <summary>
		/// Returns the Unix seconds equivalent of a provided DateTime.
		/// </summary>
		/// <param name="date">The DateTime provided.</param>
		/// <returns>The Unix seconds equivalent.</returns>
		public static long ConvertToUnixSeconds(DateTime date) {
			DateTimeOffset offset = new(date);
			return offset.ToUnixTimeSeconds();
		}

		/// <summary>
		/// Returns the Unix milliseconds equivalent of the current time.
		/// </summary>
		/// <returns>The Unix milliseconds equivalent.</returns>
		public static long GetUnixMillisecondsNow() {
			return ConvertToUnixMilliseconds(DateTime.Now);
		}

		/// <summary>
		/// Returns the Unix seconds equivalent of the current time.
		/// </summary>
		/// <returns>The Unix seconds equivalent.</returns>
		public static long GetUnixSecondsNow() {
			return ConvertToUnixSeconds(DateTime.Now);
		}

		/// <summary>
		/// Returns the Unix milliseconds equivalent of a provided DateTime.
		/// </summary>
		/// <param name="date">The DateTime provided.</param>
		/// <returns>The Unix milliseconds equivalent.</returns>
		public static long ToUnixMilliseconds(this DateTime date) {
			return ConvertToUnixMilliseconds(date);
		}

		/// <summary>
		/// Returns the Unix seconds equivalent of a provided DateTime.
		/// </summary>
		/// <param name="date">The DateTime provided.</param>
		/// <returns>The Unix seconds equivalent.</returns>
		public static long ToUnixSeconds(this DateTime date) {
			return ConvertToUnixSeconds(date);
		}
	}
}
