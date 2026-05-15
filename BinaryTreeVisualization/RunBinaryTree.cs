using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTreeVisualization;

public class RunBinaryTree : ICreateBinaryTree
{
    public Node root;
    AlgorithmSettings _settings;
    public RunBinaryTree(AlgorithmSettings settings)
    {
        _settings = settings;
    }
    public void CreateBinaryTree()
    {
        root = null;
        foreach (var value in _settings.Values)
        {
            root = InsertTree(root, value);
        }
        
    }
    public void Delete(int value)
    {
        root = DeleteElementFromTree(root, value);
    }
    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            throw new FileNotFoundException();
        }
        using StreamReader sr = new(filename);
        string name = sr.ReadLine();
        string numbers = sr.ReadLine();

        string[] partsOfNumbers = numbers.Split([':'],StringSplitOptions.RemoveEmptyEntries);
        string sizeOfList = partsOfNumbers[0];
        string elements = partsOfNumbers[1];
        
        int[] arrayNumbers = elements.Split(';', StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x.Trim())).ToArray();
        _settings = new AlgorithmSettings(int.Parse(sizeOfList), name);
        foreach(int i in arrayNumbers)
        {
            _settings.Values.Add(i);
        }
        {
            
        }
    }

    public void SaveToFile(string filename)
    {
        if (File.Exists(filename))
        {
            File.Delete(filename);
        }
        using StreamWriter sw = new(filename);
        sw.Write("BinaryTree");
        sw.Write(Environment.NewLine);
        sw.Write(_settings._size.ToString() + ": ");
        foreach(int value in _settings.Values)
        {
            sw.Write(value + ";");
        }

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
