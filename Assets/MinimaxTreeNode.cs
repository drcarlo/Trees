using System.Collections.Generic;
class MinimaxTreeNode<T>
{
    T value;
    MinimaxTreeNode<T> parent;
    List<MinimaxTreeNode<T>> children;
    int minimaxScore = 0;

    public MinimaxTreeNode(T value, MinimaxTreeNode<T> parent)
    {
        this.value = value;
        this.parent = parent;
        children = new List<MinimaxTreeNode<T>>();
    }

    public T Value
    {
        get { return value; }
    }

    public MinimaxTreeNode<T> Parent
    {
        get { return parent; }
        set { parent = value; }
    }

    public IList<MinimaxTreeNode<T>> Children
    {
        get { return children.AsReadOnly(); }
    }

    public int MinimaxScore
    {
        get { return minimaxScore; }
        set { minimaxScore = value; }
    }

    public bool AddChild(MinimaxTreeNode<T> child)
    {
        // don't add duplicate children
        if (children.Contains(child))
        {
            return false;
        }
        else if (child == this)
        {
            // don't add self as child
            return false;
        }
        else
        {
            // add as child and add self as parent
            children.Add(child);
            child.Parent = this;
            return true;
        }
    }

    public bool RemoveChild(MinimaxTreeNode<T> child)
    {
        // only remove children in list
        if (children.Contains(child))
        {
            child.Parent = null;
            return children.Remove(child);
        }
        else
        {
            return false;
        }
    }

    public bool RemoveAllChildren()
    {
        for (int i = children.Count - 1; i >= 0; i--)
        {
            children[i].Parent = null;
            children.RemoveAt(i);
        }
        return true;
    }
}

