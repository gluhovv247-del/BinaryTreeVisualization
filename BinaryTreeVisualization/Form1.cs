using System.Configuration;
using System.Drawing;
using System.Numerics;
using System.Security.Policy;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BinaryTreeVisualization
{
    public partial class Form1 : Form
    {

        private DrawingTree? drawingTree;
        AlgorithmSettings settings;
        private EnumAct currentAct;
        RunBinaryTree myTree;
        public Form1()
        {
            InitializeComponent();
            drawingTree = new DrawingTree();
            drawingTree.SetPictureSize(pictureBoxTree.Width, pictureBoxTree.Height);
            drawingTree.SetPosition(pictureBoxTree.Width / 2, 60);
            settings = new AlgorithmSettings(0, "BinaryTree");
            myTree = new RunBinaryTree(settings);
        }
        public void FillTree()
        {
            Random rnd = new Random();
            int size = Convert.ToInt32(maskedTextBoxInsert.Text);
            CreateTree(size);
            for (int i = 0; i < size; i++)
            {
                settings.Values.Add(rnd.Next(1, 30));
            }
        }
        public void CreateTree(int size)
        {
            settings = new AlgorithmSettings(size, "BinaryTree");
            myTree = new RunBinaryTree(settings);
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
            myTree.CreateBinaryTree();
            pictureBoxTree.Image = drawingTree?.DrawCanvas(myTree.root, currentAct);

        }
        private async void buttonDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(maskedTextBoxDelete.Text))
            {
                MessageBox.Show("Введите количество элементов");
                return;
            }
            int number = Convert.ToInt32(maskedTextBoxDelete.Text);
            if (!settings.Values.Contains(number))
            {
                MessageBox.Show("Такого элемента нет");
                return;
            }
            Node root = myTree.root;
            while (root != null)
            {
                root.isActive = true;
                pictureBoxTree.Image = drawingTree.DrawCanvas(myTree.root, currentAct);
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
            pictureBoxTree.Image = drawingTree.DrawCanvas(myTree.root, currentAct);
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
            pictureBoxTree.Image = drawingTree.DrawCanvas(myTree.root, currentAct);
        }
        private async Task print(Node root)
        {
            if (root == null)
            {
                return;
            }
            root.isActive = true;
            pictureBoxTree.Image = drawingTree.DrawCanvas(myTree.root, currentAct);
            await Task.Delay(500);
            root.isActive = false;
            pictureBoxTree.Image = drawingTree.DrawCanvas(myTree.root, currentAct);
            await print(root.Left);
            await print(root.Right);
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                myTree.SaveToFile(saveFileDialog.FileName);
                MessageBox.Show("Сохранение прошло успешно",
                    "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void LoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentAct = EnumAct.Insert;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if(settings.Values.Count != 0)
                {
                    settings.Values.Clear();
                }
                myTree.LoadFromFile(openFileDialog.FileName);
                MessageBox.Show("Загрузка прошла успешно", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
                myTree.CreateBinaryTree();
                pictureBoxTree.Image = drawingTree?.DrawCanvas(myTree.root, currentAct);
            }
        }
    }
}
