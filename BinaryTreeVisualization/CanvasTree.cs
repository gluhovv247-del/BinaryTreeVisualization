using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTreeVisualization;

public class CanvasTree
{
    private DrawingTree _drawingTree;
    private int? canvasWidth;
    private int? canvasHeight;
    public CanvasTree(DrawingTree? drawingTree)
    {
        _drawingTree = new DrawingTree();
        _drawingTree = drawingTree;
    }
    public void SetPictureSize(int width, int height)
    {
        canvasWidth = width;
        canvasHeight = height;
    }
    //public void InsertObject(DrawingTree tree)
    //{
    //    _drawingTree = tree;
    //}
    //public void SetPosition(int x, int y)
    //{
    //    if (x > canvasWidth)
    //    {
    //        x = canvasWidth.Value;

    //    }
    //    if (y > canvasHeight)
    //    {
    //        y = canvasHeight.Value;
    //    }
    //    _drawingTree.SetPosition(x, y);
    //}
    public Bitmap? DrawCanvas()
    {
        Bitmap bmp = new(canvasWidth.Value, canvasHeight.Value);
        Graphics g = Graphics.FromImage(bmp);
        _drawingTree?.DrawTree(g);
        return bmp;
    }

}
