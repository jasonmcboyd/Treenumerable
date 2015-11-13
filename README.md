# Treenumerable [![Build status](https://ci.appveyor.com/api/projects/status/t2k5sprexxmiq0ey)](https://ci.appveyor.com/project/JasonBoyd/treenumerable) [![License](http://img.shields.io/badge/license-MIT-blue.svg?style=flat-square)](#license)

## Available on NuGet

To install the [Treenumerable](https://www.nuget.org/packages/Treenumerable/) package
run the following command in the [Package Manager Console](http://docs.nuget.org/docs/start-here/using-the-package-manager-console):

    PM> Install-Package Treenumerable

## What Is It
*Treenumerable* is a general purpose library for enumerating, traversing and querying just about any tree.  If, given any node in your tree, you can navigate to the node's parent and children then you can use *Treenumerable*.

## What Can It Do

- **GetAncestors**
  
  Gets a node's ancestors, starting with its parent node and ending with the root node.
  
- **GetAncestorsAndSelf**
  
  Gets a node and a node's ancestors, starting with its parent node and ending with the root node.

- **GetBranches**

  Gets a node's branches; a branch being a path from the node to a leaf node.
  
- **GetChildAt**

  Gets a node's (or nodes') child at the specified index.  Throws an *ArgumentOutOfRangeException* if the index is not valid.
  
- **GetChildAtOrDefault**

  Gets a node's (or nodes') child at the specified index.  Returns a default value if the index is not valid.
  
- **GetChildren**

  Several overloads exist that allow getting a node's (or nodes') children based on a predicate or a key.
  
- **GetDegree**

   Gets the degree of a node (number of children).
   
- **GetDepth**

  Gets the depth of the node.  The depth is measured by the number of edges between the node and the root of the tree.

- **GetDescendants**

  Gets a node's (or nodes') nearest descendants based on a predicate or a key.  'Nearest descendants' means the first node in each branch that satisfies the predicate or matches the key.  Once a branch yields a node no further nodes in that branch are evaluated.
  
- **GetFollowingSiblings**

  Gets a node's following siblings, i.e. all nodes that share the same parent and follow the node in the parent's list of children.
  
- **GetHeight**

  Gets the height of the node.  The height is measured by the number of edges between node and its deepest leaf.

- **GetLeaves**

  Gets a node's leaves, i.e. all descendants of that node that do not have children.  If the node has no children then the node itself is returned.
  
- **GetLevel**

  Returns all nodes at a depth relative to the specified node.
  
- **GetParent**

  Returns a node's parent or throws an InvalidOperationException if the node does not have a parent.
  
- **GetParentOrDefault**

  Returns a node's parent or a default node if no parent exists.
  
- **GetPrecedingSiblings**

  Gets a node's preceding siblings, i.e. all nodes that share the same parent and precede the node in the parent's list of children.
  
- **GetRoot**

  Gets the root node of a tree given a node in that tree.  If the node does not have any ancestors then the node itself is returned.
  
- **GetSiblings**

  Gets a node's siblings, i.e. all nodes that share the same parent.
  
- **HasChildren**

  Determines if a node has children.
  
- **HasParent**

  Determines if a node has a parent.
  
- **LevelOrderTraversal**

  Enumerates a tree using the level-order traversal method.  I.e. it returns all nodes in the first level relative to the specified node, followed by all nodes in the second level, etc...  This is comparable to a breadth first search.

- **PostOrderTraversal**

  Enumerates a tree using the post-order traversal method.
  
- **PreOrderTraversal**

  Enumerates a tree using the pre-order traversal method.
  
- **TryGetParent**

  Uses the try pattern (returns a bool and takes the parent node as an out parameter) to try and get a node's parent.

## How Does It Work
To get started with *Treenumerable* all you have to do is implement the *ITreeWalker* interface and its two methods: *GetAncestors* and *GetChildren*; once you have done that you get access to dozens of extension methods that allow you to enumerate, traverse and query your tree.

##### Example Implementation
How you implement *ITreeWalker* will depend on your specific scenario but let's assume your tree follows the common pattern where each node stores a value, a reference to its parent node, and references to its child nodes.  For example:

    public class Node<T>
    {
    	public Node(T value, Node<T> parent, IEnumerable<Node<T>> children)
    	{
    		this.Value = value;
    		this.Parent = parent;
    		this.Children = children;
    	}
    	
    	public T Value { get; private set;}
    	public Node<T> Parent { get; private set;}
    	public IEnumerable<Node<T>> Children { get; private set;}
    }

An  *ITreeWalker* implementation for this tree would simply look like this:

    public class MyTreeWalker<T> : ITreeWalker<Node<T>>
    {
    	public IEnumerable<Node<T>> GetAncestors(Node<T> node)
    	{
    		Node<T> parent = node.Parent;
    		while (parent != null)
    		{
    			yield return parent;
    			parent = parent.Parent;
    		}
    	}
    
    	public IEnumerable<Node<T>> GetChildren(Node<T> node)
    	{
    		// Note the null coalescing operator in this example.
    		// Treenumerable does not play nicely with null IEnumerables.  If your node 
    		// returns a null IEnumerable you should ensure that your ITreeWalker returns
    		// an empty IEnumerable instead.
    		return node.Children ?? Enumerable.Empty<Node<T>>();
    	}
    }
    
##### Calculated Tree Example

*Treenumerable* is particularly well suited for calculated trees (the children and ancestors are calculated from the current node).  The following *ITreeWalker* implementation operates on the the Collatz tree ([Collatz conjecture](https://en.wikipedia.org/wiki/Collatz_conjecture)) by calculating each value on the fly:

    public class CollatzTreeWalker : ITreeWalker<long>
    {
    	public IEnumerable<long> GetAncestors(long node)
    	{
    		if (node <= 0)
    		{
    			yield break;
    		}
    
    		while (node > 1)
    		{
    			if ((node & 1) == 0)
    			{
    				node = node >> 1;
    			}
    			else
    			{
    				node = (node * 3) + 1;
    			}
    			yield return node;
    		}
    	}
    
    	public IEnumerable<long> GetChildren(long node)
    	{
    		if (node <= 0)
    		{
    			yield break;
    		}
    		
    		if (node << 1 > 0)
    		{
    			yield return node << 1;
    		}
    
    		if (node > 4 && (node - 1) % 3 == 0)
    		{
    			yield return (node - 1) / 3;
    		}
    	}
    
    	private static readonly CollatzTreeWalker _Instance = new CollatzTreeWalker();
    	public static CollatzTreeWalker Instance
    	{
    		get { return CollatzTreeWalker._Instance; }
    	}
    }
    
Then, using the *CollatzTreeWalker*, the following code:

    CollatzTreeWalker
    .Instance
    .GetAncestorsAndSelf(3);
    
Yields this:

> 3 10 5 16 8 4 2 1
