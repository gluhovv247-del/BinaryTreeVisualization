using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTreeVisualization;

public interface ICreateBinaryTree 
{
    void CreateBinaryTree();
    void SaveToFile(string filename);
    void LoadFromFile(string filename);
}
