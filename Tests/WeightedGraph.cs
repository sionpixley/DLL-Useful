using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests {
	[TestClass]
	public class WeightedGraph {
		[TestMethod]
		public void AddEdge() {
			try {
				Sion.Useful.Classes.WeightedGraph<int, int> graph = new();
				Sion.Useful.Classes.WeightedNode<int, int> node1 = new();
				Sion.Useful.Classes.WeightedNode<int, int> node2 = new();
				graph.AddNodes(node1, node2);
				graph.AddEdge(node1, node2, 3);
				bool wasSuccessful = (
					node1.Neighbors.Contains(node2) && node1.Weights.Count > 0
					&& node2.Neighbors.Contains(node1) && node2.Weights.Count > 0
				);
				Assert.IsTrue(wasSuccessful);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void AddEdge_Existing() {
			try {
				Sion.Useful.Classes.WeightedGraph<int, int> graph = new();
				Sion.Useful.Classes.WeightedNode<int, int> node1 = new();
				Sion.Useful.Classes.WeightedNode<int, int> node2 = new();
				graph.AddNodes(node1, node2);
				graph.AddEdge(node1, node2, 5);
				bool wasSuccessful = graph.AddEdge(node1, node2, 7);
				Assert.IsFalse(wasSuccessful);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void AddNode() {
			try {
				Sion.Useful.Classes.WeightedGraph<int, int> graph = new();
				Sion.Useful.Classes.WeightedNode<int, int> node = new();
				graph.AddNode(node);
				bool wasSuccessful = graph.NodeSet.Contains(node);
				Assert.IsTrue(wasSuccessful);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void AddNode_Existing() {
			try {
				Sion.Useful.Classes.WeightedGraph<int, int> graph = new();
				Sion.Useful.Classes.WeightedNode<int, int> node = new();
				graph.AddNode(node);
				bool wasSuccessful = graph.AddNode(node);
				Assert.IsFalse(wasSuccessful);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void AddNodes_IEnumerable() {
			try {
				Sion.Useful.Classes.WeightedGraph<int, int> graph = new();
				Sion.Useful.Classes.WeightedNode<int, int> node1 = new();
				Sion.Useful.Classes.WeightedNode<int, int> node2 = new();
				Sion.Useful.Classes.WeightedNode<int, int> node3 = new();
				List<Sion.Useful.Classes.WeightedNode<int, int>> nodes = new() { node1, node2, node3 };
				bool wasSuccessful = graph.AddNodes(nodes).All(n => n);
				Assert.IsTrue(wasSuccessful);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void AddNodes_Params() {
			try {
				Sion.Useful.Classes.WeightedGraph<int, int> graph = new();
				Sion.Useful.Classes.WeightedNode<int, int> node1 = new();
				Sion.Useful.Classes.WeightedNode<int, int> node2 = new();
				Sion.Useful.Classes.WeightedNode<int, int> node3 = new();
				bool wasSuccessful = graph.AddNodes(node1, node2, node3).All(n => n);
				Assert.IsTrue(wasSuccessful);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void Clear() {
			try {
				Sion.Useful.Classes.WeightedGraph<int, int> graph = new();
				Sion.Useful.Classes.WeightedNode<int, int> node1 = new();
				Sion.Useful.Classes.WeightedNode<int, int> node2 = new();
				Sion.Useful.Classes.WeightedNode<int, int> node3 = new();
				graph.AddNodes(node1, node2, node3);
				graph.Clear();
				bool wasSuccessful = graph.NodeSet.Count == 0;
				Assert.IsTrue(wasSuccessful);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void CustomToString() {
			try {
				Sion.Useful.Classes.WeightedGraph<int, int> graph = new();
				Sion.Useful.Classes.WeightedNode<int, int> node1 = new(1);
				Sion.Useful.Classes.WeightedNode<int, int> node2 = new(2);
				graph.AddNodes(node1, node2);
				graph.AddEdge(node1, node2, 5);

				string expected = "[1],[2]";
				string result = graph.ToString();

				Assert.AreEqual(expected, result);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void DepthFirstSearch_Default() {
			try {
				Sion.Useful.Classes.WeightedGraph<int, int> graph = new();
				Sion.Useful.Classes.WeightedNode<int, int> node1 = new(1);
				Sion.Useful.Classes.WeightedNode<int, int> node2 = new(2);
				Sion.Useful.Classes.WeightedNode<int, int> node3 = new(3);
				Sion.Useful.Classes.WeightedNode<int, int> node4 = new(4);
				graph.AddNodes(node1, node2, node3, node4);
				graph.AddEdge(node1, node2, 3);
				graph.AddEdge(node1, node3, 4);
				graph.AddEdge(node1, node4, 6);
				graph.AddEdge(node3, node4, 1);
				IEnumerable<Sion.Useful.Classes.WeightedNode<int, int>> dfs = graph.DepthFirstSearch();
				List<Sion.Useful.Classes.WeightedNode<int, int>> expected = new() { node1, node2, node3, node4 };
				Assert.IsTrue(Enumerable.SequenceEqual(dfs, expected));
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void DepthFirstSearch_Empty() {
			try {
				Sion.Useful.Classes.WeightedGraph<int, int> graph = new();
				IEnumerable<Sion.Useful.Classes.WeightedNode<int, int>> dfs = graph.DepthFirstSearch();
				Assert.AreEqual(dfs.Count(), 0);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void DepthFirstSearch_NotExisting() {
			try {
				Sion.Useful.Classes.WeightedGraph<int, int> graph = new();
				Sion.Useful.Classes.WeightedNode<int, int> node = new();
				List<Sion.Useful.Classes.WeightedNode<int, int>> dfs = graph.DepthFirstSearch(node).ToList();
				Assert.AreEqual(dfs.Count, 0);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void DepthFirstSearch_RootProvided() {
			try {
				Sion.Useful.Classes.WeightedGraph<int, int> graph = new();
				Sion.Useful.Classes.WeightedNode<int, int> node1 = new(1);
				Sion.Useful.Classes.WeightedNode<int, int> node2 = new(2);
				Sion.Useful.Classes.WeightedNode<int, int> node3 = new(3);
				Sion.Useful.Classes.WeightedNode<int, int> node4 = new(4);
				graph.AddNodes(node1, node2, node3, node4);
				graph.AddEdge(node1, node2, 3);
				graph.AddEdge(node1, node3, 4);
				graph.AddEdge(node1, node4, 6);
				graph.AddEdge(node3, node4, 1);
				IEnumerable<Sion.Useful.Classes.WeightedNode<int, int>> dfs = graph.DepthFirstSearch(node3);
				List<Sion.Useful.Classes.WeightedNode<int, int>> expected = new() { node3, node4, node1, node2 };
				Assert.IsTrue(Enumerable.SequenceEqual(dfs, expected));
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void RemoveEdge() {
			try {
				Sion.Useful.Classes.WeightedGraph<int, int> graph = new();
				Sion.Useful.Classes.WeightedNode<int, int> node1 = new();
				Sion.Useful.Classes.WeightedNode<int, int> node2 = new();
				graph.AddNodes(node1, node2);
				graph.AddEdge(node1, node2, 7);
				graph.RemoveEdge(node1, node2);
				bool wasSuccessful = (
					!node1.Neighbors.Contains(node2) && node1.Weights.Count == 0
					&& !node2.Neighbors.Contains(node1) && node2.Weights.Count == 0
				);
				Assert.IsTrue(wasSuccessful);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void RemoveEdge_NotExisting() {
			try {
				Sion.Useful.Classes.WeightedGraph<int, int> graph = new();
				Sion.Useful.Classes.WeightedNode<int, int> node1 = new();
				Sion.Useful.Classes.WeightedNode<int, int> node2 = new();
				graph.AddNodes(node1, node2);
				bool wasSuccessful = graph.RemoveEdge(node1, node2);
				Assert.IsFalse(wasSuccessful);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void RemoveNode() {
			try {
				Sion.Useful.Classes.WeightedGraph<int, int> graph = new();
				Sion.Useful.Classes.WeightedNode<int, int> node = new();
				graph.AddNode(node);
				graph.RemoveNode(node);
				bool wasSuccessful = !graph.NodeSet.Contains(node);
				Assert.IsTrue(wasSuccessful);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void RemoveNode_NotExisting() {
			try {
				Sion.Useful.Classes.WeightedGraph<int, int> graph = new();
				Sion.Useful.Classes.WeightedNode<int, int> node = new();
				bool wasSuccessful = graph.RemoveNode(node);
				Assert.IsFalse(wasSuccessful);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}
	}
}
