using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace BinaryTreeVisualization;

public class DrawingTree
{
    private int? _PosX;
    private int? _PosY;
    public DrawingTree()
    {
        _PosX = null;
        _PosY = null;
    }
    public void SetPosition(int x, int y)
    {
        _PosX = x;
        _PosY = y;
    }
    
    public void DrawTree(Graphics g)
    {
        Random rnd = new Random();
        Pen blackPen = new Pen(Color.Black);
        string text = rnd.Next(0, 10).ToString();
        Font drawFont = new Font("Arial", 24, FontStyle.Bold);
        SolidBrush drawBrush = new SolidBrush(Color.Black);
        StringFormat sf = new StringFormat();
        sf.Alignment = StringAlignment.Center;
        sf.LineAlignment = StringAlignment.Center;
        Rectangle rect = new Rectangle(50, 50, 100, 100);
        g.DrawRectangle(blackPen, rect);
        g.DrawString(text, drawFont, drawBrush, rect, sf);
    }
}
