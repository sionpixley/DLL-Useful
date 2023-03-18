using System;

namespace Sion.Useful.Math {
	public class Matrix<T> where T : IComparable<T>, IEquatable<T> {
		private readonly T[,] _Matrix;

		public Matrix() {
			_Matrix = new T[1, 1];
		}

		public Matrix(int rows, int columns) {
			_Matrix = new T[rows, columns];
		}

		public Matrix(Matrix<T> matrix) {

		}
	}
}
