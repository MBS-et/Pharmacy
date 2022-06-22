
using iTextSharp.text;
using iTextSharp.text.pdf;
using Pharmacy.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Font = System.Drawing.Font;

namespace Pharmacy
{
    public partial class Form1 : Form
    {
        private bool isCollapsed;
        Panel pnl;
        Button btn;
        string Date;
        string Access = "";
        static int CatAction=0;
        int click = 0;
        int userId=0;
        int quantityLimit = 0;
        public Point mouseLocation;
        
        public Form1(int i)
        {
            InitializeComponent();
            userId=i;
            getAcc(i);

        }
        private void playaudio() 
        {
            SoundPlayer audio = new SoundPlayer(Properties.Resources.NotificationSound);
            audio.Play();
        }
        public void getAcc(int i)
        {
            Database_Connection_Classes.getAccess acc = new Database_Connection_Classes.getAccess();
            Access=acc.GetUserAccess(i);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            submenu();
        }
        private void button6_Click_1(object sender, EventArgs e)
        {
            timer1.Start();

        }
        //----------------------------------------SUPPLY------------------------------------------------
        private void btnSupplySalesDetails_Click(object sender, EventArgs e)
        {
            MainTab.SelectTab(11);
            StatusPic.Image = Resources.supplier;
            lblStatus.Text = "Supply";
        }
        private void btnSupplierLedger_Click(object sender, EventArgs e)
        {
            MainTab.SelectTab(10);
            StatusPic.Image = Resources.supplier;
            lblStatus.Text = "Supply";
        }
        private void btnManageSupplier_Click(object sender, EventArgs e)
        {
            MainTab.SelectTab(9);
            StatusPic.Image = Resources.supplier;
            lblStatus.Text = "Supply";
        }
        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            MainTab.SelectTab(8);
            StatusPic.Image = Resources.supplier;
            lblStatus.Text = "Supply";
            Supplier supplier = new Supplier();
            txtSupplierId.Text = supplier.getSupplierId().ToString();
            dvgSupplier.DataSource = supplier.getAllSuppliers();
        }
        private void btnSupply_Click(object sender, EventArgs e)
        {
            if (click == 0)
            {
                timer1.Start();
                btn = btnSupply;
                pnl = pnlSupply;
                click++;
            }
            else
            {
                isCollapsed = false;
                timer1.Start();
                click--;
            }
        }
        //----------------------------------------SUPPLY-----------------------------------------------
        void submenu()
        {
            if (isCollapsed)
            {
                
                
                    btn.Image = Resources.collapse_1_1_30x30;
                    pnl.Height += 10;
                    if (pnl.Size == pnl.MaximumSize)
                    {
                        timer1.Stop();
                        isCollapsed = false;

                    }
                
            }
            else
            {
                
                
                    btn.Image = Resources.expand_1_1_30x30;
                    pnl.Height -= 10;
                    if (pnl.Size == pnl.MinimumSize)
                    {
                        timer1.Stop();
                        isCollapsed = true;
                    }
                
                
                
            }
        }
        //----------------------------------------MEDICINE------------------------------------------------
        GetStoreDrugsDB obj = new GetStoreDrugsDB();
        private void btnMedicine_Click(object sender, EventArgs e)
        {
            
            dgvDrugStore.DataSource=obj.getStoreDrug();
            cbDrugCategory.Items.Clear();
            for (int i = 0; i < getcat.getCategories().Rows.Count; i++)
            {
                cbDrugCategory.Items.Add(getcat.getCategories().Rows[i]["CategoryName"]);
            }
            if (click == 0)
            {
                timer1.Start();
                btn = btnMedicine;
                pnl = pnlMed;
                click++;
            }
            else
            {
                isCollapsed = false;
                timer1.Start();
                click--;
            }
        }
        private void btnAddMed_Click(object sender, EventArgs e)
        {
            MainTab.SelectTab(4);
            StatusPic.Image = Resources.medicine;
            lblStatus.Text = "Medicine";
        }
        private void btnManageMed_Click(object sender, EventArgs e)
        {
            MainTab.SelectTab(3);
            StatusPic.Image = Resources.medicine;
            lblStatus.Text = "Medicine";
        }
        private void btnViewMed_Click(object sender, EventArgs e)
        {
            MainTab.SelectTab(5);
            StatusPic.Image = Resources.medicine;
            lblStatus.Text = "Medicine";
        }
        private void btnAddtoDispensery_Click(object sender, EventArgs e)
        {
            MainTab.SelectTab(6);
            StatusPic.Image = Resources.medicine;
            Dispensery D = new Dispensery();
            dgvDispenseyDrug.DataSource = D.getDispenseryMed();
            lblStatus.Text = "Medicine";
        }
        private void btnViewMedInDispensery_Click(object sender, EventArgs e)
        {
            MainTab.SelectTab(7);
            StatusPic.Image = Resources.medicine;
            lblStatus.Text = "Medicine";
        }
        //----------------------------------------MEDICINE------------------------------------------------

        //----------------------------------------REPORT------------------------------------------------
        private void btnSalesReport_Click(object sender, EventArgs e)
        {

         
            MainTab.SelectTab(18);
            StatusPic.Image = Resources.document;
            lblStatus.Text = "Report";
            dvgSalesReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void btnProfitLoss_Click(object sender, EventArgs e)
        {
            StatusPic.Image = Resources.document;
            lblStatus.Text = "Report";
        }
        private void btnTodayReport_Click(object sender, EventArgs e)
        {
            
            TodayReport t = new TodayReport();
            dgvtoday.DataSource = t.getReport();
            MainTab.SelectTab(19);
            StatusPic.Image = Resources.document;
            lblStatus.Text = "Report";
        }
        private void btnPurchaseReport_Click(object sender, EventArgs e)
        {
            MainTab.SelectTab(20);
            StatusPic.Image = Resources.document;
            lblStatus.Text = "Report";
        }
        private void btnReport_Click(object sender, EventArgs e)
        {
            if (click == 0)
            {
                timer1.Start();
                btn = btnReport;
                pnl = pnlReport;
                click++;
            }
            else
            {
                isCollapsed = false;
                timer1.Start();
                click--;
            }
        }
        //----------------------------------------REPORT------------------------------------------------

        //----------------------------------------EMPLOYEE------------------------------------------------
        private void btnEmployee_Click(object sender, EventArgs e)
        {
            if (click == 0)
            {
                timer1.Start();
                btn = btnEmployee;
                pnl = pnlEmployee;
                click++;
            }
            else
            {
                isCollapsed = false;
                timer1.Start();
                click--;
            }
            try
            {
                String cn = ConfigurationManager.ConnectionStrings["PharmacyDB"].ToString();
                SqlConnection conn = new SqlConnection(cn);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand("sp_rolename", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds);
                cbEmployeeRole.DataSource = ds.Tables[0];
                cbEmployeeRole.DisplayMember = "RoleName";
                cbEmployeeRole.ValueMember = "RoleID";

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);

            }

        }
        private void btnAddEmp_Click(object sender, EventArgs e)
        {
            MainTab.SelectTab(15);
            EMPLOYEELAYER2 emp = new EMPLOYEELAYER2();
            dgvEmployee.DataSource = emp.fetchemployeeinfo();
            txtEmployeeId.Text = emp.getEmployeeeId();
        }
        private void btnViewEmp_Click(object sender, EventArgs e)
        {
            MainTab.SelectTab(16);
        }
        private void btnManageEmp_Click(object sender, EventArgs e)
        {
            MainTab.SelectTab(17);
        }
        //----------------------------------------EMPLOYEE------------------------------------------------

        //----------------------------------------PATIENT------------------------------------------------
        private void btnPatient_Click(object sender, EventArgs e)
        {
            Patients2ndLayer P2L = new Patients2ndLayer();
            dgvPatient.DataSource = P2L.FetchPatients();
            txtPatientID.Text = P2L.FetchNextPatientsID();  
            if (click == 0)
            {
                timer1.Start();
                btn = btnPatient;
                pnl = pnlPatient;
                click++;
            }
            else
            {
                isCollapsed = false;
                timer1.Start();
                click--;
            }
        }
        private void btnAddPatients_Click(object sender, EventArgs e)
        {
            MainTab.SelectTab(12);
        }
        private void btnViewPatient_Click(object sender, EventArgs e)
        {
            MainTab.SelectTab(13);
        }
        private void btnManagePatient_Click(object sender, EventArgs e)
        {
            MainTab.SelectTab(14);
        }
        //----------------------------------------PATIENT------------------------------------------------

        //----------------------------------------CATEGORY------------------------------------------------
        private void btnMedCat_Click(object sender, EventArgs e)
        {
            txtCatSearch.Text = cat.getCategoryId().ToString();
            if (click == 0)
            {
                timer1.Start();
                btn = btnMedCat;
                pnl = pnlCategory;
                click++;
            }
            else
            {
                isCollapsed = false;
                timer1.Start();
                click--;
            }
        }
        private void btnAddCat_Click(object sender, EventArgs e)
        {
            Category cat = new Category();
            StatusPic.Image = Resources.menu;
            lblStatus.Text = "Category";
            dvgCategory.DataSource = cat.getAllCategory();
            txtCategoryID.Text = cat.getCategoryId().ToString();
            MainTab.SelectTab(0);
        }
        private void btnViewCat_Click(object sender, EventArgs e)
        {
            StatusPic.Image = Resources.menu;
            lblStatus.Text = "Category";
            MainTab.SelectTab(1);
        }
        private void btnManageCat_Click(object sender, EventArgs e)
        {
            StatusPic.Image = Resources.menu;
            lblStatus.Text = "Category";
            MainTab.SelectTab(2);
        }
        //----------------------------------------CATEGORY------------------------------------------------
       
        private void Form1_Load(object sender, EventArgs e)
        {
            ChangeUserInfo ch = new ChangeUserInfo();
            DataRow row = ch.getEmpInfo(userId).Rows[0];
            lblUser.Text = row["A"].ToString();
            MainTab.SelectTab(24);
            if (Access=="2")//Cashier
            {
                pnlCategory.Visible = false;    
                pnlEmployee.Visible= false;
                pnlMed.Visible = false;
                pnlSupply.Visible = false;  
                pnlPurchase.Visible= false;
                pnlReport.Visible = false;
                btnBackUp.Visible=false;
                pnlPatient.Visible=false;
                btnDashboard.Visible = false;
                MainTab.SelectTab(21);
                btnSale.PerformClick();
                lblRole.Text = "Cashier";
                // btnSale.Visible=false;
            }else if (Access == "4")//Supply Manager
            {
                pnlCategory.Visible = false;
                pnlEmployee.Visible = false;
                pnlMed.Visible = false;
                //pnlSupply.Visible = false;
                //pnlPurchase.Visible = false;
                pnlReport.Visible = false;
                btnBackUp.Visible = false;
                pnlPatient.Visible = false;
                btnSale.Visible = false;
                lblRole.Text = "Supply Manager";
            }
            else if (Access == "5")//Stock Controller
            {
                pnlCategory.Visible = false;
                pnlEmployee.Visible = false;
               // pnlMed.Visible = false;
                pnlSupply.Visible = false;
                pnlPurchase.Visible = false;
                pnlReport.Visible = false;
                btnBackUp.Visible = false;
                pnlPatient.Visible = false;
                btnSale.Visible = false;
                lblRole.Text = "Stock Controller";
            }
            else
            {
                lblRole.Text = "Manager";
            }
            updateDashBoard();
            styleDataGridView(dgvSalesReport);
            styleDataGridView(dgvTodayReport);
            styleDataGridView2(dgvDashboard);
            styleDataGridView(dgvPurchaseReport2);
            styleDataGridView2(dvgSalesReport);
            styleDataGridView(dgvTodayReport);
            styleDataGridView(dgvtoday);
            styleDataGridView3_2(dgvViewOrders);
            styleDataGridView4(dgvSuggestion);
            styleDataGridView(dvgSalesReport);
            styleDataGridView3(dvgSupplier);
            styleDataGridView3(dvgCategory);
            styleDataGridView3(dgvPatient);
            styleDataGridView2(dgvDispenseyDrug);
            styleDataGridView3_2(dgvEmployee);
            styleDataGridView3(dgvViewOrders);
            styleDataGridView3(dgvDrugStore);
            styleDataGridView(dgvTodayReport);
            styleDataGridView2(dgvSales);

            createTable();
            btnPurchase.PerformClick();
            btnPurchase.PerformClick();
            
        }
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            MainTab.SelectTab(24);
            isCollapsed = false;
            timer1.Start();
            StatusPic.Image = Resources.dashboard__1_;
            lblStatus.Text = "Dashboard";
        }
        //----------------------------------------SALE----------------------------------------------------
        private void btnSale_Click(object sender, EventArgs e)
        {
            StatusPic.Image = Resources.sales;
            lblStatus.Text = "Sales";
            MainTab.SelectTab(21);
            txtSaleDate.Text = Date;

           // cbCustomer.Items.Clear();
            Sale s = new Sale();
            cbCustomer.DataSource = s.getCustomers();
            cbCustomer.DisplayMember = "FirstName";
            cbCustomer.ValueMember = "RegularClientID";
            
            dgvSales.DataSource = s.getsolditems();
        }

        //----------------------------------------SALE----------------------------------------------------

        //----------------------------------------PURCHASE------------------------------------------------
        GetCategories getcat = new GetCategories();
        GetSuppliers getsup = new GetSuppliers();
        
        private void btnPurchase_Click(object sender, EventArgs e)
        {
            dgvViewOrders.DataSource = Getvorder.getViewOrders();
            lbdTotalOrdersCount.Text = 0.ToString();
            lbdTotalOrdersCount.Text = (((int.Parse(lbdTotalOrdersCount.Text) + Getvorder.getViewOrders().Rows.Count))).ToString();
            cbPurCategory.Items.Clear();
            cbPurSupplier.Items.Clear();
            for (int i = 0; i < getcat.getCategories().Rows.Count; i++)
            {
                cbPurCategory.Items.Add(getcat.getCategories().Rows[i]["CategoryName"]);
            }
            for (int i = 0; i < getsup.getSuppliers().Rows.Count; i++)
            {
                cbPurSupplier.Items.Add(getsup.getSuppliers().Rows[i]["SupplierName"]);
            }


            if (click == 0)
            {
              
                timer1.Start();
                btn = btnPurchase;
                
                pnl = pnlPurchase;
                click++;
            }
            else
            {
                isCollapsed = false;
                timer1.Start();
                click--;
            }
        }
        private void btnPurNewItem_Click(object sender, EventArgs e)
        {
            AddPurchasedOrders p = new AddPurchasedOrders();
            txtPurItemId.Text = p.getID();
            MainTab.SelectTab(22);
            StatusPic.Image = Resources.order;
            lblStatus.Text = "Purchase";
            btnPurSearch.Visible = false;
            txtPurSearch.Visible = false;
            txtPurItemName.Enabled = true;
            cbPurCategory.Enabled = true;
        }
        private void btnPurExisItem_Click(object sender, EventArgs e)
        {
            MainTab.SelectTab(22);
            AddPurchasedOrders p = new AddPurchasedOrders();
            txtPurItemId.Text = p.getID();
            StatusPic.Image = Resources.order;
            lblStatus.Text = "Purchase";
            btnPurSearch.Visible = true;
            txtPurSearch.Visible = true;
            txtPurItemName.Enabled = false;
            cbPurCategory.Enabled = false;
        }
        
        //----------------------------------------PURCHASE------------------------------------------------
        private void getDateTimer_Tick(object sender, EventArgs e)
        {
            DateTime Today = DateTime.Now;
            Date = Today.ToString("d");
        }
        private void txtSaleQuantity_Leave(object sender, EventArgs e)
        {
            if(int.Parse(txtSaleQuantity.Text)<=quantityLimit)
            {
                double price = double.Parse(txtSaleUnitPirce.Text);
                double amount = double.Parse(txtSaleQuantity.Text);
                double totalAmount = price * amount;
                txtSaleTotalPrice.Text = totalAmount.ToString();
            }
            else
            {
                MessageBox.Show("The Specified Item Quantity is only: " + quantityLimit.ToString() + " Please Enter Again");
                txtSaleQuantity.Text = "";
            }
            
        }

        private void btnAddSale_Click(object sender, EventArgs e)
        {
            string[] rows = new string[] {txtSaleItemId.Text, txtSaleItemName.Text, txtSaleUnitPirce.Text,txtSaleQuantity.Text,cbCustomer.SelectedItem.ToString(),txtSaleDate.Text,txtSaleTotalPrice.Text };
            dgvSales.Rows.Add(rows);
            txtSaleItemId.Text = "";
            txtSaleItemName.Text = "";
            txtSaleUnitPirce.Text = "";
            txtSaleQuantity.Text = "";
            txtSaleTotalPrice.Text = "";

        }

        private void btnSalRepSearch_Click(object sender, EventArgs e)
        {
          //  MessageBox.Show(cbSalRepSearchBy.SelectedItem.ToString());
            dvgSalesReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            new SignIn().Visible = true;
            this.Hide();
        }

        private void dgvSales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvSales.Columns[e.ColumnIndex].Name=="Delete")
            {
                dgvSales.Rows.RemoveAt(dgvSales.Rows[e.RowIndex].Index);
            }

        }
        Category cat = new Category();
        private void btnSaveCategory_Click(object sender, EventArgs e)
        {
           
            if(txtCatSearch.Text=="")
            { 
            
                MessageBox.Show("Category Id Should be specified");
            return;
            }
            cat.categoryId = int.Parse(txtCatSearch.Text);
            if (txtCategoryName.Text == "")
            {

                MessageBox.Show("Category Name Should be specified");
                return;
            }
            cat.categoryName = txtCategoryName.Text;
            if (cbCommodityType.SelectedItem == null)
            {

                MessageBox.Show("Commodity Type Should be specified");
                return;
            }
            cat.categoryCommodityType = cbCommodityType.Text;

            cat.addCategory();
            dvgCategory.DataSource = cat.getAllCategory();
            txtCatSearch.Text = cat.getCategoryId().ToString();
            txtCategoryName.Text = "";
            cbCommodityType.Text = "";
        }
        public void styleDataGridView(DataGridView dvg)
        {
            dvg.BorderStyle = BorderStyle.None;
            dvg.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(47,71,100);
            dvg.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dvg.DefaultCellStyle.SelectionBackColor = Color.FromArgb(55, 152, 163);
            dvg.DefaultCellStyle.SelectionForeColor = Color.White;
            dvg.BackgroundColor = Color.White;
            dvg.EnableHeadersVisualStyles = false;
            dvg.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dvg.ColumnHeadersDefaultCellStyle.Font = new Font("MS Reference Sans Serif", 10);
            dvg.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(68, 107, 111);
            dvg.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dvg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        public void styleDataGridView3_2(DataGridView dvg)
        {
            dvg.BorderStyle = BorderStyle.None;
            dvg.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(47, 71, 100);
            dvg.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dvg.DefaultCellStyle.SelectionBackColor = Color.FromArgb(55, 152, 163);
            dvg.DefaultCellStyle.SelectionForeColor = Color.White;
            dvg.BackgroundColor = Color.White;
            dvg.EnableHeadersVisualStyles = false;
            dvg.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dvg.ColumnHeadersDefaultCellStyle.Font = new Font("MS Reference Sans Serif", 10);
            dvg.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(68, 107, 111);
            dvg.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            DataGridViewButtonColumn c = (DataGridViewButtonColumn)dvg.Columns[0];
            if (c != null)
            {
                c.FlatStyle = FlatStyle.Flat;
                c.DefaultCellStyle.ForeColor = Color.White;
                c.DefaultCellStyle.BackColor = Color.FromArgb(55, 152, 163);

            }
            DataGridViewButtonColumn c2 = (DataGridViewButtonColumn)dvg.Columns[1];
            if (c2 != null)
            {
                c2.FlatStyle = FlatStyle.Flat;
                c2.DefaultCellStyle.ForeColor = Color.White;
                c2.DefaultCellStyle.BackColor = Color.FromArgb(55, 152, 163);
            }
        }
        public void styleDataGridView3(DataGridView dvg)
        {
            dvg.BorderStyle = BorderStyle.None;
            dvg.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(47, 71, 100);
            dvg.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dvg.DefaultCellStyle.SelectionBackColor = Color.FromArgb(55, 152, 163);
            dvg.DefaultCellStyle.SelectionForeColor = Color.White;
            dvg.BackgroundColor = Color.White;
            dvg.EnableHeadersVisualStyles = false;
            dvg.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dvg.ColumnHeadersDefaultCellStyle.Font = new Font("MS Reference Sans Serif", 10);
            dvg.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(68, 107, 111);
            dvg.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dvg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGridViewButtonColumn c = (DataGridViewButtonColumn)dvg.Columns[0];
            if (c != null)
            {
                c.FlatStyle = FlatStyle.Flat;
                c.DefaultCellStyle.ForeColor = Color.White;
                c.DefaultCellStyle.BackColor = Color.FromArgb(55, 152, 163);
                
            }
            DataGridViewButtonColumn c2 = (DataGridViewButtonColumn)dvg.Columns[1];
            if (c2 != null)
            {
                c2.FlatStyle = FlatStyle.Flat;
                c2.DefaultCellStyle.ForeColor = Color.White;
                c2.DefaultCellStyle.BackColor = Color.FromArgb(55, 152, 163);
            }
        }
        public void styleDataGridView4(DataGridView dvg)
        {
            dvg.BorderStyle = BorderStyle.None;
            dvg.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(47, 71, 100);
            dvg.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dvg.DefaultCellStyle.SelectionBackColor = Color.FromArgb(55, 152, 163);
            dvg.DefaultCellStyle.SelectionForeColor = Color.White;
            dvg.BackgroundColor = Color.White;
            dvg.EnableHeadersVisualStyles = false;
            dvg.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dvg.ColumnHeadersDefaultCellStyle.Font = new Font("MS Reference Sans Serif", 10);
            dvg.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(68, 107, 111);
            dvg.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            DataGridViewButtonColumn c = (DataGridViewButtonColumn)dvg.Columns[0];
            if (c != null)
            {
                c.FlatStyle = FlatStyle.Flat;
                c.DefaultCellStyle.ForeColor = Color.White;
                c.DefaultCellStyle.BackColor = Color.FromArgb(55, 152, 163);

            }
        }
        public void styleDataGridView2(DataGridView dvg)
        {
            dvg.BorderStyle = BorderStyle.None;
            dvg.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(47, 71, 100);
            dvg.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dvg.DefaultCellStyle.SelectionBackColor = Color.FromArgb(55, 152, 163);
            dvg.DefaultCellStyle.SelectionForeColor = Color.White;
            dvg.BackgroundColor = Color.White;
            dvg.EnableHeadersVisualStyles = false;
            dvg.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dvg.ColumnHeadersDefaultCellStyle.Font = new Font("MS Reference Sans Serif", 10);
            dvg.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(68,107,111);
            dvg.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            
        }

        private void dvgCategory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dvgCategory.Columns[e.ColumnIndex].Name == "EditCat")
            {
                dvgCategory.CurrentRow.Selected = true;
                txtCatSearch.Text = dvgCategory.Rows[e.RowIndex].Cells[2].FormattedValue.ToString();
                txtCategoryName.Text = dvgCategory.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();
                cbCommodityType.Text = dvgCategory.Rows[e.RowIndex].Cells[4].FormattedValue.ToString();

            }
            if (dvgCategory.Columns[e.ColumnIndex].Name == "DeleteCat")
            {
                dvgCategory.CurrentRow.Selected = true;
                Category cat = new Category();
                cat.categoryId = int.Parse(dvgCategory.Rows[e.RowIndex].Cells[2].FormattedValue.ToString());
                string toBeDeletedName = dvgCategory.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete " + toBeDeletedName, "Deleting Supplier", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    cat.deleteCategory();
                    dvgCategory.DataSource = cat.getAllCategory();
                    txtSupplierId.Text = cat.getCategoryId().ToString();
                    dvgCategory.DataSource = cat.getAllCategory();
                }
                else
                {
                    //does nothing 

                }

            }

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
      
        private void btnMaximize_Click(object sender, EventArgs e)
        {
            
            
        }

       

        private void btnMinimize_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        GetViewOrder Getvorder = new GetViewOrder();
        private void btnViewOrder_Click(object sender, EventArgs e)
        {
            dgvViewOrders.DataSource = Getvorder.getViewOrders();
            MainTab.SelectTab(25);
        }

        private void btnSavePatient_Click(object sender, EventArgs e)
        {
            
            Patients2ndLayer P2L = new Patients2ndLayer();
            String SaveStatus=P2L.savePatients(int.Parse(txtPatientID.Text), txtPatientFname.Text, txtPatientsMname.Text, txtPatientsLname.Text, dtpPatientDateofBirth.Value,txtPatAddress.Text,txtPatEmail.Text,txtPatPrimaryPhone.Text,txtPatSecondaryPhone.Text);
            MessageBox.Show(SaveStatus);
            dgvPatient.DataSource = P2L.FetchPatients();
        }

        private void dgvPatient_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvPatient.Columns[e.ColumnIndex].Name=="PatEdit")
            {
                dgvPatient.CurrentRow.Selected = true;
                txtPatientID.Text = dgvPatient.Rows[e.RowIndex].Cells[2].FormattedValue.ToString();
                txtPatientFname.Text = dgvPatient.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();
                txtPatientsMname.Text = dgvPatient.Rows[e.RowIndex].Cells[4].FormattedValue.ToString();
                txtPatientsLname.Text = dgvPatient.Rows[e.RowIndex].Cells[5].FormattedValue.ToString();
                dtpPatientDateofBirth.Text = dgvPatient.Rows[e.RowIndex].Cells[6].FormattedValue.ToString();
                txtPatAddress.Text= dgvPatient.Rows[e.RowIndex].Cells[7].FormattedValue.ToString();
                txtPatEmail.Text= dgvPatient.Rows[e.RowIndex].Cells[10].FormattedValue.ToString();
                txtPatPrimaryPhone.Text= dgvPatient.Rows[e.RowIndex].Cells[8].FormattedValue.ToString();
                txtPatSecondaryPhone.Text= dgvPatient.Rows[e.RowIndex].Cells[9].FormattedValue.ToString();
            }
            else if (dgvPatient.Columns[e.ColumnIndex].Name == "PatDelete")
            {
                dgvPatient.CurrentRow.Selected = true;
                Patients2ndLayer P2L = new Patients2ndLayer();
                string DeleteStatus =P2L.DeletePatient(int.Parse(dgvPatient.Rows[e.RowIndex].Cells[2].FormattedValue.ToString()));

                MessageBox.Show(DeleteStatus);
                dgvPatient.DataSource = P2L.FetchPatients();
            }
        }

        private void btnSaveSupplier_Click(object sender, EventArgs e)
        {

            Supplier sup = new Supplier();
            sup.supplierId = int.Parse(txtSupplierId.Text);
            sup.supplierName = txtSupplierName.Text;
            sup.supplierCountry = txtSupplierCountry.Text;
            sup.supplierCity = txtSupplierCity.Text;
            sup.supplierContactAddress = txtSupplierAddress.Text;
            sup.addSupplier();
            dvgSupplier.DataSource = sup.getAllSuppliers();
            txtSupplierId.Text = sup.getSupplierId().ToString();
            txtSupplierName.Text = "";
            txtSupplierCountry.Text = "";
            txtSupplierCity.Text = "";
            txtSupplierAddress.Text = "";
        }

        private void dvgSupplier_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dvgSupplier.Columns[e.ColumnIndex].Name == "SupEdit")
            {
                dvgSupplier.CurrentRow.Selected = true;
                txtSupplierId.Text = dvgSupplier.Rows[e.RowIndex].Cells[2].FormattedValue.ToString();
                txtSupplierName.Text = dvgSupplier.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();
                txtSupplierCountry.Text = dvgSupplier.Rows[e.RowIndex].Cells[4].FormattedValue.ToString();
                txtSupplierCity.Text = dvgSupplier.Rows[e.RowIndex].Cells[5].FormattedValue.ToString();
                txtSupplierAddress.Text = dvgSupplier.Rows[e.RowIndex].Cells[6].FormattedValue.ToString();
               
            }
            if (dvgSupplier.Columns[e.ColumnIndex].Name == "SupDelete")
            {
                dvgSupplier.CurrentRow.Selected = true;
                Supplier sup = new Supplier();
                sup.supplierId = int.Parse(dvgSupplier.Rows[e.RowIndex].Cells[2].FormattedValue.ToString());
                string toBeDeletedName = dvgSupplier.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete " + toBeDeletedName, "Deleting Supplier", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    sup.deleteSupplier();
                    dvgSupplier.DataSource = sup.getAllSuppliers();
                    txtSupplierId.Text = sup.getSupplierId().ToString();
                }
                else
                {
                    //does nothing 

                }
                

            }
           
              
        }

        private void btnSupplierClear_Click(object sender, EventArgs e)
        {
            txtSupplierId.Text = "";
            txtSupplierName.Text = "";
            txtSupplierAddress.Text = "";
            txtSupplierCity.Text = "";
            txtSupplierCountry.Text = "";
            Supplier sup = new Supplier();
            txtSupplierId.Text = sup.getSupplierId().ToString();
            dvgSupplier.DataSource = sup.getAllSuppliers();
        }

        private void btnClearCategory_Click(object sender, EventArgs e)
        {
            txtCatSearch.Text = "";
            txtCategoryName.Text = "";
            cbCommodityType.Text = "";
            Category cat = new Category();
            dvgCategory.DataSource = cat.getAllCategory();
            txtCatSearch.Text = cat.getCategoryId().ToString();
        }


        //Creating the datatable to add the purchase orders to the gridview
        DataTable PurchaseTable = new DataTable();
        public void createTable()
        { 
           PurchaseTable.Columns.Add("ItemId");
            PurchaseTable.Columns.Add("Category");
            PurchaseTable.Columns.Add("ItemName");
            PurchaseTable.Columns.Add("BatchNumber");
            PurchaseTable.Columns.Add("ProductionDate");
            PurchaseTable.Columns.Add("ExpiryDate");
           // PurchaseTable.Columns.Add("PurchaseType");
            PurchaseTable.Columns.Add("TaxStatus");
            PurchaseTable.Columns.Add("StoreBranch");
            PurchaseTable.Columns.Add("TotalAmount");
            PurchaseTable.Columns.Add("Quantity");
            PurchaseTable.Columns.Add("UnitCost");
            PurchaseTable.Columns.Add("UnitPrice");
            PurchaseTable.Columns.Add("MeasureUnit");
            PurchaseTable.Columns.Add("ManfDetail");
            PurchaseTable.Columns.Add("Supplier");
            PurchaseTable.Columns.Add("Invoice");
            PurchaseTable.Columns.Add("PurchaseDate");
            PurchaseTable.Columns.Add("PaymentMethod");
            }

       
        //To Save the orders to database which will later be confirmed by the Store Owner
       private void btnSaveOrders_Click(object sender, EventArgs e)
        {
           
        }
        //To add a purchaseorder to the datagridview
        OrderList ol = new OrderList();
        private void btnAddPurchase_Click_1(object sender, EventArgs e)
        {
            
            DataRow NewPurchaseRow = PurchaseTable.NewRow();
            if (txtPurItemId.Text == "")
            {
                MessageBox.Show("Iteam Id Detail Should be Supplied");
                return;
            }
            NewPurchaseRow["ItemId"] = txtPurItemId.Text;
            if (cbPurCategory.SelectedItem == null)
            {
                MessageBox.Show("Category Detail Should be Supplied");
                return;

            }
            NewPurchaseRow["Category"] = cbPurCategory.SelectedItem.ToString();
            if (txtPurItemName.Text == "")
            {
                MessageBox.Show("Iteam Name Detail Should be Supplied");
                return;
            }
            NewPurchaseRow["ItemName"] = txtPurItemName.Text;
            if (txtPurBatchNumber.Text == "")
            {
                MessageBox.Show("Batch Number Detail Should be Supplied");
                return;
            }
            NewPurchaseRow["BatchNumber"] = txtPurBatchNumber.Text;
            if (dtpPurProductionDate.Value.Day >= dtpPurExpiryDate.Value.Day)
            {
                if (dtpPurProductionDate.Value.Month >= dtpPurExpiryDate.Value.Month)
                {
                    if (dtpPurProductionDate.Value.Year >= dtpPurExpiryDate.Value.Year)
                    { 
                    MessageBox.Show("Production Date Detail Should be less than the Expiry Date Detail");
                    return;
                    }
                }
            }
            NewPurchaseRow["ProductionDate"] = dtpPurProductionDate.Value.ToString("yyyy-MM-dd");
            NewPurchaseRow["ExpiryDate"] = dtpPurExpiryDate.Value.ToString("yyyy-MM-dd");
            if (txtPurTaxStatus.Text == "")
            {
                MessageBox.Show("Tax Status Detail Should be Supplied");
                return;
            }
            NewPurchaseRow["TaxStatus"] = txtPurTaxStatus.Text;
            if (txtPurStoreBranch.Text == "")
            {
                MessageBox.Show("Store Branch Detail Should be Supplied");
                return;
            }
            NewPurchaseRow["StoreBranch"] = txtPurStoreBranch.Text;
            if (txtPurTotalAmount.Text == "")
            {
                MessageBox.Show("Total Amount Detail Should be Supplied");
                return;
            }
            NewPurchaseRow["TotalAmount"] = txtPurTotalAmount.Text;
            if (txtPurQuantity.Text == "")
            {
                MessageBox.Show("Quantity Detail Should be Supplied");
                return;
            }
            NewPurchaseRow["Quantity"] = txtPurQuantity.Text;
            if (txtPurUnitCost.Text == "")
            {
                MessageBox.Show("Unit Cost Detail Should be Supplied");
                return;
            }
            NewPurchaseRow["UnitCost"] = txtPurUnitCost.Text;
            if (txtPurUnitPrice.Text == "")
            {
                MessageBox.Show("Unit Price Detail Should be Supplied");
                return;
            }
            NewPurchaseRow["UnitPrice"] = txtPurUnitPrice.Text;
            if (txtPurMeasureUnit.Text == "")
            {
                MessageBox.Show("Measure Unit Detail Should be Supplied");
                return;
            }
            NewPurchaseRow["MeasureUnit"] = txtPurMeasureUnit.Text;
            if (txtManfDetail.Text == "")
            {
                MessageBox.Show("Manufacturer Detail Should be Supplied");
                return;
            }
            NewPurchaseRow["ManfDetail"] = txtManfDetail.Text;
            if (cbPurSupplier.SelectedItem == null)
            {
                MessageBox.Show("Supplier Detail Should be Supplied");
                return;
            }
            NewPurchaseRow["Supplier"] = cbPurSupplier.SelectedItem.ToString();
            if (txtPurInvoice.Text == "")
            {
                MessageBox.Show("Invoice Detail Should be Supplied");
                return;
            }
            NewPurchaseRow["Invoice"] = txtPurInvoice.Text;
            
            NewPurchaseRow["PurchaseDate"] = dtpPurchaseDate.Value.ToString("yyyy-MM-dd");
            if (txtPurPaymentMethod.Text == "")
            {
                MessageBox.Show("Payment Method Detail Should be Supplied");
                return;
            }
            NewPurchaseRow["PaymentMethod"] = txtPurPaymentMethod.Text;


            PurchaseTable.Rows.Add(NewPurchaseRow);
            AddPurchasedOrders AD = new AddPurchasedOrders();
            MessageBox.Show(AD.AddOrders(PurchaseTable));
            lbdTotalOrdersCount.Text = (int.Parse(lbdTotalOrdersCount.Text) + 1).ToString();
            
            
              
        }
        
        //To return to the purchase form from the view orders form
        private void btnBackToPurchase_Click(object sender, EventArgs e)
        {
            txtPurItemId.Text = "";
            txtPurItemName.Text = "";
            cbPurCategory.Items.Add("");
            txtPurBatchNumber.Text = "";
            dtpPurProductionDate.Text = "";
            dtpPurExpiryDate.Text = "";
            txtManfDetail.Text = "";
            txtPurMeasureUnit.Text = "";
            cbPurSupplier.Items.Add("");
            txtPurQuantity.Text = "";
            txtPurUnitCost.Text = "";
            txtPurUnitPrice.Text = "";
            dtpPurchaseDate.Text = "";
            txtPurPaymentMethod.Text = "";
            txtPurTaxStatus.Text = "";
            txtPurInvoice.Text = "";
            txtPurStoreBranch.Text = "";
            txtPurTotalAmount.Text = "";
            MainTab.SelectTab(22);
        }

        private void dgvViewOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            
            if (dgvViewOrders.Columns[e.ColumnIndex].Name == "ViewOrderEdit")
            {
                dgvViewOrders.CurrentRow.Selected = true;
                txtPurItemId.Text = dgvViewOrders.Rows[e.RowIndex].Cells[2].FormattedValue.ToString();
                txtPurItemName.Text = dgvViewOrders.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();
                cbPurCategory.Items.Add(dgvViewOrders.Rows[e.RowIndex].Cells[4].FormattedValue.ToString());
                txtPurBatchNumber.Text = dgvViewOrders.Rows[e.RowIndex].Cells[5].FormattedValue.ToString();
                dtpPurProductionDate.Text = dgvViewOrders.Rows[e.RowIndex].Cells[6].FormattedValue.ToString();
                dtpPurExpiryDate.Text  = dgvViewOrders.Rows[e.RowIndex].Cells[7].FormattedValue.ToString();
                txtManfDetail.Text = dgvViewOrders.Rows[e.RowIndex].Cells[8].FormattedValue.ToString();
                txtPurMeasureUnit.Text = dgvViewOrders.Rows[e.RowIndex].Cells[9].FormattedValue.ToString();
                cbPurSupplier.Items.Add(dgvViewOrders.Rows[e.RowIndex].Cells[10].FormattedValue.ToString());
                txtPurQuantity.Text = dgvViewOrders.Rows[e.RowIndex].Cells[11].FormattedValue.ToString();
                txtPurUnitCost.Text = dgvViewOrders.Rows[e.RowIndex].Cells[12].FormattedValue.ToString();
                txtPurUnitPrice.Text = dgvViewOrders.Rows[e.RowIndex].Cells[13].FormattedValue.ToString();
                dtpPurchaseDate.Text = dgvViewOrders.Rows[e.RowIndex].Cells[14].FormattedValue.ToString();
                txtPurPaymentMethod.Text = dgvViewOrders.Rows[e.RowIndex].Cells[15].FormattedValue.ToString();
                txtPurTaxStatus.Text= dgvViewOrders.Rows[e.RowIndex].Cells[16].FormattedValue.ToString();
                txtPurInvoice.Text = dgvViewOrders.Rows[e.RowIndex].Cells[17].FormattedValue.ToString();
                txtPurStoreBranch.Text= dgvViewOrders.Rows[e.RowIndex].Cells[18].FormattedValue.ToString();
                txtPurTotalAmount.Text= dgvViewOrders.Rows[e.RowIndex].Cells[19].FormattedValue.ToString();
                MainTab.SelectTab(22);
                DeleteViewOrderDB obj = new DeleteViewOrderDB();
                MessageBox.Show(obj.DeleteOrders(int.Parse(dgvViewOrders.Rows[e.RowIndex].Cells[2].FormattedValue.ToString())));
                lbdTotalOrdersCount.Text = (int.Parse(lbdTotalOrdersCount.Text) - 1).ToString();
            }
            if (dgvViewOrders.Columns[e.ColumnIndex].Name == "ViewOrderDelete")
            {
                dgvViewOrders.CurrentRow.Selected = true;
                DeleteViewOrderDB obj = new DeleteViewOrderDB();
                MessageBox.Show(obj.DeleteOrders(int.Parse(dgvViewOrders.Rows[e.RowIndex].Cells[2].FormattedValue.ToString())));
                lbdTotalOrdersCount.Text = (int.Parse(lbdTotalOrdersCount.Text) - 1).ToString();
                dgvViewOrders.DataSource = Getvorder.getViewOrders();
            }
        }

        private void btnSaveOrders_Click_1(object sender, EventArgs e)
        {
            
            SaveOrders sa = new SaveOrders();
            string message = sa.SaveOrderstodatabase(userId);
            MessageBox.Show(message);
            lbdTotalOrdersCount.Text = 0.ToString();
            dgvViewOrders.DataSource = Getvorder.getViewOrders();


        }
     
        
        private void dgvDrugStore_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            /*
             * DrugName,CategoryName,DrugBatchNumber,DrugProductionNumber,DrugExpiryDate,DrugManufacturer,DrugMeasurementUnit,DrugQunatity,
             * DrugUnitCost,DrugUnitPrice,SupplierName,PurchaseDate,UserName,PaymentMethod,TaxStatus,Tax,TotalAmount,InvoiceNumber,
             * StoreName
             */
            GetDrugId gdi = new GetDrugId();
            if (dgvDrugStore.Columns[e.ColumnIndex].Name == "EditStoreMedicine")
            {

                dgvDrugStore.CurrentRow.Selected = true;

                txtStrDrugID.Text = gdi.getDrugsId(dgvDrugStore.Rows[e.RowIndex].Cells[2].FormattedValue.ToString()).ToString();
                txtStrDrugName.Text = dgvDrugStore.Rows[e.RowIndex].Cells[2].FormattedValue.ToString();
                txtDrugStrBatchNo.Text = dgvDrugStore.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();
                txtManuDetailStr.Text = dgvDrugStore.Rows[e.RowIndex].Cells[4].FormattedValue.ToString();
                txtDrugStrMesureUnit.Text = dgvDrugStore.Rows[e.RowIndex].Cells[5].FormattedValue.ToString();
                txtDrugStrQuantity.Text= dgvDrugStore.Rows[e.RowIndex].Cells[6].FormattedValue.ToString(); 


                
            }
            if (dgvDrugStore.Columns[e.ColumnIndex].Name == "DeleteSotreDrug")
            {
                dgvDrugStore.CurrentRow.Selected = true;
                DeleteSotreMedicineDB obj = new DeleteSotreMedicineDB();
                MessageBox.Show(obj.DeleteDrugs(gdi.getDrugsId(dgvDrugStore.Rows[e.RowIndex].Cells[2].FormattedValue.ToString())));
                lbdTotalOrdersCount.Text = (int.Parse(lbdTotalOrdersCount.Text) - 1).ToString();
                GetStoreDrugsDB obj2 = new GetStoreDrugsDB();
                dgvDrugStore.DataSource = obj2.getStoreDrug();
            }
        }
        EditStoreDB db = new EditStoreDB();
       
        
        private void btnSaveStoreMed_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbDrugCategory.SelectedItem == null) {
                MessageBox.Show("Catogory Detail not specified");
                    return;
            
            }
                
                MessageBox.Show(db.saveToSotre(txtStrDrugID.Text, txtStrDrugName.Text, cbDrugCategory.SelectedItem.ToString(), txtDrugStrBatchNo.Text,
                       dtpExpDateStr.Value.ToString("yyyy-MM-dd"), txtDrugStrMesureUnit.Text, txtManuDetailStr.Text, txtDrugStrQuantity.Text));

                dgvDrugStore.DataSource = obj.getStoreDrug();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
                throw;
            }
            
           
        }
        GetSalesReportDB gsr = new GetSalesReportDB();
        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            //dgvSalesReport.DataSource= gsr.getSalesReport(dtpReportFrom.Value.ToString("yyyy-MM-dd"), dtpReportTo.Value.ToString("yyyy-MM-dd"));
       
            //new SalesReportViewr1(userId).Visible = true;
            //this.Hide();
        }

        private void btnDispensery_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtMoveToQuantity.Text=="")
                {
                    MessageBox.Show("Quantity Detail Should be specified");
                    return;
                }
                Dispensery D = new Dispensery();
                D.DrugID = int.Parse(txtSearchDrugIdDis.Text);
                dgvSuggestion.DataSource = D.getAllPossibleMed();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
                //throw;
            }
            
        }

        private void dgvSuggestion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSuggestion.Columns[e.ColumnIndex].Name == "Move")
            {
                Dispensery D = new Dispensery();
                dgvSuggestion.CurrentRow.Selected = true;
                D.DrugID = int.Parse(dgvSuggestion.Rows[e.RowIndex].Cells[1].FormattedValue.ToString());
                D.Quantity = int.Parse(txtMoveToQuantity.Text);
                D.moveToDispenser();
                dgvDispenseyDrug.DataSource = D.getDispenseryMed();
            }
        }

        private void btnGeneratePurchaseReport_Click(object sender, EventArgs e)
        {

            dgvPurchaseReport2.DataSource= gsr.getPurchaseReport(dtpPurchaseFrom.Value, dtpPurchaseUpto.Value);
               
        }

        private void undoCat_Click(object sender, EventArgs e)
        {
            Category cat = new Category();
            dvgCategory.DataSource = cat.getAllCategory();
        }

        private void btnSearchCat_Click(object sender, EventArgs e)
        {
            Category cat = new Category();
            cat.categoryId = int.Parse(txtCatSearch.Text);
            dvgCategory.DataSource=cat.searchCategory();
        }

        private void dgvEmployee_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvEmployee.Columns[e.ColumnIndex].Name == "EmpEdit")
            {
                dgvEmployee.CurrentRow.Selected = true;
                txtEmployeeId.Text = dgvEmployee.Rows[e.RowIndex].Cells[2].FormattedValue.ToString();
                txtEmployeeContact.Text = dgvEmployee.Rows[e.RowIndex].Cells[10].FormattedValue.ToString();
                txtEmployeeContactName.Text = dgvEmployee.Rows[e.RowIndex].Cells[9].FormattedValue.ToString();
                textBox4.Text = dgvEmployee.Rows[e.RowIndex].Cells[7].FormattedValue.ToString();
                textBox1.Text = dgvEmployee.Rows[e.RowIndex].Cells[5].FormattedValue.ToString();
                textBox5.Text = dgvEmployee.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();
                textBox3.Text = dgvEmployee.Rows[e.RowIndex].Cells[4].FormattedValue.ToString();
                dateTimePicker1.Text = dgvEmployee.Rows[e.RowIndex].Cells[6].FormattedValue.ToString();
                txtPhoneNumber.Text = dgvEmployee.Rows[e.RowIndex].Cells[8].FormattedValue.ToString();
                cbCommodityType.SelectedItem = dgvEmployee.Rows[e.RowIndex].Cells[11].FormattedValue.ToString();

            }
            if (dgvEmployee.Columns[e.ColumnIndex].Name == "EmpDelete")
            {
                dgvEmployee.CurrentRow.Selected = true;
                EMPLOYEELAYER2 sup = new EMPLOYEELAYER2();
                sup.EmployeeId = int.Parse(dgvEmployee.Rows[e.RowIndex].Cells[2].FormattedValue.ToString());
                string toBeDeletedName = dgvEmployee.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete " + toBeDeletedName, "Deleting Employee", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    sup.deleteEmployee();
                    dgvEmployee.DataSource = sup.fetchemployeeinfo();
                    txtEmployeeId.Text = sup.getEmployeeeId();
                }
                else
                {
                    //does nothing 

                }





            }

        }

        private void dgvPurchseReport_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dgvSalesReport_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSalesReport.Columns[e.ColumnIndex].Name == "SalesReportPrint")
            {
              
            }
        }

        private void PurchasePrint_Click(object sender, EventArgs e)
        {
            //dgvPurchseReport.CurrentRow.Selected = true;
           generateReport(dgvPurchaseReport2);
        }
        
        PrintReport pr = new PrintReport();
        private void SalesPrint_Click(object sender, EventArgs e)
        {
            dgvSalesReport.CurrentRow.Selected = true;
            
            pr.generateReport(dgvSalesReport);

        }

        private void btnPrintTodays_Click(object sender, EventArgs e)
        {
            
            pr.generateReport(dgvtoday);
        }

        private void groupBox20_Enter(object sender, EventArgs e)
        {

        }

        private void label123_Click(object sender, EventArgs e)
        {

        }

        private void groupBox28_Enter(object sender, EventArgs e)
        {

        }
        

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
           
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mousePose;
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSaveEmployee_Click(object sender, EventArgs e)
        {
            EMPLOYEELAYER2 emplay = new EMPLOYEELAYER2();

            emplay.EmployeeId = int.Parse(txtEmployeeId.Text);
            emplay.EmployeeFirstName = textBox5.Text;
            emplay.EmployeeMiddleName = textBox3.Text;
            emplay.EmployeeLastName = textBox1.Text;
            emplay.EmployeeDateBirth = dateTimePicker1.Value;
            emplay.EmployeeAddress = textBox4.Text;
            emplay.EmployeePhoneNumber = txtPhoneNumber.Text;
            emplay.EmployeeEmergencyContactName = txtEmployeeContactName.Text;
            emplay.EmployeeEmergencyContactNumber = txtEmployeeContact.Text;
            emplay.EmployeeRoleID = int.Parse(cbEmployeeRole.SelectedValue.ToString());
            emplay.SaveEmployee();
            dgvEmployee.DataSource = emplay.fetchemployeeinfo();
            txtEmployeeId.Text = emplay.getEmployeeeId();
            txtEmployeeContact.Text = "";
            txtEmployeeContactName.Text = "";
            textBox4.Text = "";
            textBox1.Text = "";
            textBox5.Text = "";
            textBox3.Text = "";
            dateTimePicker1.Text = "";
            txtPhoneNumber.Text = "";
        }
        public void generateReport(DataGridView dgv)
        {
            if (dgv.Rows.Count > 0)

            {

                SaveFileDialog save = new SaveFileDialog();

                save.Filter = "PDF (*.pdf)|*.pdf";

                save.FileName = "Report.pdf";

                bool ErrorMessage = false;

                if (save.ShowDialog() == DialogResult.OK)

                {
                    if (File.Exists(save.FileName))
                    {
                        try

                        {

                            File.Delete(save.FileName);

                        }

                        catch (Exception ex)

                        {

                            ErrorMessage = true;

                            MessageBox.Show("Unable to wride data in disk" + ex.Message);

                        }

                    }

                    if (!ErrorMessage)

                    {

                        try

                        {

                            PdfPTable pTable = new PdfPTable(dgv.Columns.Count);

                            pTable.DefaultCell.Padding = 2;

                            pTable.WidthPercentage = 100;

                            pTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach (DataGridViewColumn col in dgv.Columns)

                            {

                                PdfPCell pCell = new PdfPCell(new Phrase(col.HeaderText));

                                pTable.AddCell(pCell);

                            }

                            foreach (DataGridViewRow viewRow in dgv.Rows)

                            {

                                foreach (DataGridViewCell dcell in viewRow.Cells)

                                {

                                    try
                                    {
                                        pTable.AddCell(dcell.Value.ToString());
                                    }
                                    catch (Exception err)
                                    {

                                        MessageBox.Show("ERROR: ", err.Message); ;
                                    }

                                }

                            }

                            using (FileStream fileStream = new FileStream(save.FileName, FileMode.Create))

                            {

                                Document document = new Document(PageSize.A4, 8f, 16f, 16f, 8f);

                                PdfWriter.GetInstance(document, fileStream);

                                document.Open();

                                document.Add(pTable);

                                document.Close();

                                fileStream.Close();

                            }

                            MessageBox.Show("Data Export Successfully", "info");

                        }

                        catch (Exception ex)

                        {

                            MessageBox.Show("Error while exporting Data" + ex.Message);

                        }

                    }

                }

            }

            else

            {

                MessageBox.Show("No Record Found", "Info");

            }
        }

        private void btnGeneratePurchaseReport_Click_1(object sender, EventArgs e)
        {
            dgvPurchaseReport2.DataSource = gsr.getPurchaseReport(dtpPurchaseFrom.Value, dtpPurchaseUpto.Value);
        }

        private void PurchasePrint_Click_1(object sender, EventArgs e)
        {
            generateReport(dgvPurchaseReport2);
        }

        private void btnGenerateReport_Click_1(object sender, EventArgs e)
        {
            dgvSalesReport.DataSource = gsr.getSalesReport(dtpReportFrom.Value, dtpReportTo.Value);

        }

        private void SalesPrint_Click_1(object sender, EventArgs e)
        {
            pr.generateReport(dgvSalesReport);
        }

        private void panel17_Paint(object sender, PaintEventArgs e)
        {

        }
        public void loadCharts()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["PharmacyDB"].ConnectionString))
            {
                conn.Open();
                SqlCommand da = new SqlCommand("getSalesData", conn);
                da.CommandType = CommandType.StoredProcedure;
                SqlDataReader reads = da.ExecuteReader();
                while(reads.Read())
                {
                    this.SalesChart.Series["Sales"].Points.AddXY(reads.GetInt32(2), reads.GetInt32(1));
                }
               
            }
            
        }

        public void updateDashBoard()
        {
            SalesChart.Series.Clear();
            SalesChart.Series.Add("Sales");
            SalesChart.Series["Sales"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            loadCharts();
            DashboardDB ddb = new DashboardDB();
            dgvDashboard.DataSource = ddb.getExpierDateDetail();
            lblDashBaordMed.Text = ddb.getCounts().ElementAt(0);
            lblDashboardSup.Text = ddb.getCounts().ElementAt(1);
            lblDashboardPat.Text = ddb.getCounts().ElementAt(2);
            
            for (int i = 0; i < dgvDashboard.Rows.Count; i++)
            {
                if(dgvDashboard.Rows[i].Cells["Mounths Left For expiery"].Value.ToString().Equals("0"))
                {
                    playaudio();
                    this.Notify("Medicine Expired");
                    this.Notify(dgvDashboard.Rows[i].Cells["DrugName"].Value.ToString() + " " + "has expired");
                    
                }

            }
        }
        public void Notify(string msg)
        {
            Alert frm = new Alert();
            frm.showAlert(msg);
        }

        private void Refresh_Tick(object sender, EventArgs e)
        {
            updateDashBoard();
        }

        private void btnPrintReceipt_Click(object sender, EventArgs e)
        {

            Sale s = new Sale();
            
            s.SaveSales
        (int.Parse(txtSaleItemId.Text),int.Parse(txtSaleTotalPrice.Text), cbCustomer.SelectedItem.ToString(), int.Parse(txtSaleQuantity.Text), "1234567");
            dgvSales.DataSource = s.getsolditems();

        }

        private void cbEmployeeRole_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnPurSearch_Click(object sender, EventArgs e)
        {
            AddPurchasedOrders apo = new AddPurchasedOrders();
            apo.DrugId = int.Parse(txtPurSearch.Text);
            DataRow row = apo.getDrug().Rows[0];
            txtPurItemId.Text = row["DrugId"].ToString();
            txtPurItemName.Text = row["DrugName"].ToString();
            cbPurCategory.SelectedItem = row["CategoryId"].ToString();
           
        }

        private void btnSearchSale_Click(object sender, EventArgs e)
        {
            Sale sal = new Sale();
            if(txtSaleItemId.Text.Equals(""))
            {
                MessageBox.Show("Please Provide an ID");
            }
            else
            {
                sal.getItemToBeSold(int.Parse(txtSaleItemId.Text));
                DataRow row = sal.getItemToBeSold(int.Parse(txtSaleItemId.Text)).Rows[0];
                txtSaleItemName.Text = row["A"].ToString();
                txtSaleUnitPirce.Text = row["C"].ToString();
                txtSaleQuantity.Text = row["D"].ToString();
                quantityLimit = int.Parse(row["D"].ToString());
            }
            
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            if (click == 0)
            {
                timer1.Start();
                btn = btnSettings;
                pnl = pnlSettings;
                click++;
            }
            else
            {
                isCollapsed = false;
                timer1.Start();
                click--;
            }
        }
        string regex1 = "^(?=.*[a-z])";
        string regex2 = "^(?=.*[A-Z])";
        string regex3 = "^(?=.*[-+_!@#$%^&*., ?]).+$";
        string regex4 = "^(?=.*\\d)";
        string oldPass="";
        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            MainTab.SelectTab(26);
            ChangeUserInfo ch = new ChangeUserInfo();
            DataRow row = ch.getEmpInfo(userId).Rows[0];
            txtChanFistName.Text = row["A"].ToString();
            txtChanMiddleName.Text = row["B"].ToString();
            txtChanLastname.Text = row["C"].ToString();
            txtChanPhoneNumber.Text = row["D"].ToString();
            txtChanAddress.Text = row["E"].ToString();
            txtChanEmpID.Text = row["F"].ToString();
            oldPass = row["G"].ToString();
        }
        
        private void btnBackUp_Click(object sender, EventArgs e)
        {
            string path="";
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                path = folderDlg.SelectedPath;
                //Environment.SpecialFolder root = folderDlg.RootFolder;
            }
            path = Path.Combine("Backup.xls");
            BackUp backUp = new BackUp();
            backUp.Backup(path);

        }

        private void txtNewPass_TextChanged(object sender, EventArgs e)
        {
            Regex p1 = new Regex(regex1);//lower
            Regex p2 = new Regex(regex2);//upper
            Regex p3 = new Regex(regex3);//special
            Regex p4 = new Regex(regex4);//digit
            Match m1 = p1.Match(txtNewPass.Text);
            Match m2 = p2.Match(txtNewPass.Text);
            Match m3 = p3.Match(txtNewPass.Text);
            Match m4 = p4.Match(txtNewPass.Text);
            if (m1.Success && m2.Success)
            {
                label58.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                label58.ForeColor = System.Drawing.Color.LightCoral;
            }
            if (m3.Success)
            {
                label59.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                label59.ForeColor = System.Drawing.Color.LightCoral;
            }
            if (m4.Success)
            {
                label139.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                label139.ForeColor = System.Drawing.Color.LightCoral;
            }
            if (txtNewPass.Text.Length > 8)
            {
                label140.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                label140.ForeColor = System.Drawing.Color.LightCoral;
            }
        }

        private void txtNewPass_Leave(object sender, EventArgs e)
        {

            if (label140.ForeColor == Color.LightCoral || label59.ForeColor == Color.LightCoral || label139.ForeColor == Color.LightCoral || label58.ForeColor == Color.LightCoral)
            {
                MessageBox.Show("Incorrect Password format please enter again");
                txtNewPass.Clear();
            }
        }

        private void txtConfrimPass_Leave(object sender, EventArgs e)
        {
            if (txtNewPass.Text != txtConfrimPass.Text)
            {
                MessageBox.Show("Password doesn't match");
                txtConfrimPass.Clear();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtNewPass.UseSystemPasswordChar = true;
                txtConfrimPass.UseSystemPasswordChar = true;
            }
            else
            {
                txtNewPass.UseSystemPasswordChar = false;
                txtConfrimPass.UseSystemPasswordChar = false;
            }
        }

        private void txtOldPass_Leave(object sender, EventArgs e)
        {
            if(txtOldPass.Text!=oldPass)
            {
                MessageBox.Show("Password doesn't match");
                txtOldPass.Clear();
            }
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            ChangeUserInfo ch = new ChangeUserInfo();
            ch.updateUserInfo(userId, txtNewPass.Text);
            txtOldPass.Text = "";
            txtConfrimPass.Text = "";
            txtNewPass.Text = "";
        }
    }
}
