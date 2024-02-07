using System;
using System.Security.Cryptography;

namespace Sion.Useful.Security {
	/// <summary>
	/// Static class to produce cryptographically-strong random values.
	/// </summary>
	public static class Random {
		/// <summary>
		/// Creates a cryptographically-strong random boolean value.
		/// </summary>
		/// <returns>Either true or false, determined randomly.</returns>
		public static bool Bool() {
			byte[] data = Bytes(1);
			return data[0] >> 7 == 1;
		}

		/// <summary>
		/// Creates a cryptographically-strong random byte array with a given length.
		/// </summary>
		/// <param name="numOfBytes">Number of bytes you want the array to have.</param>
		/// <returns>A cryptographically-strong random byte array.</returns>
		public static byte[] Bytes(int numOfBytes = 16) {
			byte[] data = new byte[numOfBytes];
			RandomNumberGenerator.Fill(data);
			return data;
		}

		/// <summary>
		/// Creates a cryptographically-strong random 64-bit floating-point value.
		/// </summary>
		/// <returns>A cryptographically-strong random double.</returns>
		public static double Double() {
			byte[] data = Bytes(8);
			return BitConverter.ToDouble(data, 0);
		}

		/// <summary>
		/// Creates a cryptographically-strong random 64-bit floating-point value within a given range.
		/// </summary>
		/// <param name="min">The inclusive lower bound of the range. Must be less than the max argument.</param>
		/// <param name="max">The exclusive upper bound of the range.</param>
		/// <returns>A cryptographically-strong random double. The number returned will be greater than or equal to the min argument and less than the max argument.</returns>
		/// <exception cref="ArgumentException">The min argument is greater than or equal to the max argument.</exception>
		public static double Double(double min, double max) {
			if(min >= max) {
				throw new ArgumentException("The min argument must be less than the max argument.", nameof(min));
			}

			double n = (Double() + min) % max;
			while(n < min) {
				n = (Double() + min) % max;
			}

			return n;
		}

		/// <summary>
		/// Creates a cryptographically-strong random 32-bit floating-point value.
		/// </summary>
		/// <returns>A cryptographically-strong random float.</returns>
		public static float Float() {
			byte[] data = Bytes(4);
			return BitConverter.ToSingle(data, 0);
		}

		/// <summary>
		/// Creates a cryptographically-strong random 32-bit floating-point value within a given range.
		/// </summary>
		/// <param name="min">The inclusive lower bound of the range. Must be less than the max argument.</param>
		/// <param name="max">The exclusive upper bound of the range.</param>
		/// <returns>A cryptographically-strong random float. The number returned will be greater than or equal to the min argument and less than the max argument.</returns>
		/// <exception cref="ArgumentException">The min argument is greater than or equal to the max argument.</exception>
		public static float Float(float min, float max) {
			if(min >= max) {
				throw new ArgumentException("The min argument must be less than the max argument.", nameof(min));
			}

			float n = (Float() + min) % max;
			while(n < min) {
				n = (Float() + min) % max;
			}

			return n;
		}

		/// <summary>
		/// Creates a cryptographically-strong random 32-bit integer value.
		/// </summary>
		/// <returns>A cryptographically-strong random int.</returns>
		public static int Int() => Int32();

		/// <summary>
		/// Creates a cryptographically-strong random 32-bit integer value within a given range.
		/// </summary>
		/// <param name="min">The inclusive lower bound of the range. Must be less than the max argument.</param>
		/// <param name="max">The exclusive upper bound of the range.</param>
		/// <returns>A cryptographically-strong random int. The number returned will be greater than or equal to the min argument and less than the max argument.</returns>
		/// <exception cref="ArgumentException">The min argument is greater than or equal to the max argument.</exception>
		public static int Int(int min, int max) => Int32(min, max);

		/// <summary>
		/// Creates a cryptographically-strong random 16-bit integer value.
		/// </summary>
		/// <returns>A cryptographically-strong random short.</returns>
		public static short Int16() {
			byte[] data = Bytes(2);
			return BitConverter.ToInt16(data, 0);
		}

		/// <summary>
		/// Creates a cryptographically-strong random 16-bit integer value within a given range.
		/// </summary>
		/// <param name="min">The inclusive lower bound of the range. Must be less than the max argument.</param>
		/// <param name="max">The exclusive upper bound of the range.</param>
		/// <returns>A cryptographically-strong random short. The number returned will be greater than or equal to the min argument and less than the max argument.</returns>
		/// <exception cref="ArgumentException">The min argument is greater than or equal to the max argument.</exception>
		public static short Int16(short min, short max) {
			if(min >= max) {
				throw new ArgumentException("The min argument must be less than the max argument.", nameof(min));
			}

			short n = Convert.ToInt16((Int16() + min) % max);
			while(n < min) {
				n = Convert.ToInt16((Int16() + min) % max);
			}

			return n;
		}

		/// <summary>
		/// Creates a cryptographically-strong random 32-bit integer value.
		/// </summary>
		/// <returns>A cryptographically-strong random int.</returns>
		public static int Int32() {
			byte[] data = Bytes(4);
			return BitConverter.ToInt32(data, 0);
		}

		/// <summary>
		/// Creates a cryptographically-strong random 32-bit integer value within a given range.
		/// </summary>
		/// <param name="min">The inclusive lower bound of the range. Must be less than the max argument.</param>
		/// <param name="max">The exclusive upper bound of the range.</param>
		/// <returns>A cryptographically-strong random int. The number returned will be greater than or equal to the min argument and less than the max argument.</returns>
		/// <exception cref="ArgumentException">The min argument is greater than or equal to the max argument.</exception>
		public static int Int32(int min, int max) {
			if(min >= max) {
				throw new ArgumentException("The min argument must be less than the max argument.", nameof(min));
			}

			int n = (Int32() + min) % max;
			while(n < min) {
				n = (Int32() + min) % max;
			}

			return n;
		}

		/// <summary>
		/// Creates a cryptographically-strong random 64-bit integer value.
		/// </summary>
		/// <returns>A cryptographically-strong random long.</returns>
		public static long Int64() {
			byte[] data = Bytes(8);
			return BitConverter.ToInt64(data, 0);
		}

		/// <summary>
		/// Creates a cryptographically-strong random 64-bit integer value.
		/// </summary>
		/// <param name="min">The inclusive lower bound of the range. Must be less than the max argument.</param>
		/// <param name="max">The exclusive upper bound of the range.</param>
		/// <returns>A cryptographically-strong random long. The number returned will be greater than or equal to the min argument and less than the max argument.</returns>
		/// <exception cref="ArgumentException">The min argument is greater than or equal to the max argument.</exception>
		public static long Int64(long min, long max) {
			if(min >= max) {
				throw new ArgumentException("The min argument must be less than the max argument.", nameof(min));
			}

			long n = (Int64() + min) % max;
			while(n < min) {
				n = (Int64() + min) % max;
			}

			return n;
		}

		/// <summary>
		/// Creates a cryptographically-strong random 64-bit integer value.
		/// </summary>
		/// <returns>A cryptographically-strong random long.</returns>
		public static long Long() => Int64();

		/// <summary>
		/// Creates a cryptographically-strong random 64-bit integer value.
		/// </summary>
		/// <param name="min">The inclusive lower bound of the range. Must be less than the max argument.</param>
		/// <param name="max">The exclusive upper bound of the range.</param>
		/// <returns>A cryptographically-strong random long. The number returned will be greater than or equal to the min argument and less than the max argument.</returns>
		/// <exception cref="ArgumentException">The min argument is greater than or equal to the max argument.</exception>
		public static long Long(long min, long max) => Int64(min, max);

		/// <summary>
		/// Creates a cryptographically-strong random 16-bit integer value
		/// </summary>
		/// <returns>A cryptographically-strong random short.</returns>
		public static short Short() => Int16();

		/// <summary>
		/// Creates a cryptographically-strong random 16-bit integer value within a given range.
		/// </summary>
		/// <param name="min">The inclusive lower bound of the range. Must be less than the max argument.</param>
		/// <param name="max">The exclusive upper bound of the range.</param>
		/// <returns>A cryptographically-strong random short. The number returned will be greater than or equal to the min argument and less than the max argument.</returns>
		/// <exception cref="ArgumentException">The min argument is greater than or equal to the max argument.</exception>
		public static short Short(short min, short max) => Int16(min, max);
	}
}
