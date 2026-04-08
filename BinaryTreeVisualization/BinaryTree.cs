using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTreeVisualization;

public class BinaryTree
{
    public Node root;
    public void Insert(int value)
    {
        root = InsertRec(root, value);
    }
    private Node InsertRec(Node root, int value)
    {
        if (root == null)
            return new Node(value);
        if (value < root.Value)
            root.Left = InsertRec(root.Left, value);
        else if (value > root.Value)
            root.Right = InsertRec(root.Right, value);
        return root;
    }
    public void Delete(int value)
    {
        root = DeleteRec(root, value);
    }
    private Node DeleteRec(Node root, int value)
    {
        if (root == null)
            return root;
        if (value < root.Value)
            root.Left = DeleteRec(root.Left, value);
        else if (value > root.Value)
            root.Right = DeleteRec(root.Right, value);
        else
        {
            if (root.Left == null)
                return root.Right;
            if (root.Right == null)
                return root.Left;
            root.Value = MinValue(root.Right);
            root.Right = DeleteRec(root.Right, root.Value);
        }
        return root;
    }
    private int MinValue(Node node)
    {
        int min = node.Value;
        while (node.Left != null)
        {
            min = node.Left.Value;
            node = node.Left;
        }
        return min;
    }
    public void PrintTree()
    {
        PrintTreeRec(root);
        Console.WriteLine();
    }
    private void PrintTreeRec(Node root)
    {
        if (root != null)
        {
            PrintTreeRec(root.Left);
            Console.WriteLine(root.Value + " ");
            PrintTreeRec(root.Right);
        }
    }
    public void Clear()
    {
        root = null;
    }
}
