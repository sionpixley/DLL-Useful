using Sion.Useful.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sion.Useful.Classes {
	public class WeightedGraph<TValue, TWeight> : IWeightedGraph<TValue, TWeight> 
		where TValue : IEquatable<TValue>, IComparable<TValue> 
		where TWeight : IEquatable<TWeight>, IComparable<TWeight> {
			public List<WeightedNode<TValue, TWeight>> NodeSet { get; set; }

			public WeightedGraph() {
				NodeSet = new();
			}

			public bool AddEdge(WeightedNode<TValue, TWeight> node1, WeightedNode<TValue, TWeight> node2, TWeight weight) {
				if(!NodeSet.Contains(node1) || !NodeSet.Contains(node2)) {
					return false;
				}
				else if(node1.Neighbors.Contains(node2) || node2.Neighbors.Contains(node1)) {
					return false;
				}
				else {
					int i = 0;
					for(; i < node1.Weights.Count; i += 1) {
						if(weight.CompareTo(node1.Weights[0]) < 0) {
							break;
						}
					}
					node1.Neighbors.Insert(i, node2);
					node1.Weights.Insert(i, weight);

					i = 0;
					for(; i < node2.Weights.Count; i += 1) {
						if(weight.CompareTo(node2.Weights[i]) < 0) {
							break;
						}
					}
					node2.Neighbors.Insert(i, node1);
					node2.Weights.Insert(i, weight);

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

			public bool RemoveEdge(WeightedNode<TValue, TWeight> node1, WeightedNode<TValue, TWeight> node2) {
				int node1Index = node2.Neighbors.IndexOf(node1);
				int node2Index = node1.Neighbors.IndexOf(node2);

				if(!NodeSet.Contains(node1) || !NodeSet.Contains(node2)) {
					return false;
				}
				else if(node1Index == -1 || node2Index == -1) {
					return false;
				}
				else {
					node1.Neighbors.Remove(node2);
					node1.Weights = node1.Weights.Take(node2Index).Skip(1).TakeWhile(w => true).ToList();
					node2.Neighbors.Remove(node1);
					node2.Weights = node2.Weights.Take(node1Index).Skip(1).TakeWhile(w => true).ToList();
					return true;
				}
			}

			public bool RemoveNode(WeightedNode<TValue, TWeight> node) {
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
