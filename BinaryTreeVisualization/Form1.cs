using System.Drawing;
using System.Security.Policy;

namespace BinaryTreeVisualization
{
    public partial class Form1 : Form
    {

        private DrawingTree? drawingTree;
        private CanvasTree? canvasTree;
        BinaryTree myTree = new BinaryTree();


        public Form1()
        {
            InitializeComponent();
            drawingTree = new DrawingTree();
            canvasTree = new CanvasTree(drawingTree);
            canvasTree.SetPictureSize(pictureBoxTree.Width, pictureBoxTree.Height);
            drawingTree.SetPosition(pictureBoxTree.Width/2, 30, 3);
        }
        public void FillTree()
        {
            myTree.Clear();
            Random rnd = new Random();
            int count = Convert.ToInt32(maskedTextBoxInsert.Text);
            for(int i =0; i<count; i++)
            {
                myTree.Insert(rnd.Next(1, 30));
            }
        }
        private void buttonInsert_Click(object sender, EventArgs e)
        { 
            if (string.IsNullOrEmpty(maskedTextBoxInsert.Text)){
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

            pictureBoxTree.Image = canvasTree.DrawCanvas(myTree.root);
        }

        
    }
}
