# Treenumerable [![Build status](https://ci.appveyor.com/api/projects/status/t2k5sprexxmiq0ey)](https://ci.appveyor.com/project/JasonBoyd/treenumerable)

## What Is It
Treenumerable is a general purpose library for enumerating, traversing and querying just about any tree.  If, given any node in your tree, you can navigate to the node's parent and children then you can use Treenumerable.

## How Does It Work
To get started with Treenumerable all you have to do is implement the *ITreeWalker* interface and its two methods: *TryGetParent* and *GetChildren*; once you have done that you get access to dozens of extension methods that allow you to enumerate, traverse and query your tree.

## What Can It Do
After you implement the *ITreeWalker* interface the following extension methods are available:

- **GetAncestors**
  
  Gets a node's ancestors, starting with its parent node and ending with the root node.

- **GetChildAt**

  Gets a node's (or nodes') child at the specified index.  Throws an *ArgumentOutOfRangeException* if the index is not valid.
  
- **GetChildAtOrDefault**

  Gets a node's (or nodes') child at the specified index.  Returns a default value if the index is not valid.
  
- **GetDegree**

   Gets the degree of a node (number of children).
   
- **GetDepth**

  Gets the depth of the node.  The depth is measured by the number of edges between the node and the root of the tree.
  
- **GetHeight**

  Gets the height of the node.  The height is measured by the number of edges between node and its deepest leaf.

- **GetLeaves**

  Gets a node's leaves, i.e. all descendants of that node that do not have children.  If the node has no children then the node itself is returned.
  
- **GetLevel**

  Returns all nodes at a depth relative to the specified node.
  
- **GetParentOrDefault**

  Returns a node's parent or a default node if no parent exists.
  
- **GetRoot**

  Gets the root node of a tree given a node in that tree.
  
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
  
- **SelectChildren**

  Selects a node's (or nodes') children based on a predicate or a key.
  
- **SelectDescendants**

  Selects a node's (or nodes') nearest descendants based on a predicate or a key.  The nearest descendant means the first node in a branch that meets the criteria.  Once a node has been returned in a branch no further nodes in that branch are evaluated.
