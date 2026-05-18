using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO.Packaging;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BinaryTreeVisualization;

public class DrawingTree
{
    private int? _PosX;
    private int? _PosY;
    int currentCount = 0;
    int count = 0;
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
    
    public void DrawInsert(Graphics g, Node root, int x, int y, int offset)
    {
        if (root == null)
        {
            return;
        }
        Pen blackPen = new Pen(Color.Black);
        Brush brush = root.isActive ? Brushes.Red : Brushes.White;
        if (root.Left != null)
        {
            g.DrawLine(blackPen, x, y + 10, x - offset, y + 10);
            g.DrawLine(blackPen, x - offset, y + 10, x - offset, y + 35);
        }
        if (root.Right != null)
        {
            g.DrawLine(blackPen, x, y + 10, x + offset, y + 10);
            g.DrawLine(blackPen, x + offset, y + 10, x + offset, y + 35);
        }
        Rectangle rect = new Rectangle(x - 15, y - 15, 30, 30);
        g.DrawRectangle(blackPen, rect);
        g.FillRectangle(brush, rect);
        string text = root.Value.ToString();
        SolidBrush drawBrush = new SolidBrush(Color.Black);
        Font drawFont = new Font("Arial", 12, FontStyle.Bold);
        StringFormat sf = new StringFormat();
        sf.Alignment = StringAlignment.Center;
        sf.LineAlignment = StringAlignment.Center;
        g.DrawString(text, drawFont, drawBrush, rect, sf);
        DrawInsert(g, root.Left, x - offset + 10, y + 50, offset / 2 + 20);
        DrawInsert(g, root.Right, x + offset, y + 50, offset / 2 + 20);
    }
    public void DrawPrint(Graphics g, Node root, int x, int y)
    {
        if (root == null)
        {
            return;   
        }
        Pen blackPen = new Pen(Color.Black);
       
        string text = root.Value.ToString();
        SolidBrush drawBrush = new SolidBrush(Color.Black);
        Font drawFont = new Font("Arial", 12, FontStyle.Bold);
        StringFormat sf = new StringFormat();
        sf.Alignment = StringAlignment.Center;
        sf.LineAlignment = StringAlignment.Center;
        count = (currentCount * 40);
        Rectangle rect = new Rectangle(count, y + 350, 30, 30);
        g.DrawRectangle(blackPen, rect);
        g.DrawString(text, drawFont, drawBrush, rect, sf);
        currentCount++;
        DrawPrint(g, root.Left, count, y);
        DrawPrint(g, root.Right, count, y);
    }
    public void DrawDelete(int number, Node root)
    {
        while (root != null)
        {
            if (number == root.Value) break;
            root.isActive = false;
            if (number < root.Value)
                root = root.Left;
            else
                root = root.Right;
        }
    }
    public void DrawTree(Graphics g, Node root, EnumAct act, int offset)
    {
        switch (act)
        {
            case EnumAct.Insert:
                DrawInsert(g, root, _PosX.Value, _PosY.Value, offset);
                break;
            case EnumAct.Print:
                DrawInsert(g, root, _PosX.Value, _PosY.Value, offset);
                DrawPrint(g, root, _PosX.Value, _PosY.Value);
                count = 0;
                currentCount = 0;
                break;
        }
    }
}
