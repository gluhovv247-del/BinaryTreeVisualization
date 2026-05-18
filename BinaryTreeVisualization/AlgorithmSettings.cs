using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Text;

namespace BinaryTreeVisualization;

public class AlgorithmSettings : AlgorithmInfo
{
    public List<int> Values { get; set; }
    public static readonly int maxSize = 20;
    public AlgorithmSettings(int size, string name)
    {
        _name = name;
        _description = "";
        _size = size;
        Values = new List<int>();
    }
    public void Insert()
    {
        Random rnd = new Random();
        if (_size > maxSize)
        {
            throw new IndexOutOfRangeException();
        }
        for(int i = 0; i<_size; i++)
        {
            Values.Add(rnd.Next(1, 30));
        }
    }
    public void Remove(int value)
    {
        if (!Values.Contains(value))
        {
            throw new KeyNotFoundException();
        }
    }
}
