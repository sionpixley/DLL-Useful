﻿using Sion.Useful.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sion.Useful.Classes {
	public class Graph<T> : IGraph<T> {
		public List<Node<T>> NodeSet { get; set; }

		public Graph() {
			NodeSet = new();
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

		public Queue<Node<T>> DepthFirstSearch() {
			if(NodeSet.Count == 0) {
				return new Queue<Node<T>>();
			}
			else {
				return DepthFirstSearch(NodeSet[0]);
			}
		}

		public Queue<Node<T>> DepthFirstSearch(Node<T> root) {
			if(!NodeSet.Contains(root)) {
				throw new Exception("Root provided does not exist in the graph.");
			}

			Queue<Node<T>> result = new();
			root.HasBeenVisited = true;
			result.Enqueue(root);

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
					IEnumerable<Node<T>> notVisited = current.Neighbors.Where(n => !n.HasBeenVisited);
					current = notVisited.First();
					current.HasBeenVisited = true;
					result.Enqueue(current);
					order.Push(current);
				}
			}

			return result;
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
	}
}