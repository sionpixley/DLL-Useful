﻿using Sion.Useful.Graphs.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sion.Useful.Graphs {
	/// <inheritdoc />
	/// <summary>
	/// Simple graph implementation.
	/// </summary>
	[Serializable]
	public class Graph<T> : IGraph<T> where T : IEquatable<T>, IComparable<T> {
		public List<Node<T>> NodeSet { get; set; }

		/// <summary>
		/// Creates a new, empty graph.
		/// </summary>
		public Graph() {
			NodeSet = [];
		}

		public bool AddEdge(Node<T> node1, Node<T> node2) {
			if(!NodeSet.Contains(node1) || !NodeSet.Contains(node2)) {
				return false;
			}
			else if(node1.Neighbors.Contains(node2) || node2.Neighbors.Contains(node1)) {
				return false;
			}
			else {
				node1.Neighbors.Add(node2);
				node2.Neighbors.Add(node1);
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
			List<bool> result = [];
			foreach(var node in nodes) {
				result.Add(AddNode(node));
			}
			return result;
		}

		public IEnumerable<bool> AddNodes(IEnumerable<Node<T>> nodes) {
			List<bool> result = [];
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

			List<Node<T>> bfs = [];
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
				return NodeSet;
			}
			else {
				return DepthFirstSearch(NodeSet[0]);
			}
		}

		public IEnumerable<Node<T>> DepthFirstSearch(Node<T> root) {
			if(!NodeSet.Contains(root)) {
				return new List<Node<T>>();
			}

			List<Node<T>> dfs = [];
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

		public bool RemoveEdge(Node<T> node1, Node<T> node2) {
			if(!NodeSet.Contains(node1) || !NodeSet.Contains(node2)) {
				return false;
			}
			else if(!node1.Neighbors.Contains(node2) || !node2.Neighbors.Contains(node1)) {
				return false;
			}
			else {
				node1.Neighbors.Remove(node2);
				node2.Neighbors.Remove(node1);
				return true;
			}
		}

		public bool RemoveNode(Node<T> node) {
			if(!NodeSet.Contains(node)) {
				return false;
			}
			else {
				foreach(var neighbor in node.Neighbors) {
					RemoveEdge(node, neighbor);
				}
				NodeSet.Remove(node);
				return true;
			}
		}

		public void ResetVisited() {
			foreach(var node in NodeSet) {
				node.HasBeenVisited = false;
			}
		}

		public override string? ToString() {
			StringBuilder sb = new();
			foreach(var node in NodeSet) {
				sb.Append($"[{node.ToString()}],");
			}
			sb.Remove(sb.Length - 1, 1);
			return sb.ToString();
		}
	}
}
