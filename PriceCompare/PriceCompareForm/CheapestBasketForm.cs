using PriceCompareLib.Manager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PriceCompareForm.Properties;
using Excel = Microsoft.Office.Interop.Excel;
using PriceCompareLib.Modules;

namespace PriceCompareForm
{


    /**
    * When creating a UI application- consider one of the following paradigms: MVC, MVP or MVVM
    * It is best to refrain from coding in the codebehind of the UI class.
    * This enables better testability and separation of UI from User interaction and Business Logic.
    * 
    * Consider :
    * a) https://he.wikipedia.org/wiki/Model_View_Controller
    * b) https://en.wikipedia.org/wiki/Model%E2%80%93view%E2%80%93presenter
    * c) https://en.wikipedia.org/wiki/Model%E2%80%93view%E2%80%93viewmodel
    */
    public partial class CheapestBasketForm : Form
    {
        readonly PriceCompareManager _manager = new PriceCompareManager();


        public CheapestBasketForm()
        {
            InitializeComponent();
            AddProductsToComboBox();
        }
        //
        //Select Item Inputs
        //
        private void btnIncreaseAmount_Click(object sender, EventArgs e)
        {
            int amount = Convert.ToInt16(txtboxAmount.Text);
            amount++;
            txtboxAmount.Text = amount.ToString();
        }

        private void btnDecreaseAmount_Click(object sender, EventArgs e)
        {
            int amount = Convert.ToInt16(txtboxAmount.Text);
            if (amount == 1)
            {
                return;
            }
            amount--;
            txtboxAmount.Text = amount.ToString();
        }
        private void AddProductsToComboBox()
        {
            int i = 0;
            foreach (var pName in _manager.ProductList
                .Select(product => product.Name))
            {
                comboxItem.Items.Insert(i, pName);
                i++;
            }
        }
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (comboxItem.Text == "")
            {
                MessageBox.Show(Resources.PleaseEnterProductMsg);
                return;
            }
            _manager.UpdateItem(comboxItem.Text, int.Parse(txtboxAmount.Text));

            UpdateDgSelectedItems();

            ResetInputControls();
        }

        private void ResetInputControls()
        {
            txtboxAmount.Text = Resources.startedAmount;
            comboxItem.Text = null;
            comboxItem.Focus();
            btnCheckSuppliersPrices.Visible = true;
            lblSelectedItems.Visible = true;
        }
        //
        // Selected Item DataGrid
        //
        private void UpdateDgSelectedItems()
        {
            BindingSource bsource = new BindingSource { DataSource = _manager.GetSelectedItems() };
            dgSelectedItems.DataSource = bsource;
            dgSelectedItems.Columns[0].HeaderText = Resources.productName;
            dgSelectedItems.Columns[1].HeaderText = Resources.amount;

        }
        private void dgSelectedItems_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            comboxItem.Text = dgSelectedItems.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtboxAmount.Text = dgSelectedItems.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
        //
        //Caulculate Prices
        //
        private void btnCheckSuppliersPrices_Click(object sender, EventArgs e)
        {
            UpdateFinalPricesDg();
            UpdateTreeViewPrices();
            ShowAvailableControls();
        }
        private void UpdateFinalPricesDg()
        {
            var bsource1 = new BindingSource { DataSource = _manager.GetFinalPrices() };
            dgFinalPrices.DataSource = bsource1;

            dgFinalPrices.Columns[0].HeaderText = Resources.chainName;
            dgFinalPrices.Columns[1].HeaderText = Resources.basketPrice;
        }
        private void ShowAvailableControls()
        {

            btnExportToExcel.Visible = true;
            lblTreeviewTitle.Visible = true;
            treeViewPrices.Visible = true;
        }
        //
        //Tree View
        //
        private void UpdateTreeViewPrices()
        {
            treeViewPrices.Nodes.Clear();
            var dicList = _manager.GetHighLowPrices();

            var iSup = 0;
            foreach (var supplier in dicList)
            {
                var treeNode = new TreeNode(supplier.Key.Name);
                treeViewPrices.Nodes.Add(treeNode);
                treeViewPrices.Nodes[iSup].Nodes.Add(Resources.cheapest);
                treeViewPrices.Nodes[iSup].Nodes.Add(Resources.expensive);
                AddCheapestNodes(supplier, iSup);
                AddExpensiveNodes(supplier, iSup);

                iSup++;
            }
        }

        private void AddCheapestNodes(KeyValuePair<Supplier, List<Item>> supplier, int iSup)
        {
            for (var i = 0; i < supplier.Value.Count / 2; i++)
            {
                treeViewPrices.Nodes[iSup].Nodes[0].Nodes.Add(supplier.Value[i].Name + ": " + supplier.Value[i].Price + " שח");
            }
        }

        private void AddExpensiveNodes(KeyValuePair<Supplier, List<Item>> supplier, int iSup)
        {
            for (var i = supplier.Value.Count / 2; i < supplier.Value.Count; i++)
            {
                treeViewPrices.Nodes[iSup].Nodes[1].Nodes.Add(supplier.Value[i].Name + ": " + supplier.Value[i].Price + " שח");
            }
        }

        //
        //Export to Excel
        //
        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            Excel.Workbook wb;
            Excel.Worksheet ws;
            Excel.Application xlApp;
            object misValue;
            var excel = InitializeExcelObjects(out wb, out ws, out xlApp, out misValue);

            var exRow = BuildExTable(ws);

            BuildExChart(exRow, ws, misValue, wb, xlApp);
            excel.Visible = true;
        }

        private static Excel.Application InitializeExcelObjects(out Excel.Workbook wb, out Excel.Worksheet ws, out Excel.Application xlApp,
            out object misValue)
        {
            Excel.Application excel = new Excel.Application();
            wb = excel.Workbooks.Add(Excel.XlSheetType.xlWorksheet);
            ws = (Excel.Worksheet)excel.ActiveSheet;
            xlApp = new Excel.Application();
            misValue = System.Reflection.Missing.Value;
            return excel;
        }

        private int BuildExTable(Excel.Worksheet ws)
        {
            ws.Cells[1, 1] = Resources.chainName;
            ws.Cells[1, 2] = Resources.basketPrice;

            int exRow = 2;
            for (int j = 0; j <= dgFinalPrices.Rows.Count - 1; j++)
            {
                for (int i = 1; i <= 2; i++)
                {
                    ws.Cells[exRow, i] = dgFinalPrices.Rows[j].Cells[i - 1].Value;
                }
                exRow++;
            }
            return exRow;
        }

        private static void BuildExChart(int exRow, Excel.Worksheet ws, object misValue, Excel.Workbook wb, Excel.Application xlApp)
        {
            int exRowNum = exRow - 1;
            Excel.ChartObjects xlCharts = (Excel.ChartObjects)ws.ChartObjects(Type.Missing);
            Excel.ChartObject myChart = xlCharts.Add(10, 80, 300, 250);
            Excel.Chart chartPage = myChart.Chart;

            var chartRange = ws.Range["A1", "B" + exRowNum];
            chartPage.SetSourceData(chartRange, misValue);
            chartPage.ChartType = Excel.XlChartType.xlColumnClustered;

            ReleaseExcelObjects(ws, wb, xlApp);
        }

        private static void ReleaseExcelObjects(Excel.Worksheet ws, Excel.Workbook wb, Excel.Application xlApp)
        {
            ReleaseObject(ws);
            ReleaseObject(wb);
            ReleaseObject(xlApp);
        }

        private static void ReleaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show(Resources.ReleaseObject_Exception_Occured_while_releasing_object + ex);
            }
            finally
            {
                GC.Collect();
            }
        }

        //
        //Change Button Size
        //
        private void btnExportToExcel_MouseEnter(object sender, EventArgs e)
        {
            btnExportToExcel.Size = new Size(btnExportToExcel.Size.Width + 6, btnExportToExcel.Size.Height + 6);
            btnExportToExcel.Cursor = Cursors.Hand;
        }

        private void btnExportToExcel_MouseLeave(object sender, EventArgs e)
        {
            btnExportToExcel.Size = new Size(btnExportToExcel.Size.Width - 6, btnExportToExcel.Size.Height - 6);
            btnExportToExcel.Cursor = Cursors.Hand;
        }
        private void btnIncreaseAmount_MouseEnter(object sender, EventArgs e)
        {
            btnIncreaseAmount.Size = new Size(btnIncreaseAmount.Size.Width + 6, btnIncreaseAmount.Size.Height + 6);
            btnIncreaseAmount.Cursor = Cursors.Hand;
        }

        private void btnIncreaseAmount_MouseLeave(object sender, EventArgs e)
        {
            btnIncreaseAmount.Size = new Size(btnIncreaseAmount.Size.Width - 6, btnIncreaseAmount.Size.Height - 6);
            btnIncreaseAmount.Cursor = Cursors.Hand;
        }

        private void btnDecreaseAmount_MouseEnter(object sender, EventArgs e)
        {
            btnDecreaseAmount.Size = new Size(btnDecreaseAmount.Size.Width + 6, btnDecreaseAmount.Size.Height + 6);
            btnDecreaseAmount.Cursor = Cursors.Hand;
        }

        private void btnDecreaseAmount_MouseLeave(object sender, EventArgs e)
        {
            btnDecreaseAmount.Size = new Size(btnDecreaseAmount.Size.Width - 6, btnDecreaseAmount.Size.Height - 6);
            btnDecreaseAmount.Cursor = Cursors.Hand;
        }

        private void btnAddItem_MouseEnter(object sender, EventArgs e)
        {
            btnAddItem.Size = new Size(btnAddItem.Size.Width + 6, btnAddItem.Size.Height + 6);
            btnAddItem.Cursor = Cursors.Hand;
        }

        private void btnAddItem_MouseLeave(object sender, EventArgs e)
        {
            btnAddItem.Size = new Size(btnAddItem.Size.Width - 6, btnAddItem.Size.Height - 6);
            btnAddItem.Cursor = Cursors.Hand;
        }

        private void btnCheckSuppliersPrices_MouseEnter(object sender, EventArgs e)
        {
            btnCheckSuppliersPrices.Size = new Size(btnCheckSuppliersPrices.Size.Width + 6, btnCheckSuppliersPrices.Size.Height + 6);
            btnCheckSuppliersPrices.Cursor = Cursors.Hand;
        }

        private void btnCheckSuppliersPrices_MouseLeave(object sender, EventArgs e)
        {
            btnCheckSuppliersPrices.Size = new Size(btnCheckSuppliersPrices.Size.Width - 6, btnCheckSuppliersPrices.Size.Height - 6);
            btnCheckSuppliersPrices.Cursor = Cursors.Hand;
        }

    }
}
