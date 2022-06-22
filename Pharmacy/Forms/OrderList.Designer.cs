
namespace Pharmacy
{
    partial class OrderList
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
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Batch_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Production_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Exp_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Manu_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.M_unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qunatity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit_Cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit_Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pur_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pay_Method = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tax_stat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Invoice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Store_Bran = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvOrders
            // 
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Name,
            this.Category,
            this.Batch_No,
            this.Production_Date,
            this.Exp_date,
            this.Manu_Date,
            this.M_unit,
            this.Qunatity,
            this.Unit_Cost,
            this.Unit_Price,
            this.Pur_Date,
            this.Pay_Method,
            this.Tax_stat,
            this.Invoice,
            this.Store_Bran,
            this.Total});
            this.dgvOrders.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvOrders.Location = new System.Drawing.Point(0, 0);
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.RowHeadersWidth = 62;
            this.dgvOrders.RowTemplate.Height = 28;
            this.dgvOrders.Size = new System.Drawing.Size(1924, 506);
            this.dgvOrders.TabIndex = 0;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 8;
            this.ID.Name = "ID";
            this.ID.Width = 150;
            // 
            // Name
            // 
            this.Name.HeaderText = "Name";
            this.Name.MinimumWidth = 8;
            this.Name.Name = "Name";
            this.Name.Width = 150;
            // 
            // Category
            // 
            this.Category.HeaderText = "Category";
            this.Category.MinimumWidth = 8;
            this.Category.Name = "Category";
            this.Category.Width = 150;
            // 
            // Batch_No
            // 
            this.Batch_No.HeaderText = "Batch No";
            this.Batch_No.MinimumWidth = 8;
            this.Batch_No.Name = "Batch_No";
            this.Batch_No.Width = 150;
            // 
            // Production_Date
            // 
            this.Production_Date.HeaderText = "Production Date";
            this.Production_Date.MinimumWidth = 8;
            this.Production_Date.Name = "Production_Date";
            this.Production_Date.Width = 150;
            // 
            // Exp_date
            // 
            this.Exp_date.HeaderText = "Expiry Date";
            this.Exp_date.MinimumWidth = 8;
            this.Exp_date.Name = "Exp_date";
            this.Exp_date.Width = 150;
            // 
            // Manu_Date
            // 
            this.Manu_Date.HeaderText = "Manufacture Date";
            this.Manu_Date.MinimumWidth = 8;
            this.Manu_Date.Name = "Manu_Date";
            this.Manu_Date.Width = 150;
            // 
            // M_unit
            // 
            this.M_unit.HeaderText = "Measurement Unit";
            this.M_unit.MinimumWidth = 8;
            this.M_unit.Name = "M_unit";
            this.M_unit.Width = 150;
            // 
            // Qunatity
            // 
            this.Qunatity.HeaderText = "Qantity";
            this.Qunatity.MinimumWidth = 8;
            this.Qunatity.Name = "Qunatity";
            this.Qunatity.Width = 150;
            // 
            // Unit_Cost
            // 
            this.Unit_Cost.HeaderText = "Unit Cost";
            this.Unit_Cost.MinimumWidth = 8;
            this.Unit_Cost.Name = "Unit_Cost";
            this.Unit_Cost.Width = 150;
            // 
            // Unit_Price
            // 
            this.Unit_Price.HeaderText = "Unit Price";
            this.Unit_Price.MinimumWidth = 8;
            this.Unit_Price.Name = "Unit_Price";
            this.Unit_Price.Width = 150;
            // 
            // Pur_Date
            // 
            this.Pur_Date.HeaderText = "Purchase_Date";
            this.Pur_Date.MinimumWidth = 8;
            this.Pur_Date.Name = "Pur_Date";
            this.Pur_Date.Width = 150;
            // 
            // Pay_Method
            // 
            this.Pay_Method.HeaderText = "Payment Method";
            this.Pay_Method.MinimumWidth = 8;
            this.Pay_Method.Name = "Pay_Method";
            this.Pay_Method.Width = 150;
            // 
            // Tax_stat
            // 
            this.Tax_stat.HeaderText = "Tax Status";
            this.Tax_stat.MinimumWidth = 8;
            this.Tax_stat.Name = "Tax_stat";
            this.Tax_stat.Width = 150;
            // 
            // Invoice
            // 
            this.Invoice.HeaderText = "Invoice";
            this.Invoice.MinimumWidth = 8;
            this.Invoice.Name = "Invoice";
            this.Invoice.Width = 150;
            // 
            // Store_Bran
            // 
            this.Store_Bran.HeaderText = "Store Branch";
            this.Store_Bran.MinimumWidth = 8;
            this.Store_Bran.Name = "Store_Bran";
            this.Store_Bran.Width = 150;
            // 
            // Total
            // 
            this.Total.HeaderText = "Total";
            this.Total.MinimumWidth = 8;
            this.Total.Name = "Total";
            this.Total.Width = 150;
            // 
            // OrderList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 716);
            this.Controls.Add(this.dgvOrders);
            //this.Name = "OrderList";
            this.Text = "OrderList";
            this.Load += new System.EventHandler(this.OrderList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
        private System.Windows.Forms.DataGridViewTextBoxColumn Batch_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Production_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Exp_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Manu_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn M_unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qunatity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit_Cost;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit_Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pur_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pay_Method;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tax_stat;
        private System.Windows.Forms.DataGridViewTextBoxColumn Invoice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Store_Bran;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        public System.Windows.Forms.DataGridView dgvOrders;
    }
}