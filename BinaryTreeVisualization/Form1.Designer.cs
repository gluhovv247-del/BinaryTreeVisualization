namespace BinaryTreeVisualization
{
    partial class Form1
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
            maskedTextBoxDelete = new MaskedTextBox();
            pictureBoxTree = new PictureBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxTree).BeginInit();
            SuspendLayout();
            // 
            // buttonInsert
            // 
            buttonInsert.Location = new Point(51, 120);
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
            // 
            // buttonPrint
            // 
            buttonPrint.Location = new Point(51, 285);
            buttonPrint.Name = "buttonPrint";
            buttonPrint.Size = new Size(94, 29);
            buttonPrint.TabIndex = 3;
            buttonPrint.Text = "Вывести";
            buttonPrint.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(maskedTextBoxDelete);
            groupBox1.Controls.Add(buttonPrint);
            groupBox1.Controls.Add(buttonInsert);
            groupBox1.Controls.Add(buttonDelete);
            groupBox1.Location = new Point(612, -1);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(186, 451);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
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
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox1);
            Controls.Add(pictureBoxTree);
            Name = "Form1";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxTree).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox;
        private Button buttonInsert;
        private Button buttonDelete;
        private Button buttonPrint;
        private GroupBox groupBox1;
        private MaskedTextBox maskedTextBoxDelete;
        private PictureBox pictureBoxTree;
    }
}
