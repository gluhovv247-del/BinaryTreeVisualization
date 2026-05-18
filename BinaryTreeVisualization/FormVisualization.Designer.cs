namespace BinaryTreeVisualization
{
    partial class FormVisualization
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            buttonInsert = new Button();
            buttonDelete = new Button();
            buttonPrint = new Button();
            groupBox1 = new GroupBox();
            buttonInfo = new Button();
            maskedTextBoxInsert = new MaskedTextBox();
            maskedTextBoxDelete = new MaskedTextBox();
            pictureBoxTree = new PictureBox();
            openFileDialog = new OpenFileDialog();
            saveFileDialog = new SaveFileDialog();
            menuStrip1 = new MenuStrip();
            FileToolStripMenuItem = new ToolStripMenuItem();
            SaveToolStripMenuItem = new ToolStripMenuItem();
            LoadToolStripMenuItem = new ToolStripMenuItem();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxTree).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // buttonInsert
            // 
            buttonInsert.Location = new Point(51, 95);
            buttonInsert.Name = "buttonInsert";
            buttonInsert.Size = new Size(90, 29);
            buttonInsert.TabIndex = 1;
            buttonInsert.Text = "Вставить";
            buttonInsert.UseVisualStyleBackColor = true;
            buttonInsert.Click += buttonInsert_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(51, 186);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(94, 29);
            buttonDelete.TabIndex = 2;
            buttonDelete.Text = "Удалить";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // buttonPrint
            // 
            buttonPrint.Location = new Point(51, 285);
            buttonPrint.Name = "buttonPrint";
            buttonPrint.Size = new Size(94, 29);
            buttonPrint.TabIndex = 3;
            buttonPrint.Text = "Вывести";
            buttonPrint.UseVisualStyleBackColor = true;
            buttonPrint.Click += buttonPrint_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(buttonInfo);
            groupBox1.Controls.Add(maskedTextBoxInsert);
            groupBox1.Controls.Add(maskedTextBoxDelete);
            groupBox1.Controls.Add(buttonPrint);
            groupBox1.Controls.Add(buttonInsert);
            groupBox1.Controls.Add(buttonDelete);
            groupBox1.Location = new Point(612, -1);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(186, 451);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Инструменты";
            // 
            // buttonInfo
            // 
            buttonInfo.Location = new Point(51, 343);
            buttonInfo.Name = "buttonInfo";
            buttonInfo.Size = new Size(110, 29);
            buttonInfo.TabIndex = 11;
            buttonInfo.Text = "Информация";
            buttonInfo.UseVisualStyleBackColor = true;
            buttonInfo.Click += buttonInfo_Click;
            // 
            // maskedTextBoxInsert
            // 
            maskedTextBoxInsert.Location = new Point(36, 141);
            maskedTextBoxInsert.Name = "maskedTextBoxInsert";
            maskedTextBoxInsert.Size = new Size(125, 27);
            maskedTextBoxInsert.TabIndex = 10;
            // 
            // maskedTextBoxDelete
            // 
            maskedTextBoxDelete.Location = new Point(36, 231);
            maskedTextBoxDelete.Name = "maskedTextBoxDelete";
            maskedTextBoxDelete.Size = new Size(125, 27);
            maskedTextBoxDelete.TabIndex = 9;
            // 
            // pictureBoxTree
            // 
            pictureBoxTree.Location = new Point(0, -1);
            pictureBoxTree.Name = "pictureBoxTree";
            pictureBoxTree.Size = new Size(606, 451);
            pictureBoxTree.TabIndex = 6;
            pictureBoxTree.TabStop = false;
            // 
            // openFileDialog
            // 
            openFileDialog.FileName = "openFileDialog1";
            openFileDialog.Filter = "txt file |*.txt";
            // 
            // saveFileDialog
            // 
            saveFileDialog.Filter = "txt file |*.txt";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { FileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 28);
            menuStrip1.TabIndex = 7;
            menuStrip1.Text = "menuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            FileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { SaveToolStripMenuItem, LoadToolStripMenuItem });
            FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            FileToolStripMenuItem.Size = new Size(59, 24);
            FileToolStripMenuItem.Text = "Файл";
            // 
            // SaveToolStripMenuItem
            // 
            SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
            SaveToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            SaveToolStripMenuItem.Size = new Size(216, 26);
            SaveToolStripMenuItem.Text = "Сохранить";
            SaveToolStripMenuItem.Click += SaveToolStripMenuItem_Click;
            // 
            // LoadToolStripMenuItem
            // 
            LoadToolStripMenuItem.Name = "LoadToolStripMenuItem";
            LoadToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.L;
            LoadToolStripMenuItem.Size = new Size(216, 26);
            LoadToolStripMenuItem.Text = "Загрузить";
            LoadToolStripMenuItem.Click += LoadToolStripMenuItem_Click;
            // 
            // FormVisualization
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox1);
            Controls.Add(menuStrip1);
            Controls.Add(pictureBoxTree);
            Name = "FormVisualization";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxTree).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox;
        private Button buttonInsert;
        private Button buttonDelete;
        private Button buttonPrint;
        private GroupBox groupBox1;
        private MaskedTextBox maskedTextBoxDelete;
        private PictureBox pictureBoxTree;
        private MaskedTextBox maskedTextBoxInsert;
        private OpenFileDialog openFileDialog;
        private SaveFileDialog saveFileDialog;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem FileToolStripMenuItem;
        private ToolStripMenuItem SaveToolStripMenuItem;
        private ToolStripMenuItem LoadToolStripMenuItem;
        private Button buttonInfo;
    }
}
