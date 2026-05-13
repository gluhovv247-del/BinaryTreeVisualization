using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTreeVisualization;

public class RunBinaryTree : ICreateBinaryTree<AlgorithmSettings>
{
    public Node root;
    public void CreateBinaryTree(AlgorithmSettings settings)
    {
        root = null;
        foreach (var value in settings.Values)
        {
            root = InsertTree(root, value);
        }
    }
    public void Delete(int value)
    {
        root = DeleteElementFromTree(root, value);
    }
    public void LoadFromFile()
    {
        throw new NotImplementedException();
    }

    public void SaveToFile()
    {
        throw new NotImplementedException();
    }
    public Node InsertTree(Node root, int value)
    {
        {
            if (root == null)
                return new Node(value);
            if (value < root.Value)
                root.Left = InsertTree(root.Left, value);
            else if (value > root.Value)
                root.Right = InsertTree(root.Right, value);
            return root;
        }
    }
    private Node DeleteElementFromTree(Node root, int value)
    {

        if (root == null)
            return root;
        if (value < root.Value)
            root.Left = DeleteElementFromTree(root.Left, value);
        else if (value > root.Value)
            root.Right = DeleteElementFromTree(root.Right, value);
        else
        {
            if (root.Left == null)
                return root.Right;
            if (root.Right == null)
                return root.Left;
            root.Value = MinValue(root.Right);
            root.Right = DeleteElementFromTree(root.Right, root.Value);
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
}
