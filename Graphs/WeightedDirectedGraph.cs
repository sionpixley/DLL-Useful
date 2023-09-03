using Sion.Useful.Graphs.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sion.Useful.Graphs {
	[Serializable]
	/// <inheritdoc />
	/// <summary>
	/// Simple weighted directed graph implementation.
	/// </summary>
	public class WeightedDirectedGraph<TValue, TWeight> : IWeightedGraph<TValue, TWeight>
		where TValue : IEquatable<TValue>, IComparable<TValue>
		where TWeight : IEquatable<TWeight>, IComparable<TWeight> {
		public List<WeightedNode<TValue, TWeight>> NodeSet { get; set; }

		/// <summary>
		/// Creates a new, empty weighted directed graph.
		/// </summary>
		public WeightedDirectedGraph() {
			NodeSet = new();
		}

		/// <summary>
		/// Adds a weighted directed edge from one node to another node.
		/// </summary>
		/// <param name="fromNode">The node that the edge starts from.</param>
		/// <param name="toNode">The node that the edge goes to.</param>
		/// <param name="weight">The value of the weight of new edge.</param>
		public bool AddEdge(WeightedNode<TValue, TWeight> fromNode, WeightedNode<TValue, TWeight> toNode, TWeight weight) {
			if(!NodeSet.Contains(fromNode) || !NodeSet.Contains(toNode)) {
				return false;
			}
			else if(fromNode.Neighbors.Contains(toNode)) {
				return false;
			}
			else {
				int i = 0;
				for(; i < fromNode.Weights.Count; i += 1) {
					if(weight.CompareTo(fromNode.Weights[0]) < 0) {
						break;
					}
				}
				fromNode.Neighbors.Insert(i, toNode);
				fromNode.Weights.Insert(i, weight);
				return true;
			}
		}

		public bool AddNode(WeightedNode<TValue, TWeight> node) {
			if(NodeSet.Contains(node)) {
				return false;
			}
			else {
				NodeSet.Add(node);
				return true;
			}
		}

		public IEnumerable<bool> AddNodes(params WeightedNode<TValue, TWeight>[] nodes) {
			List<bool> result = new();
			foreach(var node in nodes) {
				result.Add(AddNode(node));
			}
			return result;
		}

		public IEnumerable<bool> AddNodes(IEnumerable<WeightedNode<TValue, TWeight>> nodes) {
			List<bool> result = new();
			foreach(var node in nodes) {
				result.Add(AddNode(node));
			}
			return result;
		}

		public IEnumerable<WeightedNode<TValue, TWeight>> BreadthFirstSearch() {
			if(NodeSet.Count == 0) {
				return NodeSet;
			}
			else {
				return BreadthFirstSearch(NodeSet[0]);
			}
		}

		public IEnumerable<WeightedNode<TValue, TWeight>> BreadthFirstSearch(WeightedNode<TValue, TWeight> root) {
			if(!NodeSet.Contains(root)) {
				return new List<WeightedNode<TValue, TWeight>>();
			}

			List<WeightedNode<TValue, TWeight>> bfs = new();
			Queue<WeightedNode<TValue, TWeight>> visit = new();

			WeightedNode<TValue, TWeight> current = root;

			while(true) {
				if(current.Neighbors.All(n => n.HasBeenVisited) && visit.Count == 0 && current.HasBeenVisited) {
					break;
				}
				else {
					current.HasBeenVisited = true;
					bfs.Add(current);
					IEnumerable<WeightedNode<TValue, TWeight>> unvisited = current.Neighbors.Where(n => !n.HasBeenVisited);
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

		public IEnumerable<WeightedNode<TValue, TWeight>> DepthFirstSearch() {
			if(NodeSet.Count == 0) {
				return new List<WeightedNode<TValue, TWeight>>();
			}
			else {
				return DepthFirstSearch(NodeSet[0]);
			}
		}

		public IEnumerable<WeightedNode<TValue, TWeight>> DepthFirstSearch(WeightedNode<TValue, TWeight> root) {
			if(!NodeSet.Contains(root)) {
				return new List<WeightedNode<TValue, TWeight>>();
			}

			List<WeightedNode<TValue, TWeight>> dfs = new();
			Stack<WeightedNode<TValue, TWeight>> visit = new();

			WeightedNode<TValue, TWeight> current = root;
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

		/// <summary>
		/// Removes a weighted directed edge from one node to another node.
		/// </summary>
		/// <param name="fromNode">The node that the edge starts from.</param>
		/// <param name="toNode">The node that the edge goes to.</param>
		public bool RemoveEdge(WeightedNode<TValue, TWeight> fromNode, WeightedNode<TValue, TWeight> toNode) {
			int toNodeIndex = fromNode.Neighbors.IndexOf(toNode);

			if(!NodeSet.Contains(fromNode) || !NodeSet.Contains(toNode)) {
				return false;
			}
			else if(toNodeIndex == -1) {
				return false;
			}
			else {
				fromNode.Neighbors.Remove(toNode);
				fromNode.Weights = fromNode.Weights.Take(toNodeIndex).Skip(1).TakeWhile(w => true).ToList();
				return true;
			}
		}

		public bool RemoveNode(WeightedNode<TValue, TWeight> node) {
			if(!NodeSet.Contains(node)) {
				return false;
			}
			else {
				IEnumerable<WeightedNode<TValue, TWeight>> referencingNodes = NodeSet.Where(n => n.Neighbors.Contains(node));
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
