using Sion.Useful.Classes;
using System.Collections.Generic;

namespace Sion.Useful.Interfaces {
	public interface IGraph<T> {
		public List<Node<T>> NodeSet { get; set; }

		public bool AddEdge(Node<T> node1, Node<T> node2);
		public bool AddNode(Node<T> node);
		public IEnumerable<bool> AddNodes(params Node<T>[] nodes);
		public IEnumerable<bool> AddNodes(IEnumerable<Node<T>> nodes);
		public void Clear();
		public Queue<Node<T>> DepthFirstSearch();
		public Queue<Node<T>> DepthFirstSearch(Node<T> root);
		public bool RemoveEdge(Node<T> node1, Node<T> node2);
		public bool RemoveNode(Node<T> node);
	}
}
