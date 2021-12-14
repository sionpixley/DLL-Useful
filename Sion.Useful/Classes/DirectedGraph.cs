using Sion.Useful.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sion.Useful.Classes {
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
				throw new BehindScenes.Exception(Enums.ExceptionCode.RootProvidedDoesNotExist, "Root provided does not exist in the graph.");
			}

			List<Node<T>> result = new();
			root.HasBeenVisited = true;
			result.Add(root);

			Stack<Node<T>> order = new();
			order.Push(root);

			Node<T> current = root;
			while(NodeSet.Any(node => !node.HasBeenVisited)) {
				if(current.Neighbors.All(n => n.HasBeenVisited) && order.Count == 0) {
					break;
				}
				else if(current.Neighbors.All(n => n.HasBeenVisited)) {
					current = order.Pop();
				}
				else {
					current = current.Neighbors.Where(n => !n.HasBeenVisited).First();
					current.HasBeenVisited = true;
					result.Add(current);
					order.Push(current);
				}
			}

			return result;
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
	}
}
