using Sion.Useful.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sion.Useful.Classes {
	[Obsolete("Please use Sion.Useful.Graphs.DirectedGraph instead. This will be removed in version 3.")]
	public class DirectedGraph<T> : IGraph<T> where T : IEquatable<T>, IComparable<T> {
		public List<Node<T>> NodeSet { get; set; }

		public DirectedGraph() {
			NodeSet = new();
		}

		public bool AddEdge(Node<T> fromNode, Node<T> toNode) {
			if(!NodeSet.Contains(fromNode) || !NodeSet.Contains(toNode)) {
				return false;
			}
			else if(fromNode.Neighbors.Contains(toNode)) {
				return false;
			}
			else {
				fromNode.Neighbors.Add(toNode);
				return true;
			}
		}

		public bool AddNode(Node<T> node) {
			if(NodeSet.Contains(node)) {
				return false;
			}
			else {
				NodeSet.Add(node);
				return true;
			}
		}

		public IEnumerable<bool> AddNodes(params Node<T>[] nodes) {
			List<bool> result = new();
			foreach(var node in nodes) {
				result.Add(AddNode(node));
			}
			return result;
		}

		public IEnumerable<bool> AddNodes(IEnumerable<Node<T>> nodes) {
			List<bool> result = new();
			foreach(var node in nodes) {
				result.Add(AddNode(node));
			}
			return result;
		}

		public IEnumerable<Node<T>> BreadthFirstSearch() {
			if(NodeSet.Count == 0) {
				return NodeSet;
			}
			else {
				return BreadthFirstSearch(NodeSet[0]);
			}
		}

		public IEnumerable<Node<T>> BreadthFirstSearch(Node<T> root) {
			if(!NodeSet.Contains(root)) {
				return new List<Node<T>>();
			}

			List<Node<T>> bfs = new();
			Queue<Node<T>> visit = new();

			Node<T> current = root;

			while(true) {
				if(current.Neighbors.All(n => n.HasBeenVisited) && visit.Count == 0 && current.HasBeenVisited) {
					break;
				}
				else {
					current.HasBeenVisited = true;
					bfs.Add(current);
					IEnumerable<Node<T>> unvisited = current.Neighbors.Where(n => !n.HasBeenVisited);
					foreach(var u in unvisited) {
						visit.Enqueue(u);
					}
					if(visit.Count > 0) {
						current = visit.Dequeue();
					}
				}
			}

			ResetVisited();
			return bfs;
		}

		public void Clear() {
			NodeSet.Clear();
		}

		public IEnumerable<Node<T>> DepthFirstSearch() {
			if(NodeSet.Count == 0) {
				return new List<Node<T>>();
			}
			else {
				return DepthFirstSearch(NodeSet[0]);
			}
		}

		public IEnumerable<Node<T>> DepthFirstSearch(Node<T> root) {
			if(!NodeSet.Contains(root)) {
				return new List<Node<T>>();
			}

			List<Node<T>> dfs = new();
			Stack<Node<T>> visit = new();

			Node<T> current = root;
			current.HasBeenVisited = true;
			dfs.Add(current);

			while(true) {
				if(current.Neighbors.All(n => n.HasBeenVisited) && current == root) {
					break;
				}
				else if(current.Neighbors.All(n => n.HasBeenVisited)) {
					current = visit.Pop();
				}
				else {
					visit.Push(current);
					current = current.Neighbors.Where(n => !n.HasBeenVisited).First();
					current.HasBeenVisited = true;
					dfs.Add(current);
				}
			}

			ResetVisited();
			return dfs;
		}

		public bool RemoveEdge(Node<T> fromNode, Node<T> toNode) {
			if(!NodeSet.Contains(fromNode) || !NodeSet.Contains(toNode)) {
				return false;
			}
			else if(!fromNode.Neighbors.Contains(toNode)) {
				return false;
			}
			else {
				fromNode.Neighbors.Remove(toNode);
				return true;
			}
		}

		public bool RemoveNode(Node<T> node) {
			if(!NodeSet.Contains(node)) {
				return false;
			}
			else {
				IEnumerable<Node<T>> referencingNodes = NodeSet.Where(n => n.Neighbors.Contains(node));
				foreach(var referencingNode in referencingNodes) {
					RemoveEdge(referencingNode, node);
				}
				node.Neighbors.Clear();
				NodeSet.Remove(node);
				return true;
			}
		}

		public void ResetVisited() {
			foreach(var node in NodeSet) {
				node.HasBeenVisited = false;
			}
		}

		public override string ToString() {
			StringBuilder sb = new();
			foreach(var node in NodeSet) {
				sb.Append($"[{node.ToString()}],");
			}
			sb.Remove(sb.Length - 1, 1);
			return sb.ToString();
		}
	}
}
