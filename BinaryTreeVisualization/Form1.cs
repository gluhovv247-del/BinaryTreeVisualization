using System.Drawing;
using System.Security.Policy;

namespace BinaryTreeVisualization
{
    public partial class Form1 : Form
    {

        private DrawingTree? drawingTree;
        private CanvasTree? canvasTree;
        public Form1()
        {
            InitializeComponent();
            drawingTree = new DrawingTree();
            canvasTree = new CanvasTree(drawingTree);
            canvasTree.SetPictureSize(pictureBoxTree.Width, pictureBoxTree.Height);

        }

        
        private void buttonInsert_Click(object sender, EventArgs e)
        {
            
            pictureBoxTree.Image = canvasTree.DrawCanvas();
        }
        
    }
}
