using Microsoft.Extensions.Logging;
using System.Configuration;
using System.Drawing;
using System.Numerics;
using System.Security.Policy;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BinaryTreeVisualization
{
    public partial class FormVisualization : Form
    {
        AlgorithmSettings settings;
        private EnumAct currentAct;
        RunBinaryTree myTree;
        private Canvas _canvas;
        private ILogger<FormVisualization> _logger;
        public FormVisualization(ILogger<FormVisualization> logger)
        {
            InitializeComponent();
            _canvas = new Canvas();
            _canvas.SetPictureSize(pictureBoxTree.Width, pictureBoxTree.Height);
            _canvas.SetTreePosition(pictureBoxTree.Width / 2, 60);
            settings = new AlgorithmSettings(0, "BinaryTree");
            myTree = new RunBinaryTree(settings);
            _logger = logger;
        }
        public void RefreshImage(EnumAct act) => pictureBoxTree.Image = _canvas.DrawCanvas(myTree.root, currentAct);

        public void FillTree(int size)
        {
            try
            {
                Random rnd = new Random();
                settings = new AlgorithmSettings(size, "BinaryTree");
                myTree = new RunBinaryTree(settings);
                settings.Insert();
                _logger.LogInformation("Дерево создано");
            }
            catch (IndexOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message);
                _logger.LogError(ex, "Ошибка при добавлении: " + ex.Message);
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
            int quantity = Convert.ToInt32(maskedTextBoxInsert.Text);
            
            FillTree(quantity);
            myTree.CreateBinaryTree();
            RefreshImage(currentAct);  
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
                RefreshImage(currentAct);
                await Task.Delay(600);
                if (number == root.Value) break;
                root.isActive = false;
                if (number < root.Value)
                    root = root.Left;
                else
                    root = root.Right;
            }
            settings.Values.Remove(number);
            myTree.Delete(number);

            await Task.Delay(400);
            RefreshImage(currentAct);
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
            RefreshImage(currentAct);
            _logger.LogInformation("Осуществлен вывод элементов дерева");
        }
        private async Task print(Node root)
        {
            if (root == null)
            {
                return;
            }
            root.isActive = true;
            RefreshImage(currentAct);
            await Task.Delay(500);
            root.isActive = false;
            RefreshImage(currentAct);
            await print(root.Left);
            await print(root.Right);
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    myTree.SaveToFile(saveFileDialog.FileName);
                    MessageBox.Show("Сохранение прошло успешно",
                        "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _logger.LogInformation("Дерево сохранено в файл: {filename}", saveFileDialog.FileName);
                }
                catch(ArgumentNullException ex)
                {
                    MessageBox.Show(ex.Message);
                    _logger.LogError("Ошибка при сохранении: " + ex.Message);
                }
            }
        }

        private void LoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentAct = EnumAct.Insert;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (settings.Values.Count != 0)
                    {
                        settings.Values.Clear();
                    }
                    myTree.LoadFromFile(openFileDialog.FileName);
                    MessageBox.Show("Загрузка прошла успешно", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    myTree.CreateBinaryTree();
                    RefreshImage(currentAct);
                    _logger.LogInformation("Файл загружен");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    _logger.LogError("Ошибка при загрузке файла" + ex.Message);
                }
            }
        }
        private void buttonInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Бинарное дерево поиска- это древовидная структура данных, в которой элементы, находящиеся в левом поддереве меньше элемента родителя," +
                "а элементы правого поддерева наоборот больше. " + "В этой программе визуализируется удаление и вывод элементов дерева");
        }
    }
}
