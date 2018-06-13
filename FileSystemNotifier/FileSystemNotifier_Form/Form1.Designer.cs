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
            this.components = new System.ComponentModel.Container();
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
            this.scanResultsGridView = new System.Windows.Forms.DataGridView();
            this.pathDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.changeTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scanResultViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.scanResultsGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scanResultViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // startScanning
            // 
            this.startScanning.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startScanning.Location = new System.Drawing.Point(296, 412);
            this.startScanning.Name = "startScanning";
            this.startScanning.Size = new System.Drawing.Size(75, 32);
            this.startScanning.TabIndex = 0;
            this.startScanning.Text = "Start ";
            this.startScanning.UseVisualStyleBackColor = true;
            this.startScanning.Click += new System.EventHandler(this.StartScanning_Click);
            // 
            // createdBox
            // 
            this.createdBox.AutoSize = true;
            this.createdBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createdBox.Location = new System.Drawing.Point(30, 39);
            this.createdBox.Name = "createdBox";
            this.createdBox.Size = new System.Drawing.Size(95, 28);
            this.createdBox.TabIndex = 1;
            this.createdBox.Text = "Created";
            this.createdBox.UseVisualStyleBackColor = true;
            // 
            // deletedBox
            // 
            this.deletedBox.AutoSize = true;
            this.deletedBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deletedBox.Location = new System.Drawing.Point(541, 39);
            this.deletedBox.Name = "deletedBox";
            this.deletedBox.Size = new System.Drawing.Size(94, 28);
            this.deletedBox.TabIndex = 2;
            this.deletedBox.Text = "Deleted";
            this.deletedBox.UseVisualStyleBackColor = true;
            // 
            // changedBox
            // 
            this.changedBox.AutoSize = true;
            this.changedBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.changedBox.Location = new System.Drawing.Point(30, 71);
            this.changedBox.Name = "changedBox";
            this.changedBox.Size = new System.Drawing.Size(107, 28);
            this.changedBox.TabIndex = 3;
            this.changedBox.Text = "Changed";
            this.changedBox.UseVisualStyleBackColor = true;
            // 
            // renamedBox
            // 
            this.renamedBox.AutoSize = true;
            this.renamedBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.renamedBox.Location = new System.Drawing.Point(541, 71);
            this.renamedBox.Name = "renamedBox";
            this.renamedBox.Size = new System.Drawing.Size(112, 28);
            this.renamedBox.TabIndex = 4;
            this.renamedBox.Text = "Renamed";
            this.renamedBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(217, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "File system scanner settings:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(142, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(412, 24);
            this.label2.TabIndex = 6;
            this.label2.Text = "Select folder where to store scanning results file:";
            // 
            // selectFolderBtn
            // 
            this.selectFolderBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectFolderBtn.Location = new System.Drawing.Point(296, 143);
            this.selectFolderBtn.Name = "selectFolderBtn";
            this.selectFolderBtn.Size = new System.Drawing.Size(94, 32);
            this.selectFolderBtn.TabIndex = 7;
            this.selectFolderBtn.Text = "Select folder";
            this.selectFolderBtn.UseVisualStyleBackColor = true;
            this.selectFolderBtn.Click += new System.EventHandler(this.selectFolderBtn_Click);
            // 
            // scanResultsGridView
            // 
            this.scanResultsGridView.AllowUserToAddRows = false;
            this.scanResultsGridView.AllowUserToDeleteRows = false;
            this.scanResultsGridView.AutoGenerateColumns = false;
            this.scanResultsGridView.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.scanResultsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.scanResultsGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pathDataGridViewTextBoxColumn,
            this.changeTypeDataGridViewTextBoxColumn,
            this.dateDataGridViewTextBoxColumn});
            this.scanResultsGridView.DataSource = this.scanResultViewModelBindingSource;
            this.scanResultsGridView.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.scanResultsGridView.Location = new System.Drawing.Point(68, 181);
            this.scanResultsGridView.Name = "scanResultsGridView";
            this.scanResultsGridView.ReadOnly = true;
            this.scanResultsGridView.Size = new System.Drawing.Size(546, 225);
            this.scanResultsGridView.TabIndex = 8;
            // 
            // pathDataGridViewTextBoxColumn
            // 
            this.pathDataGridViewTextBoxColumn.DataPropertyName = "Path";
            this.pathDataGridViewTextBoxColumn.HeaderText = "Path";
            this.pathDataGridViewTextBoxColumn.Name = "pathDataGridViewTextBoxColumn";
            this.pathDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // changeTypeDataGridViewTextBoxColumn
            // 
            this.changeTypeDataGridViewTextBoxColumn.DataPropertyName = "ChangeType";
            this.changeTypeDataGridViewTextBoxColumn.HeaderText = "ChangeType";
            this.changeTypeDataGridViewTextBoxColumn.Name = "changeTypeDataGridViewTextBoxColumn";
            this.changeTypeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dateDataGridViewTextBoxColumn
            // 
            this.dateDataGridViewTextBoxColumn.DataPropertyName = "Date";
            this.dateDataGridViewTextBoxColumn.HeaderText = "Date";
            this.dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
            this.dateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // scanResultViewModelBindingSource
            // 
            this.scanResultViewModelBindingSource.DataSource = typeof(FileSystemNotifier_Lib.Models.ScanResultViewModel);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(673, 456);
            this.Controls.Add(this.scanResultsGridView);
            this.Controls.Add(this.selectFolderBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.renamedBox);
            this.Controls.Add(this.changedBox);
            this.Controls.Add(this.deletedBox);
            this.Controls.Add(this.createdBox);
            this.Controls.Add(this.startScanning);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(689, 495);
            this.MinimumSize = new System.Drawing.Size(689, 495);
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "File system scanner";
            ((System.ComponentModel.ISupportInitialize)(this.scanResultsGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scanResultViewModelBindingSource)).EndInit();
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
        private System.Windows.Forms.DataGridView scanResultsGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn pathDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn changeTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource scanResultViewModelBindingSource;
    }
}

