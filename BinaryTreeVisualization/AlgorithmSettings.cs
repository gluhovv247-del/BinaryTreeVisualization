using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTreeVisualization;

public class AlgorithmSettings : AlgorithmInfo
{
    public List<int> Values { get; set; }
    public AlgorithmSettings(int size, string name)
    {
        _name = name;
        _description = "";
        _size = size;
        Values = new List<int>();
    }
}
