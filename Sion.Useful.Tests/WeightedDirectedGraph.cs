using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests {
	[TestClass]
	public class WeightedDirectedGraph {
		[TestMethod]
		public void AddEdge() {
			try {
				Sion.Useful.Classes.WeightedDirectedGraph<int, int> graph = new();
				Sion.Useful.Classes.WeightedNode<int, int> fromNode = new();
				Sion.Useful.Classes.WeightedNode<int, int> toNode = new();
				graph.AddNodes(fromNode, toNode);
				graph.AddEdge(fromNode, toNode, 3);
				bool wasSuccessful = fromNode.Neighbors.Contains(toNode) && fromNode.Weights.Count > 0;
				Assert.IsTrue(wasSuccessful);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void AddEdge_Existing() {
			try {
				Sion.Useful.Classes.WeightedDirectedGraph<int, int> graph = new();
				Sion.Useful.Classes.WeightedNode<int, int> fromNode = new();
				Sion.Useful.Classes.WeightedNode<int, int> toNode = new();
				graph.AddNodes(fromNode, toNode);
				graph.AddEdge(fromNode, toNode, 5);
				bool wasSuccessful = graph.AddEdge(fromNode, toNode, 7);
				Assert.IsFalse(wasSuccessful);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void AddNode() {
			try {
				Sion.Useful.Classes.WeightedDirectedGraph<int, int> graph = new();
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
				Sion.Useful.Classes.WeightedDirectedGraph<int, int> graph = new();
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
				Sion.Useful.Classes.WeightedDirectedGraph<int, int> graph = new();
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
				Sion.Useful.Classes.WeightedDirectedGraph<int, int> graph = new();
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
				Sion.Useful.Classes.WeightedDirectedGraph<int, int> graph = new();
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
		public void DepthFirstSearch_Default() {
			try {
				Sion.Useful.Classes.WeightedDirectedGraph<int, int> graph = new();
				Sion.Useful.Classes.WeightedNode<int, int> node1 = new(1);
				Sion.Useful.Classes.WeightedNode<int, int> node2 = new(2);
				Sion.Useful.Classes.WeightedNode<int, int> node3 = new(3);
				Sion.Useful.Classes.WeightedNode<int, int> node4 = new(4);
				Sion.Useful.Classes.WeightedNode<int, int> node5 = new(5);
				Sion.Useful.Classes.WeightedNode<int, int> node6 = new(6);
				graph.AddNodes(node1, node2, node3, node4, node5, node6);
				graph.AddEdge(node1, node2, 2);
				graph.AddEdge(node1, node5, 5);
				graph.AddEdge(node2, node4, 6);
				graph.AddEdge(node2, node6, 6);
				graph.AddEdge(node5, node1, 3);
				graph.AddEdge(node6, node3, 1);
				IEnumerable<Sion.Useful.Classes.WeightedNode<int, int>> dfs = graph.DepthFirstSearch();
				List<Sion.Useful.Classes.WeightedNode<int, int>> expected = new() { node1, node2, node4, node6, node3, node5 };
				Assert.IsTrue(Enumerable.SequenceEqual(dfs, expected));
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void DepthFirstSearch_Empty() {
			try {
				Sion.Useful.Classes.WeightedDirectedGraph<int, int> graph = new();
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
				Sion.Useful.Classes.WeightedDirectedGraph<int, int> graph = new();
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
				Sion.Useful.Classes.WeightedDirectedGraph<int, int> graph = new();
				Sion.Useful.Classes.WeightedNode<int, int> node1 = new(1);
				Sion.Useful.Classes.WeightedNode<int, int> node2 = new(2);
				Sion.Useful.Classes.WeightedNode<int, int> node3 = new(3);
				Sion.Useful.Classes.WeightedNode<int, int> node4 = new(4);
				Sion.Useful.Classes.WeightedNode<int, int> node5 = new(5);
				Sion.Useful.Classes.WeightedNode<int, int> node6 = new(6);
				graph.AddNodes(node1, node2, node3, node4, node5, node6);
				graph.AddEdge(node1, node2, 2);
				graph.AddEdge(node1, node5, 5);
				graph.AddEdge(node2, node4, 6);
				graph.AddEdge(node2, node6, 6);
				graph.AddEdge(node5, node1, 3);
				graph.AddEdge(node6, node3, 1);
				IEnumerable<Sion.Useful.Classes.WeightedNode<int, int>> dfs = graph.DepthFirstSearch(node5);
				List<Sion.Useful.Classes.WeightedNode<int, int>> expected = new() { node5, node1, node2, node4, node6, node3 };
				Assert.IsTrue(Enumerable.SequenceEqual(dfs, expected));
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void RemoveEdge() {
			try {
				Sion.Useful.Classes.WeightedDirectedGraph<int, int> graph = new();
				Sion.Useful.Classes.WeightedNode<int, int> fromNode = new();
				Sion.Useful.Classes.WeightedNode<int, int> toNode = new();
				graph.AddNodes(fromNode, toNode);
				graph.AddEdge(fromNode, toNode, 7);
				graph.RemoveEdge(fromNode, toNode);
				bool wasSuccessful = !fromNode.Neighbors.Contains(toNode) && fromNode.Weights.Count == 0;
				Assert.IsTrue(wasSuccessful);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void RemoveEdge_NotExisting() {
			try {
				Sion.Useful.Classes.WeightedDirectedGraph<int, int> graph = new();
				Sion.Useful.Classes.WeightedNode<int, int> fromNode = new();
				Sion.Useful.Classes.WeightedNode<int, int> toNode = new();
				graph.AddNodes(fromNode, toNode);
				bool wasSuccessful = graph.RemoveEdge(fromNode, toNode);
				Assert.IsFalse(wasSuccessful);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void RemoveNode() {
			try {
				Sion.Useful.Classes.WeightedDirectedGraph<int, int> graph = new();
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
				Sion.Useful.Classes.WeightedDirectedGraph<int, int> graph = new();
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
