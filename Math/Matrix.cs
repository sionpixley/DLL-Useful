using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sion.Useful.Math {
	public class Matrix<T> where T : IComparable<T>, IEquatable<T> {
		private T[,] _Matrix;

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
