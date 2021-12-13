using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sion.Useful.Tests {
	[TestClass]
	public class DirectedGraph {
		[TestMethod]
		public void Test_AddEdge() {
			try {
				Classes.DirectedGraph<int> graph = new();
				Classes.Node<int> fromNode = new();
				Classes.Node<int> toNode = new();
				graph.AddNode(fromNode);
				graph.AddNode(toNode);
				graph.AddEdge(fromNode, toNode);
				bool wasSuccessful = fromNode.Neighbors.Contains(toNode);
				Assert.IsTrue(wasSuccessful);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void Test_AddEdge_Existing() {
			try {
				Classes.DirectedGraph<int> graph = new();
				Classes.Node<int> fromNode = new();
				Classes.Node<int> toNode = new();
				graph.AddNode(fromNode);
				graph.AddNode(toNode);
				graph.AddEdge(fromNode, toNode);
				bool wasSuccessful = graph.AddEdge(fromNode, toNode);
				Assert.IsFalse(wasSuccessful);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void Test_AddNode() {
			try {
				Classes.DirectedGraph<int> graph = new();
				Classes.Node<int> node = new();
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
				Classes.DirectedGraph<int> graph = new();
				Classes.Node<int> node = new();
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
				Classes.DirectedGraph<int> graph = new();
				Classes.Node<int> node1 = new();
				Classes.Node<int> node2 = new();
				List<Classes.Node<int>> nodes = new() { node1, node2 };
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
				Classes.DirectedGraph<int> graph = new();
				Classes.Node<int> node1 = new();
				Classes.Node<int> node2 = new();
				bool wasSuccessful = graph.AddNodes(node1, node2).All(n => n);
				Assert.IsTrue(wasSuccessful);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void Test_Clear() {
			try {
				Classes.DirectedGraph<int> graph = new();
				Classes.Node<int> node1 = new();
				Classes.Node<int> node2 = new();
				Classes.Node<int> node3 = new();
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
				Classes.DirectedGraph<int> graph = new();
				Classes.Node<int> node1 = new(1);
				Classes.Node<int> node2 = new(2);
				Classes.Node<int> node3 = new(3);
				Classes.Node<int> node4 = new(4);
				graph.AddNodes(node1, node2, node3, node4);
				graph.AddEdge(node1, node2);
				graph.AddEdge(node1, node3);
				graph.AddEdge(node2, node4);
				Queue<Classes.Node<int>> dfs = graph.DepthFirstSearch();
				List<Classes.Node<int>> expected = new() { node1, node2, node4, node3 };
				Assert.IsTrue(Enumerable.SequenceEqual(dfs, expected));
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void Test_DepthFirstSearch_Empty() {
			try {
				Classes.DirectedGraph<int> graph = new();
				Queue<Classes.Node<int>> dfs = graph.DepthFirstSearch();
				Assert.AreEqual(dfs.Count, 0);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void Test_DepthFirstSearch_NotExisting() {
			try {
				Classes.DirectedGraph<int> graph = new();
				Classes.Node<int> node = new();
				graph.DepthFirstSearch(node);
			}
			catch(Exception e) {
				if(e.Message == "Root provided does not exist in the graph.") {
					Assert.IsTrue(true);
				}
				else {
					Assert.Fail(e.Message);
				}
			}
		}

		[TestMethod]
		public void Test_DepthFirstSearch_RootProvided() {
			try {
				Classes.DirectedGraph<int> graph = new();
				Classes.Node<int> node1 = new(1);
				Classes.Node<int> node2 = new(2);
				Classes.Node<int> node3 = new(3);
				Classes.Node<int> node4 = new(4);
				graph.AddNodes(node1, node2, node3, node4);
				graph.AddEdge(node3, node2);
				graph.AddEdge(node2, node1);
				graph.AddEdge(node2, node4);
				Queue<Classes.Node<int>> dfs = graph.DepthFirstSearch(node3);
				List<Classes.Node<int>> expected = new() { node3, node2, node1, node4 };
				Assert.IsTrue(Enumerable.SequenceEqual(dfs, expected));
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void Test_RemoveEdge() {
			try {
				Classes.DirectedGraph<int> graph = new();
				Classes.Node<int> fromNode = new();
				Classes.Node<int> toNode = new();
				graph.AddNode(fromNode);
				graph.AddNode(toNode);
				graph.AddEdge(fromNode, toNode);
				graph.RemoveEdge(fromNode, toNode);
				bool wasSuccessful = fromNode.Neighbors.Contains(toNode);
				Assert.IsFalse(wasSuccessful);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void Test_RemoveEdge_NotExisting() {
			try {
				Classes.DirectedGraph<int> graph = new();
				Classes.Node<int> fromNode = new();
				Classes.Node<int> toNode = new();
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
				Classes.DirectedGraph<int> graph = new();
				Classes.Node<int> node = new();
				graph.AddNode(node);
				graph.RemoveNode(node);
				bool wasSuccessful = graph.NodeSet.Contains(node);
				Assert.IsFalse(wasSuccessful);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void Test_RemoveNode_NotExisting() {
			try {
				Classes.DirectedGraph<int> graph = new();
				Classes.Node<int> node = new();
				bool wasSuccessful = graph.RemoveNode(node);
				Assert.IsFalse(wasSuccessful);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}
	}
}
