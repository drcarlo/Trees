using System.Collections.Generic;
using UnityEngine;
class TestMinimaxTree : MonoBehaviour
{
    void printChildren(MinimaxTreeNode<char> _child) {
        IList<MinimaxTreeNode<char>> children = _child.Children;
        if (children.Count > 0)
        {
            foreach (MinimaxTreeNode<char> child in children)
            {
                Debug.Log("Node item value: " + child.Value + ", Node Parent: " + child.Parent.Value);
                printChildren(child);
            }
        }
    }
    void Start()
    {
        // build and mark the tree with minimax scores
        MinimaxTree<char> tree = BuildTree();

        // print out tree
        Debug.Log("Root item value: " + tree.Root.Value);
        IList<MinimaxTreeNode<char>> children = tree.Root.Children;
        if (children.Count > 0)
        {
            foreach (MinimaxTreeNode<char> child in children)
            {
                Debug.Log("Node item value: " + child.Value + ", Node Parent: " + child.Parent.Value);
                printChildren(child);
            }
        }

        // sets whether we are maximizing
        bool maximizing = false;
        Minimax(tree.Root, maximizing);

        // find child node with maximum score
        MinimaxTreeNode<char> maxChildNode = children[0];
        for (int i = 1; i < children.Count;i++)
        {
            if (maximizing) {
                if (children[i].MinimaxScore > maxChildNode.MinimaxScore)
                {
                    maxChildNode = children[i];
                }
            } else {
                if (children[i].MinimaxScore < maxChildNode.MinimaxScore)
                {
                    maxChildNode = children[i];
                }
            }
        }

        Debug.Log("Best move is to node: " + maxChildNode.Value);
    }

    static MinimaxTree<char> BuildTree()
    {
        MinimaxTree<char> tree = new MinimaxTree<char>('A');
        MinimaxTreeNode<char> bNode = new MinimaxTreeNode<char>('B', tree.Root);
        tree.AddNode(bNode);
        MinimaxTreeNode<char> cNode = new MinimaxTreeNode<char>('C', tree.Root);
        tree.AddNode(cNode);
        MinimaxTreeNode<char> dNode = new MinimaxTreeNode<char>('D', tree.Root);
        tree.AddNode(dNode);
        MinimaxTreeNode<char> eNode = new MinimaxTreeNode<char>('E', bNode);
        tree.AddNode(eNode);
        MinimaxTreeNode<char> fNode = new MinimaxTreeNode<char>('F', bNode);
        tree.AddNode(fNode);
        MinimaxTreeNode<char> gNode = new MinimaxTreeNode<char>('G', bNode);
        tree.AddNode(gNode);
        MinimaxTreeNode<char> hNode = new MinimaxTreeNode<char>('H', cNode);
        tree.AddNode(hNode);
        MinimaxTreeNode<char> iNode = new MinimaxTreeNode<char>('I', cNode);
        tree.AddNode(iNode);
        MinimaxTreeNode<char> jNode = new MinimaxTreeNode<char>('J', dNode);
        tree.AddNode(jNode);
        MinimaxTreeNode<char> kNode = new MinimaxTreeNode<char>('K', dNode);
        tree.AddNode(kNode);
        MinimaxTreeNode<char> lNode = new MinimaxTreeNode<char>('L', eNode);
        tree.AddNode(lNode);
        MinimaxTreeNode<char> mNode = new MinimaxTreeNode<char>('M', eNode);
        tree.AddNode(mNode);
        MinimaxTreeNode<char> nNode = new MinimaxTreeNode<char>('N', fNode);
        tree.AddNode(nNode);
        MinimaxTreeNode<char> oNode = new MinimaxTreeNode<char>('O', fNode);
        tree.AddNode(oNode);
        MinimaxTreeNode<char> pNode = new MinimaxTreeNode<char>('P', gNode);
        tree.AddNode(pNode);
        MinimaxTreeNode<char> qNode = new MinimaxTreeNode<char>('Q', gNode);
        tree.AddNode(qNode);
        MinimaxTreeNode<char> rNode = new MinimaxTreeNode<char>('R', hNode);
        tree.AddNode(rNode);
        MinimaxTreeNode<char> sNode = new MinimaxTreeNode<char>('S', hNode);
        tree.AddNode(sNode);
        MinimaxTreeNode<char> tNode = new MinimaxTreeNode<char>('T', iNode);
        tree.AddNode(tNode);
        MinimaxTreeNode<char> uNode = new MinimaxTreeNode<char>('U', iNode);
        tree.AddNode(uNode);
        MinimaxTreeNode<char> vNode = new MinimaxTreeNode<char>('V', jNode);
        tree.AddNode(vNode);
        MinimaxTreeNode<char> wNode = new MinimaxTreeNode<char>('W', jNode);
        tree.AddNode(wNode);
        MinimaxTreeNode<char> xNode = new MinimaxTreeNode<char>('X', kNode);
        tree.AddNode(xNode);
        MinimaxTreeNode<char> yNode = new MinimaxTreeNode<char>('Y', kNode);
        tree.AddNode(yNode);
        return tree;
    }

    static void Minimax(MinimaxTreeNode<char> tree,
        bool maximizing)
    {
        // recurse on children
        IList<MinimaxTreeNode<char>> children = tree.Children;
        if (children.Count > 0)
        {
            foreach (MinimaxTreeNode<char> child in children)
            {
                // toggle maximizing as we move down
                Minimax(child, !maximizing);
            }

            // set default node minimax score
            if (maximizing)
            {
                tree.MinimaxScore = int.MinValue;
            }
            else
            {
                tree.MinimaxScore = int.MaxValue;
            }

            // find maximum or minimum value in children
            foreach (MinimaxTreeNode<char> child in children)
            {
                if (maximizing)
                {
                    // check for higher minimax score
                    if (child.MinimaxScore > tree.MinimaxScore)
                    {
                        tree.MinimaxScore = child.MinimaxScore;
                    }
                }
                else
                {
                    // minimizing, check for lower minimax score
                    if (child.MinimaxScore < tree.MinimaxScore)
                    {
                        tree.MinimaxScore = child.MinimaxScore;
                    }
                }
            }
        }
        else
        {
            // leaf nodes are the base case
            AssignMinimaxScore(tree);
        }
    }

    static void AssignMinimaxScore(MinimaxTreeNode<char> node)
    {
        switch (node.Value)
        {
            case 'L':
                node.MinimaxScore = 7;
                break;
            case 'M':
                node.MinimaxScore = 6;
                break;
            case 'N':
                node.MinimaxScore = 8;
                break;
            case 'O':
                node.MinimaxScore = 5;
                break;
            case 'P':
                node.MinimaxScore = 2;
                break;
            case 'Q':
                node.MinimaxScore = 3;
                break;
            case 'R':
                node.MinimaxScore = 0;
                break;
            case 'S':
                node.MinimaxScore = -2;
                break;
            case 'T':
                node.MinimaxScore = 6;
                break;
            case 'U':
                node.MinimaxScore = 2;
                break;
            case 'V':
                node.MinimaxScore = 5;
                break;
            case 'W':
                node.MinimaxScore = 8;
                break;
            case 'X':
                node.MinimaxScore = 9;
                break;
            case 'Y':
                node.MinimaxScore = 2;
                break;
        }
    }
}
