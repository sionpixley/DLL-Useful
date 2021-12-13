using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sion.Useful.Classes {
	public class Node<T> {
		public T Value { get; set; }
		public bool HasBeenVisited { get; set; }
		public List<Node<T>> Neighbors { get; set; }

		public Node() {
			Value = default;
			HasBeenVisited = false;
			Neighbors = new();
		}

		public Node(T value) {
			Value = value;
			HasBeenVisited = false;
			Neighbors = new();
		}

		public override string ToString() => Value.ToString();
	}
}
