namespace FileSystemNotifier_Form
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.startScanning = new System.Windows.Forms.Button();
            this.createdBox = new System.Windows.Forms.CheckBox();
            this.deletedBox = new System.Windows.Forms.CheckBox();
            this.changedBox = new System.Windows.Forms.CheckBox();
            this.renamedBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.selectFolderBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // startScanning
            // 
            this.startScanning.Location = new System.Drawing.Point(109, 214);
            this.startScanning.Name = "startScanning";
            this.startScanning.Size = new System.Drawing.Size(75, 23);
            this.startScanning.TabIndex = 0;
            this.startScanning.Text = "Start ";
            this.startScanning.UseVisualStyleBackColor = true;
            this.startScanning.Click += new System.EventHandler(this.StartScanning_Click);
            // 
            // createdBox
            // 
            this.createdBox.AutoSize = true;
            this.createdBox.Location = new System.Drawing.Point(30, 39);
            this.createdBox.Name = "createdBox";
            this.createdBox.Size = new System.Drawing.Size(63, 17);
            this.createdBox.TabIndex = 1;
            this.createdBox.Text = "Created";
            this.createdBox.UseVisualStyleBackColor = true;
            // 
            // deletedBox
            // 
            this.deletedBox.AutoSize = true;
            this.deletedBox.Location = new System.Drawing.Point(198, 39);
            this.deletedBox.Name = "deletedBox";
            this.deletedBox.Size = new System.Drawing.Size(63, 17);
            this.deletedBox.TabIndex = 2;
            this.deletedBox.Text = "Deleted";
            this.deletedBox.UseVisualStyleBackColor = true;
            // 
            // changedBox
            // 
            this.changedBox.AutoSize = true;
            this.changedBox.Location = new System.Drawing.Point(30, 71);
            this.changedBox.Name = "changedBox";
            this.changedBox.Size = new System.Drawing.Size(69, 17);
            this.changedBox.TabIndex = 3;
            this.changedBox.Text = "Changed";
            this.changedBox.UseVisualStyleBackColor = true;
            // 
            // renamedBox
            // 
            this.renamedBox.AutoSize = true;
            this.renamedBox.Location = new System.Drawing.Point(198, 71);
            this.renamedBox.Name = "renamedBox";
            this.renamedBox.Size = new System.Drawing.Size(72, 17);
            this.renamedBox.TabIndex = 4;
            this.renamedBox.Text = "Renamed";
            this.renamedBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "File system scanner settings:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(234, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Select folder where to store scanning results file:";
            // 
            // selectFolderBtn
            // 
            this.selectFolderBtn.Location = new System.Drawing.Point(99, 134);
            this.selectFolderBtn.Name = "selectFolderBtn";
            this.selectFolderBtn.Size = new System.Drawing.Size(94, 23);
            this.selectFolderBtn.TabIndex = 7;
            this.selectFolderBtn.Text = "Select folder";
            this.selectFolderBtn.UseVisualStyleBackColor = true;
            this.selectFolderBtn.Click += new System.EventHandler(this.selectFolderBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.selectFolderBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.renamedBox);
            this.Controls.Add(this.changedBox);
            this.Controls.Add(this.deletedBox);
            this.Controls.Add(this.createdBox);
            this.Controls.Add(this.startScanning);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "File system notifier";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startScanning;
        private System.Windows.Forms.CheckBox createdBox;
        private System.Windows.Forms.CheckBox deletedBox;
        private System.Windows.Forms.CheckBox changedBox;
        private System.Windows.Forms.CheckBox renamedBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button selectFolderBtn;
    }
}

