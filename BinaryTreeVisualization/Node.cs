using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTreeVisualization;

public class Node
{
    public int Value;
    public Node Left;
    public Node Right;
    public Node(int value)
    {
        Value = value;
        Left = null;
        Right = null;
    }
}
