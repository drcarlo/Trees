using System.Collections.Generic;

class MinimaxTree<T>
{
    MinimaxTreeNode<T> root = null;
    List<MinimaxTreeNode<T>> nodes = new List<MinimaxTreeNode<T>>();

    public MinimaxTree(T value)
    {
        root = new MinimaxTreeNode<T>(value, null);
        nodes.Add(root);
    }

    public int Count
    {
        get { return nodes.Count; }
    }

    public MinimaxTreeNode<T> Root
    {
        get { return root; }
    }

    void Clear()
    {
        // remove all the children from each node
        // so nodes can be garbage collected
        foreach (MinimaxTreeNode<T> node in nodes)
        {
            node.Parent = null;
            node.RemoveAllChildren();
        }

        // now remove all the nodes from the tree and set root to null
        for (int i = nodes.Count - 1; i >= 0; i--)
        {
            nodes.RemoveAt(i);
        }
        root = null;
    }

    public bool AddNode(MinimaxTreeNode<T> node)
    {
        if (node == null ||
            node.Parent == null ||
            !nodes.Contains(node.Parent))
        {
            return false;
        }
        else if (node.Parent.Children.Contains(node))
        {
            // node already a child of parent
            return false;
        }
        else
        {
            // add child as tree node and as a child to parent
            nodes.Add(node);
            return node.Parent.AddChild(node);
        }
    }

    public bool RemoveNode(MinimaxTreeNode<T> removeNode)
    {
        if (removeNode == null)
        {
            return false;
        }
        else if (removeNode == root)
        {
            // removing the root clears the tree
            Clear();
            return true;
        }
        else
        {
            // remove as child of parent
            bool success = removeNode.Parent.RemoveChild(removeNode);
            if (!success)
            {
                return false;
            }

            // remove node from tree
            success = nodes.Remove(removeNode);
            if (!success)
            {
                return false;
            }

            // check for branch node
            if (removeNode.Children.Count > 0)
            {
                // recursively prune subtree
                IList<MinimaxTreeNode<T>> children = removeNode.Children;
                for (int i = children.Count - 1; i >= 0; i--)
                {
                    RemoveNode(children[i]);
                }
            }

            return true;
        }
    }

    public MinimaxTreeNode<T> Find(T value)
    {
        foreach (MinimaxTreeNode<T> node in nodes)
        {
            if (node.Value.Equals(value))
            {
                return node;
            }
        }
        return null;
    }
}
