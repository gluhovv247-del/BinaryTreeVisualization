using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTreeVisualization;

public class StepAnimator
{
    private Action refresh;
    public StepAnimator(Action refreshMethod)
    {
        refresh = refreshMethod;
    }
    public async Task Delete(Node root, int number)
    {
        while (root != null)
        {
            root.isActive = true;
            refresh();
            await Task.Delay(600);
            if (number == root.Value)
            {
                await BlinkNode(root);
                root.isActive = false;
                break;
            }    
            root.isActive = false;
            if (number < root.Value)
                root = root.Left;
            else
                root = root.Right;
        }
    }
    public async Task BlinkNode(Node root)
    {
        for (int i = 0; i < 6; i++)
        {
            root.isActive = !root.isActive;

            refresh();

            await Task.Delay(300);
        }

        root.isActive = true ;
        refresh();

    }
    public async Task Print(Node root)
    {
        if (root == null)
        {
            return;
        }
        root.isActive = true;
        refresh();
        await Task.Delay(500);
        root.isActive = false;
        refresh();
        await Print(root.Left);
        await Print(root.Right);
    }
}
