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
			byte[] data = new byte[1];
			RandomNumberGenerator.Fill(data);
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
			byte[] data = new byte[8];
			RandomNumberGenerator.Fill(data);
			return BitConverter.ToDouble(data, 0);
		}

		/// <summary>
		/// Creates a cryptographically-strong random 32-bit floating-point value.
		/// </summary>
		/// <returns>A cryptographically-strong random float.</returns>
		public static float Float() {
			byte[] data = new byte[4];
			RandomNumberGenerator.Fill(data);
			return BitConverter.ToSingle(data, 0);
		}

		/// <summary>
		/// Creates a cryptographically-strong random 32-bit integer value.
		/// </summary>
		/// <returns>A cryptographically-strong random int.</returns>
		public static int Int() {
			return Int32();
		}

		/// <summary>
		/// Creates a cryptographically-strong random 16-bit integer value
		/// </summary>
		/// <returns>A cryptographically-strong random short.</returns>
		public static short Int16() {
			byte[] data = new byte[2];
			RandomNumberGenerator.Fill(data);
			return BitConverter.ToInt16(data, 0);
		}

		/// <summary>
		/// Creates a cryptographically-strong random 32-bit integer value.
		/// </summary>
		/// <returns>A cryptographically-strong random int.</returns>
		public static int Int32() {
			byte[] data = new byte[4];
			RandomNumberGenerator.Fill(data);
			return BitConverter.ToInt32(data, 0);
		}

		/// <summary>
		/// Creates a cryptographically-strong random 64-bit integer value.
		/// </summary>
		/// <returns>A cryptographically-strong random long.</returns>
		public static long Int64() {
			byte[] data = new byte[8];
			RandomNumberGenerator.Fill(data);
			return BitConverter.ToInt64(data, 0);
		}

		/// <summary>
		/// Creates a cryptographically-strong random 64-bit integer value.
		/// </summary>
		/// <returns>A cryptographically-strong random long.</returns>
		public static long Long() {
			return Int64();
		}

		/// <summary>
		/// Creates a cryptographically-strong random 16-bit integer value
		/// </summary>
		/// <returns>A cryptographically-strong random short.</returns>
		public static short Short() {
			return Int16();
		}
	}
}
