using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sion.Useful.Tests {
	[TestClass]
	public class WeightedDirectedGraph {
		[TestMethod]
		public void Test_AddEdge() {
			try {
				Classes.WeightedDirectedGraph<int, int> graph = new();
				Classes.WeightedNode<int, int> fromNode = new();
				Classes.WeightedNode<int, int> toNode = new();
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
		public void Test_AddEdge_Existing() {
			try {
				Classes.WeightedDirectedGraph<int, int> graph = new();
				Classes.WeightedNode<int, int> fromNode = new();
				Classes.WeightedNode<int, int> toNode = new();
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
		public void Test_AddNode() {
			try {
				Classes.WeightedDirectedGraph<int, int> graph = new();
				Classes.WeightedNode<int, int> node = new();
				graph.AddNode(node);
				bool wasSuccessful = graph.NodeSet.Contains(node);
				Assert.IsTrue(wasSuccessful);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void Test_AddNode_Existing() {
			try {
				Classes.WeightedDirectedGraph<int, int> graph = new();
				Classes.WeightedNode<int, int> node = new();
				graph.AddNode(node);
				bool wasSuccessful = graph.AddNode(node);
				Assert.IsFalse(wasSuccessful);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void Test_AddNodes_IEnumerable() {
			try {
				Classes.WeightedDirectedGraph<int, int> graph = new();
				Classes.WeightedNode<int, int> node1 = new();
				Classes.WeightedNode<int, int> node2 = new();
				Classes.WeightedNode<int, int> node3 = new();
				List<Classes.WeightedNode<int, int>> nodes = new() { node1, node2, node3 };
				bool wasSuccessful = graph.AddNodes(nodes).All(n => n);
				Assert.IsTrue(wasSuccessful);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void Test_AddNodes_Params() {
			try {
				Classes.WeightedDirectedGraph<int, int> graph = new();
				Classes.WeightedNode<int, int> node1 = new();
				Classes.WeightedNode<int, int> node2 = new();
				Classes.WeightedNode<int, int> node3 = new();
				bool wasSuccessful = graph.AddNodes(node1, node2, node3).All(n => n);
				Assert.IsTrue(wasSuccessful);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void Test_Clear() {
			try {
				Classes.WeightedDirectedGraph<int, int> graph = new();
				Classes.WeightedNode<int, int> node1 = new();
				Classes.WeightedNode<int, int> node2 = new();
				Classes.WeightedNode<int, int> node3 = new();
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
		public void Test_DepthFirstSearch_Default() {
			try {
				Classes.WeightedDirectedGraph<int, int> graph = new();
				Classes.WeightedNode<int, int> node1 = new(1);
				Classes.WeightedNode<int, int> node2 = new(2);
				Classes.WeightedNode<int, int> node3 = new(3);
				Classes.WeightedNode<int, int> node4 = new(4);
				Classes.WeightedNode<int, int> node5 = new(5);
				Classes.WeightedNode<int, int> node6 = new(6);
				graph.AddNodes(node1, node2, node3, node4, node5, node6);
				graph.AddEdge(node1, node2, 2);
				graph.AddEdge(node1, node5, 5);
				graph.AddEdge(node2, node4, 6);
				graph.AddEdge(node2, node6, 6);
				graph.AddEdge(node5, node1, 3);
				graph.AddEdge(node6, node3, 1);
				IEnumerable<Classes.WeightedNode<int, int>> dfs = graph.DepthFirstSearch();
				List<Classes.WeightedNode<int, int>> expected = new() { node1, node2, node4, node6, node3, node5 };
				Assert.IsTrue(Enumerable.SequenceEqual(dfs, expected));
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void Test_DepthFirstSearch_Empty() {
			try {
				Classes.WeightedDirectedGraph<int, int> graph = new();
				IEnumerable<Classes.WeightedNode<int, int>> dfs = graph.DepthFirstSearch();
				Assert.AreEqual(dfs.Count(), 0);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void Test_DepthFirstSearch_NotExisting() {
			try {
				Classes.WeightedDirectedGraph<int, int> graph = new();
				Classes.WeightedNode<int, int> node = new();
				graph.DepthFirstSearch(node);
			}
			catch(BehindScenes.Exception ge) {
				Assert.AreEqual(ge.Code, Enums.ExceptionCode.RootProvidedDoesNotExist);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void Test_DepthFirstSearch_RootProvided() {
			try {
				Classes.WeightedDirectedGraph<int, int> graph = new();
				Classes.WeightedNode<int, int> node1 = new(1);
				Classes.WeightedNode<int, int> node2 = new(2);
				Classes.WeightedNode<int, int> node3 = new(3);
				Classes.WeightedNode<int, int> node4 = new(4);
				Classes.WeightedNode<int, int> node5 = new(5);
				Classes.WeightedNode<int, int> node6 = new(6);
				graph.AddNodes(node1, node2, node3, node4, node5, node6);
				graph.AddEdge(node1, node2, 2);
				graph.AddEdge(node1, node5, 5);
				graph.AddEdge(node2, node4, 6);
				graph.AddEdge(node2, node6, 6);
				graph.AddEdge(node5, node1, 3);
				graph.AddEdge(node6, node3, 1);
				IEnumerable<Classes.WeightedNode<int, int>> dfs = graph.DepthFirstSearch(node5);
				List<Classes.WeightedNode<int, int>> expected = new() { node5, node1, node2, node4, node6, node3 };
				Assert.IsTrue(Enumerable.SequenceEqual(dfs, expected));
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void Test_RemoveEdge() {
			try {
				Classes.WeightedDirectedGraph<int, int> graph = new();
				Classes.WeightedNode<int, int> fromNode = new();
				Classes.WeightedNode<int, int> toNode = new();
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
		public void Test_RemoveEdge_NotExisting() {
			try {
				Classes.WeightedDirectedGraph<int, int> graph = new();
				Classes.WeightedNode<int, int> fromNode = new();
				Classes.WeightedNode<int, int> toNode = new();
				graph.AddNodes(fromNode, toNode);
				bool wasSuccessful = graph.RemoveEdge(fromNode, toNode);
				Assert.IsFalse(wasSuccessful);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void Test_RemoveNode() {
			try {
				Classes.WeightedDirectedGraph<int, int> graph = new();
				Classes.WeightedNode<int, int> node = new();
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
		public void Test_RemoveNode_NotExisting() {
			try {
				Classes.WeightedDirectedGraph<int, int> graph = new();
				Classes.WeightedNode<int, int> node = new();
				bool wasSuccessful = graph.RemoveNode(node);
				Assert.IsFalse(wasSuccessful);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}
	}
}
