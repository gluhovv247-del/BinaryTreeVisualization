using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace BinaryTreeVisualization;

public class DrawingTree
{
    protected int? _PosX;
    protected int? _PosY;
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
    public void DrawPrint(Graphics g, Node root, int x, int y)
    {
        if (root == null)
        {
            return;
        }
        Pen blackPen = new Pen(Color.Black);
        Rectangle rect = new Rectangle(x, y + 200, 30, 30);
        string text = root.Value.ToString();
        SolidBrush drawBrush = new SolidBrush(Color.Black);
        Font drawFont = new Font("Arial", 12, FontStyle.Bold);
        StringFormat sf = new StringFormat();
        sf.Alignment = StringAlignment.Center;
        sf.LineAlignment = StringAlignment.Center;

        DrawPrint(g, root.Left, x + 30, y);
        DrawPrint(g, root.Right, x + 30, y);
        g.DrawEllipse(blackPen, x, y + 200, 30, 30);
        g.DrawString(text, drawFont, drawBrush, rect, sf);
    }
    public void DrawInsert(Graphics g, Node root, int x, int y, int offset)
    {
        Random rnd = new Random();
        Pen blackPen = new Pen(Color.Black);
        if (root == null)
        {
            return;
        }
        if (root.Left != null)
        {
            g.DrawLine(blackPen, x, y+15, x - offset, y + 35);
        }
        if (root.Right != null)
        {
            g.DrawLine(blackPen, x, y+15, x + offset, y + 35);
        }
        Rectangle rect = new Rectangle(x-15, y-15, 30, 30);
        g.DrawEllipse(blackPen, x - 15, y - 15, 30, 30);
        string text = root.Value.ToString();
        SolidBrush drawBrush = new SolidBrush(Color.Black);
        Font drawFont = new Font("Arial", 12, FontStyle.Bold);
        StringFormat sf = new StringFormat();
        sf.Alignment = StringAlignment.Center;
        sf.LineAlignment = StringAlignment.Center;
        g.DrawString(text, drawFont, drawBrush, rect, sf);
        DrawInsert(g, root.Left, x - offset, y+50, offset);
        DrawInsert(g, root.Right, x+offset, y+50, offset);
    }
    public void DrawTree(Graphics g, Node root, EnumAct act)
    {
        switch (act)
        {
            case EnumAct.Insert:
                DrawInsert(g, root, _PosX.Value, _PosY.Value, 40);
                break;
            case EnumAct.Print:
                DrawInsert(g, root, _PosX.Value, _PosY.Value, 40);
                DrawPrint(g, root, _PosX.Value, _PosY.Value);
                break;
        }
        
    }
}
