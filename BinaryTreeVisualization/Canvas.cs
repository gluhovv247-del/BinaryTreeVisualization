using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTreeVisualization;

public class Canvas
{
    private DrawingTree? _drawingTree = new DrawingTree();
    private int? canvasWidth;
    private int? canvasHeight;
    private int offset = 120;
    public void SetPictureSize(int width, int height)
    {
        canvasWidth = width;
        canvasHeight = height;
    }
    public void SetTreePosition(int x, int y) => _drawingTree.SetPosition(x, y);
    public Bitmap? DrawCanvas(Node root, EnumAct act)
    {
        Bitmap bmp = new(canvasWidth.Value, canvasHeight.Value);
        Graphics g = Graphics.FromImage(bmp);
        _drawingTree.DrawTree(g, root, act, offset);
        return bmp;
    }
}
