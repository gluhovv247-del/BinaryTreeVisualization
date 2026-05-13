using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTreeVisualization;

public interface ICreateBinaryTree<T>
{
    void CreateBinaryTree(T settings);
    void SaveToFile();
    void LoadFromFile();
}
