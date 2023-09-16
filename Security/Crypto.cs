using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Sion.Useful.Security {
	public static class Crypto {
		/// <summary>
		/// Creates a cryptographically-strong random salt with a given length.
		/// </summary>
		/// <param name="numOfBytes">Number of bytes you want the salt to be.</param>
		/// <returns>A cryptographically-strong random byte array.</returns>
		public static byte[] CreateSalt(int numOfBytes = 16) {
			byte[] salt = new byte[numOfBytes];
			RandomNumberGenerator.Fill(salt);
			return salt;
		}
	}
}
