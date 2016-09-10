namespace PriceCompareForm
{
    partial class CheapestBasketForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheapestBasketForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle43 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle44 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblEnterItem = new System.Windows.Forms.Label();
            this.lblAmout = new System.Windows.Forms.Label();
            this.txtboxAmount = new System.Windows.Forms.TextBox();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.lblSelectedItems = new System.Windows.Forms.Label();
            this.btnDecreaseAmount = new System.Windows.Forms.Button();
            this.btnIncreaseAmount = new System.Windows.Forms.Button();
            this.btnCheckSuppliersPrices = new System.Windows.Forms.Button();
            this.dgSelectedItems = new System.Windows.Forms.DataGridView();
            this.dgFinalPrices = new System.Windows.Forms.DataGridView();
            this.treeViewPrices = new System.Windows.Forms.TreeView();
            this.lblTreeviewTitle = new System.Windows.Forms.Label();
            this.btnExportToExcel = new System.Windows.Forms.Button();
            this.comboxItem = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgSelectedItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgFinalPrices)).BeginInit();
            this.SuspendLayout();
            // 
            // lblEnterItem
            // 
            this.lblEnterItem.AutoSize = true;
            this.lblEnterItem.Font = new System.Drawing.Font("Arial Narrow", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnterItem.Location = new System.Drawing.Point(837, 29);
            this.lblEnterItem.Name = "lblEnterItem";
            this.lblEnterItem.Size = new System.Drawing.Size(103, 29);
            this.lblEnterItem.TabIndex = 0;
            this.lblEnterItem.Text = ":בחר מוצר";
            // 
            // lblAmout
            // 
            this.lblAmout.AutoSize = true;
            this.lblAmout.Font = new System.Drawing.Font("Arial Narrow", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmout.Location = new System.Drawing.Point(566, 25);
            this.lblAmout.Name = "lblAmout";
            this.lblAmout.Size = new System.Drawing.Size(105, 29);
            this.lblAmout.TabIndex = 2;
            this.lblAmout.Text = ":בחר כמות";
            // 
            // txtboxAmount
            // 
            this.txtboxAmount.BackColor = System.Drawing.Color.White;
            this.txtboxAmount.Font = new System.Drawing.Font("Miriam", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtboxAmount.Location = new System.Drawing.Point(575, 61);
            this.txtboxAmount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtboxAmount.Name = "txtboxAmount";
            this.txtboxAmount.ReadOnly = true;
            this.txtboxAmount.Size = new System.Drawing.Size(34, 26);
            this.txtboxAmount.TabIndex = 3;
            this.txtboxAmount.Text = "1";
            this.txtboxAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnAddItem
            // 
            this.btnAddItem.BackgroundImage = global::PriceCompareForm.Properties.Resources.addToCart;
            this.btnAddItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddItem.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnAddItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddItem.Font = new System.Drawing.Font("Agency FB", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddItem.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnAddItem.Location = new System.Drawing.Point(451, 24);
            this.btnAddItem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnAddItem.Size = new System.Drawing.Size(61, 74);
            this.btnAddItem.TabIndex = 4;
            this.btnAddItem.Text = "+";
            this.btnAddItem.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            this.btnAddItem.MouseEnter += new System.EventHandler(this.btnAddItem_MouseEnter);
            this.btnAddItem.MouseLeave += new System.EventHandler(this.btnAddItem_MouseLeave);
            // 
            // lblSelectedItems
            // 
            this.lblSelectedItems.AutoSize = true;
            this.lblSelectedItems.Font = new System.Drawing.Font("Arial Narrow", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedItems.Location = new System.Drawing.Point(798, 199);
            this.lblSelectedItems.Name = "lblSelectedItems";
            this.lblSelectedItems.Size = new System.Drawing.Size(152, 29);
            this.lblSelectedItems.TabIndex = 6;
            this.lblSelectedItems.Text = ":מוצרים שנבחרו";
            this.lblSelectedItems.Visible = false;
            // 
            // btnDecreaseAmount
            // 
            this.btnDecreaseAmount.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDecreaseAmount.BackgroundImage")));
            this.btnDecreaseAmount.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDecreaseAmount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDecreaseAmount.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnDecreaseAmount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDecreaseAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDecreaseAmount.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnDecreaseAmount.Location = new System.Drawing.Point(529, 49);
            this.btnDecreaseAmount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDecreaseAmount.Name = "btnDecreaseAmount";
            this.btnDecreaseAmount.Size = new System.Drawing.Size(40, 50);
            this.btnDecreaseAmount.TabIndex = 7;
            this.btnDecreaseAmount.UseVisualStyleBackColor = true;
            this.btnDecreaseAmount.Click += new System.EventHandler(this.btnDecreaseAmount_Click);
            this.btnDecreaseAmount.MouseEnter += new System.EventHandler(this.btnDecreaseAmount_MouseEnter);
            this.btnDecreaseAmount.MouseLeave += new System.EventHandler(this.btnDecreaseAmount_MouseLeave);
            // 
            // btnIncreaseAmount
            // 
            this.btnIncreaseAmount.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnIncreaseAmount.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnIncreaseAmount.BackgroundImage")));
            this.btnIncreaseAmount.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnIncreaseAmount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIncreaseAmount.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnIncreaseAmount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIncreaseAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIncreaseAmount.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnIncreaseAmount.Location = new System.Drawing.Point(616, 49);
            this.btnIncreaseAmount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnIncreaseAmount.Name = "btnIncreaseAmount";
            this.btnIncreaseAmount.Size = new System.Drawing.Size(40, 50);
            this.btnIncreaseAmount.TabIndex = 8;
            this.btnIncreaseAmount.UseVisualStyleBackColor = false;
            this.btnIncreaseAmount.Click += new System.EventHandler(this.btnIncreaseAmount_Click);
            this.btnIncreaseAmount.MouseEnter += new System.EventHandler(this.btnIncreaseAmount_MouseEnter);
            this.btnIncreaseAmount.MouseLeave += new System.EventHandler(this.btnIncreaseAmount_MouseLeave);
            // 
            // btnCheckSuppliersPrices
            // 
            this.btnCheckSuppliersPrices.BackgroundImage = global::PriceCompareForm.Properties.Resources.buttonBackground;
            this.btnCheckSuppliersPrices.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCheckSuppliersPrices.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckSuppliersPrices.Location = new System.Drawing.Point(607, 138);
            this.btnCheckSuppliersPrices.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCheckSuppliersPrices.Name = "btnCheckSuppliersPrices";
            this.btnCheckSuppliersPrices.Size = new System.Drawing.Size(143, 45);
            this.btnCheckSuppliersPrices.TabIndex = 9;
            this.btnCheckSuppliersPrices.Text = "חשב מחירים";
            this.btnCheckSuppliersPrices.UseVisualStyleBackColor = true;
            this.btnCheckSuppliersPrices.Visible = false;
            this.btnCheckSuppliersPrices.Click += new System.EventHandler(this.btnCheckSuppliersPrices_Click);
            this.btnCheckSuppliersPrices.MouseEnter += new System.EventHandler(this.btnCheckSuppliersPrices_MouseEnter);
            this.btnCheckSuppliersPrices.MouseLeave += new System.EventHandler(this.btnCheckSuppliersPrices_MouseLeave);
            // 
            // dgSelectedItems
            // 
            this.dgSelectedItems.AllowUserToAddRows = false;
            this.dgSelectedItems.AllowUserToDeleteRows = false;
            this.dgSelectedItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgSelectedItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgSelectedItems.BackgroundColor = System.Drawing.SystemColors.InactiveCaption;
            this.dgSelectedItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgSelectedItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSelectedItems.Location = new System.Drawing.Point(681, 236);
            this.dgSelectedItems.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.dgSelectedItems.MultiSelect = false;
            this.dgSelectedItems.Name = "dgSelectedItems";
            this.dgSelectedItems.ReadOnly = true;
            this.dgSelectedItems.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgSelectedItems.RowHeadersWidth = 5;
            dataGridViewCellStyle43.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            dataGridViewCellStyle43.ForeColor = System.Drawing.Color.Black;
            this.dgSelectedItems.RowsDefaultCellStyle = dataGridViewCellStyle43;
            this.dgSelectedItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgSelectedItems.Size = new System.Drawing.Size(259, 350);
            this.dgSelectedItems.TabIndex = 16;
            this.dgSelectedItems.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgSelectedItems_CellMouseClick);
            // 
            // dgFinalPrices
            // 
            this.dgFinalPrices.AllowUserToAddRows = false;
            this.dgFinalPrices.AllowUserToDeleteRows = false;
            this.dgFinalPrices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgFinalPrices.BackgroundColor = System.Drawing.SystemColors.InactiveCaption;
            this.dgFinalPrices.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgFinalPrices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgFinalPrices.Location = new System.Drawing.Point(370, 236);
            this.dgFinalPrices.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.dgFinalPrices.Name = "dgFinalPrices";
            this.dgFinalPrices.ReadOnly = true;
            this.dgFinalPrices.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgFinalPrices.RowHeadersWidth = 5;
            dataGridViewCellStyle44.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            dataGridViewCellStyle44.ForeColor = System.Drawing.Color.Black;
            this.dgFinalPrices.RowsDefaultCellStyle = dataGridViewCellStyle44;
            this.dgFinalPrices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgFinalPrices.Size = new System.Drawing.Size(256, 211);
            this.dgFinalPrices.TabIndex = 17;
            // 
            // treeViewPrices
            // 
            this.treeViewPrices.Location = new System.Drawing.Point(33, 84);
            this.treeViewPrices.Name = "treeViewPrices";
            this.treeViewPrices.Size = new System.Drawing.Size(301, 491);
            this.treeViewPrices.TabIndex = 20;
            this.treeViewPrices.Visible = false;
            // 
            // lblTreeviewTitle
            // 
            this.lblTreeviewTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTreeviewTitle.Font = new System.Drawing.Font("Arial Narrow", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTreeviewTitle.Location = new System.Drawing.Point(44, 13);
            this.lblTreeviewTitle.Name = "lblTreeviewTitle";
            this.lblTreeviewTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblTreeviewTitle.Size = new System.Drawing.Size(267, 59);
            this.lblTreeviewTitle.TabIndex = 21;
            this.lblTreeviewTitle.Text = "המוצרים הזולים והיקרים ביותר עבור כל ספק:";
            this.lblTreeviewTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTreeviewTitle.Visible = false;
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.BackgroundImage = global::PriceCompareForm.Properties.Resources.buttonBackground;
            this.btnExportToExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportToExcel.Image = global::PriceCompareForm.Properties.Resources.ExcelIcon;
            this.btnExportToExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportToExcel.Location = new System.Drawing.Point(441, 525);
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(128, 50);
            this.btnExportToExcel.TabIndex = 23;
            this.btnExportToExcel.Text = "יצא לאקסל";
            this.btnExportToExcel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportToExcel.UseVisualStyleBackColor = true;
            this.btnExportToExcel.Visible = false;
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            this.btnExportToExcel.MouseEnter += new System.EventHandler(this.btnExportToExcel_MouseEnter);
            this.btnExportToExcel.MouseLeave += new System.EventHandler(this.btnExportToExcel_MouseLeave);
            // 
            // comboxItem
            // 
            this.comboxItem.AllowDrop = true;
            this.comboxItem.BackColor = System.Drawing.Color.White;
            this.comboxItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboxItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboxItem.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboxItem.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboxItem.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.comboxItem.Location = new System.Drawing.Point(699, 61);
            this.comboxItem.Name = "comboxItem";
            this.comboxItem.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.comboxItem.Size = new System.Drawing.Size(251, 30);
            this.comboxItem.Sorted = true;
            this.comboxItem.TabIndex = 1;
            // 
            // CheapestBasketForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1022, 613);
            this.Controls.Add(this.comboxItem);
            this.Controls.Add(this.btnExportToExcel);
            this.Controls.Add(this.lblTreeviewTitle);
            this.Controls.Add(this.treeViewPrices);
            this.Controls.Add(this.dgFinalPrices);
            this.Controls.Add(this.dgSelectedItems);
            this.Controls.Add(this.btnCheckSuppliersPrices);
            this.Controls.Add(this.btnIncreaseAmount);
            this.Controls.Add(this.btnDecreaseAmount);
            this.Controls.Add(this.lblSelectedItems);
            this.Controls.Add(this.btnAddItem);
            this.Controls.Add(this.txtboxAmount);
            this.Controls.Add(this.lblAmout);
            this.Controls.Add(this.lblEnterItem);
            this.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CheapestBasketForm";
            this.RightToLeftLayout = true;
            this.Text = "הסל המוזל";
            ((System.ComponentModel.ISupportInitialize)(this.dgSelectedItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgFinalPrices)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEnterItem;
        private System.Windows.Forms.Label lblAmout;
        private System.Windows.Forms.TextBox txtboxAmount;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.Label lblSelectedItems;
        private System.Windows.Forms.Button btnDecreaseAmount;
        private System.Windows.Forms.Button btnIncreaseAmount;
        private System.Windows.Forms.Button btnCheckSuppliersPrices;
        private System.Windows.Forms.DataGridView dgSelectedItems;
        private System.Windows.Forms.DataGridView dgFinalPrices;
        private System.Windows.Forms.TreeView treeViewPrices;
        private System.Windows.Forms.Label lblTreeviewTitle;
        private System.Windows.Forms.Button btnExportToExcel;
        private System.Windows.Forms.ComboBox comboxItem;
    }
}

