using System.Configuration;
using System.Drawing;
using System.Numerics;
using System.Security.Policy;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BinaryTreeVisualization
{
    public partial class Form1 : Form
    {

        private DrawingTree? drawingTree;
        private CanvasTree? canvasTree;
        private EnumAct currentAct;
        BinaryTree myTree = new BinaryTree();
        
        
        public Form1()
        {
            InitializeComponent();
            drawingTree = new DrawingTree();
            canvasTree = new CanvasTree(drawingTree);
            canvasTree.SetPictureSize(pictureBoxTree.Width, pictureBoxTree.Height);
            drawingTree.SetPosition(pictureBoxTree.Width / 2, 30);
        }
        public void FillTree()
        {
            myTree.Clear();
            Random rnd = new Random();
            int count = Convert.ToInt32(maskedTextBoxInsert.Text);
            for (int i = 0; i < count; i++)
            {
                myTree.Insert(rnd.Next(1, 30));
                
            }

        }
        private async void buttonInsert_Click(object sender, EventArgs e)
        {
            currentAct = EnumAct.Insert;
            if (string.IsNullOrEmpty(maskedTextBoxInsert.Text))
            {
                MessageBox.Show("Введите количество элементов");
                return;
            }
            int count = Convert.ToInt32(maskedTextBoxInsert.Text);
            if (count > 20)
            {
                MessageBox.Show("Слишком много элементов");
                return;
            }
            FillTree();
            pictureBoxTree.Image = canvasTree.DrawCanvas(myTree.root, currentAct);


        }
        
        private async void buttonDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(maskedTextBoxDelete.Text))
            {
                MessageBox.Show("Введите количество элементов");
                return;
            }
            int number = Convert.ToInt32(maskedTextBoxDelete.Text);
            if (myTree.SearchRec(myTree.root, number) == null)
            {
                MessageBox.Show("Элемент не добавлен в дерево");
                return;
            }
            Node root = myTree.root;
            while (root != null)
            {   
                root.isActive = true; 
                
                pictureBoxTree.Image = canvasTree.DrawCanvas(myTree.root, currentAct);
                await Task.Delay(600);
                if (number == root.Value) break; 
                root.isActive = false;
                if (number < root.Value)
                    root = root.Left;
                else
                    root = root.Right; 
            }
            myTree.Delete(number);
            await Task.Delay(400);
            pictureBoxTree.Image = canvasTree.DrawCanvas(myTree.root, currentAct);
        }

        private async void buttonPrint_Click(object sender, EventArgs e)
        {
            
            if (myTree.root == null)
            {
                MessageBox.Show("Дерево не заполнено");
                return;
            }
            Node root = myTree.root;
            await print(root);
            currentAct = EnumAct.Print;
            pictureBoxTree.Image = canvasTree.DrawCanvas(myTree.root, currentAct);

        }
        private async Task print(Node root)
        {
            if(root == null)
            {
                return;
            }
            root.isActive = true;
            pictureBoxTree.Image = canvasTree.DrawCanvas(myTree.root, currentAct);
            await Task.Delay(500);
            root.isActive = false;
            pictureBoxTree.Image = canvasTree.DrawCanvas(myTree.root, currentAct);
            await print(root.Left);
            
            await print(root.Right);

        }
    }
}
