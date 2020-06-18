using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Level02
{
    public partial class Form1 : Form
    {
        DataSet m_dsMainGrid = new DataSet();

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            // output.Text = "ปีที่ 1 \r\n ปีที่ 2";
            Int32 year = 1;
            //Int32 StartMoney = 100000;
            Int64[] StartMoney = new Int64[21];
            Int64[] Profitbaht = new Int64[21];
            Int64 profitPersent = 1;
            Int64[] EndOfYearMoney = new Int64[21];

            int CouterArray = 0;
            String STROUTPUT = "";

            Int32 inputStartMoney = 0;
            int checkerror = 0;

            //check error funtion
            try
            {
                //convert texbox to INT32
                inputStartMoney = Convert.ToInt32(tbstart.Text);
            }
            catch (Exception)
            {
                checkerror = -1;
                MessageBox.Show("Input data number only", "Error!!!", MessageBoxButtons.OK);
            }

            if (checkerror == 0)
            {
                DateTime startTime = System.DateTime.Now;
                // กำหนดให้เป็นค่าว่างเพื่อเตรียมรอแสดงผลทีเดียว
                //output.Text = "";
                //lboutput.BeginUpdate();
                //lboutput.Items.Clear();

                //// List<string> outPut = new List<string>();

                //STROUTPUT += "";
                ////for (year=1; year <= 100;year++)
                ////{
                ////    output.Text  += "ปี = " + year.ToString() + "\r\n";
                ////   // output.Text = output.Text + "ปี = "+year.ToString()+ "\r\n";
                ////}
                //year = 1;
                //while (year <= 50)
                //{
                //    STROUTPUT = "";
                //    STROUTPUT += "ปี = " + year.ToString("N0");
                //    profitPersent = 5;
                //    CouterArray = 0;
                //    while (profitPersent <= 50)
                //    {
                //        if (year == 1)
                //        {

                //            StartMoney[CouterArray] = inputStartMoney;
                //        }

                //        Profitbaht[CouterArray] = (Int32)((Decimal)(StartMoney[CouterArray]) * (Decimal)(profitPersent) / (Decimal)(100));
                //        EndOfYearMoney[CouterArray] = StartMoney[CouterArray] + Profitbaht[CouterArray];

                //        STROUTPUT += "{" +
                //    ": เงินต้นปี = " + StartMoney[CouterArray].ToString("N0") +
                //    " : กำไล " + profitPersent.ToString("N0") + "% = " + Profitbaht[CouterArray].ToString("N0") +
                //    " : เงินปลายปี = " + EndOfYearMoney[CouterArray].ToString("N0") +
                //        "}";

                //        StartMoney[CouterArray] = EndOfYearMoney[CouterArray];
                //        profitPersent += 5;
                //        CouterArray++;
                //    }

                //    STROUTPUT += "\r\n";



                //    /*output.Text += "ปี = " + year.ToString("N0") + 
                //    ": เงินต้นปี = "+ StartMoney.ToString("N0") +
                //    " : กำไล "+ profitPersent.ToString("N0") + "% = "+ Profitbaht.ToString("N0") +
                //    " : เงินปลายปี = " + EndOfYearMoney.ToString("N0") +                                
                //        "\r\n";
                //    StartMoney = EndOfYearMoney; */

                //    year++;

                //    lboutput.Items.Add(STROUTPUT);
                //    //outPut.Add(STROUTPUT);

                //}
                ////กำหนดให้แสดงผลทีเดียวเพื่อลดการ refash หน้าจอทำให้แสดงผลไว
                ////output.Text = STROUTPUT;

                ////  lboutput.DataSource = outPut;

                //lboutput.EndUpdate();


                //Insert to DataGridView

                DataTable myDataTable = m_dsMainGrid.Tables["MainGrid"];
                DataRow NewDataRow;
                string ColoumnName = "";

                      
                year = 1;
                while (year <= 100)
                {

                    NewDataRow = myDataTable.NewRow();
                    NewDataRow["ปีที่"] = year;


                    profitPersent = 5;
                    CouterArray = 0;
                    while (profitPersent <= 50)
                    {
                        if (year == 1)
                        {

                            StartMoney[CouterArray] = inputStartMoney;
                        }

                        Profitbaht[CouterArray] = (Int64)((Decimal)(StartMoney[CouterArray]) * (Decimal)(profitPersent) / (Decimal)(100));
                        EndOfYearMoney[CouterArray] = StartMoney[CouterArray] + Profitbaht[CouterArray];


                        ColoumnName = "เงินต้นปี (" + profitPersent.ToString() + "%)";
                        NewDataRow[ColoumnName] = StartMoney[CouterArray];

                        ColoumnName = "กำไล (" + profitPersent.ToString() + "%)";
                        NewDataRow[ColoumnName] = Profitbaht[CouterArray];

                        ColoumnName = "เงินปลายปี (" + profitPersent.ToString() + "%)";
                        NewDataRow[ColoumnName] = EndOfYearMoney[CouterArray];

                        StartMoney[CouterArray] = EndOfYearMoney[CouterArray];
                        profitPersent += 5;
                        CouterArray++;
                    }

                    myDataTable.Rows.Add(NewDataRow);
                    year++;

                   

                }
               

                DateTime endTime = System.DateTime.Now;
                System.TimeSpan usetime = endTime - startTime;



               // MessageBox.Show("usrTime :" + usetime.TotalSeconds.ToString() + "วินาที :");



            }

        }


        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        //select all tab order in texbox
        private void tbstart_Enter(object sender, EventArgs e)
        {
            tbstart.SelectAll();
        }

        private void tbstart_KeyPress(object sender, KeyPressEventArgs e)
        {

            //Set focus
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                tbInvestPeerMonth.Focus();
            }
            //check text box number only                 // ยอมให้ Backspace ทำงาน \b ||8
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void tbInvestPeerMonth_Enter(object sender, EventArgs e)
        {
            tbInvestPeerMonth.SelectAll();
        }

        private void tbInvestPeerMonth_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Set Focus
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                tbstart.Focus();
            }
            //check text box number only                 // ยอมให้ Backspace ทำงาน \b ||8
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        //CheckBox format Type
        private void tbstart_Leave(object sender, EventArgs e)
        {
            Int32 Inputstartmoney = 0;

            try
            {
                Inputstartmoney = Convert.ToInt32(tbstart.Text);
            }
            catch (Exception Error)
            {

                MessageBox.Show("Incorect fomat");
                //tbstart.Text = "";
            }
        }

        private void tbInvestPeerMonth_Leave(object sender, EventArgs e)
        {
            Int32 InputInvespeerMonth = 0;
            try
            {
                InputInvespeerMonth = Convert.ToInt32(tbInvestPeerMonth.Text);
            }
            catch (Exception Error)
            {
                MessageBox.Show("Incorect fomat");
                //tbstart.Text = "";
            }
        }

        private void lboutput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 3) //control c
            {
                Copyclick();

            }
            else if (e.KeyChar == 1) //control A
            {
                SelectAllRowclick();
            }
        }

        //copy text for listBox
        private void Copyclick()
        {
            // String Copytext = "";
            StringBuilder CopyText = new StringBuilder("");

            foreach (object DataRow in lboutput.SelectedItems)
            {
                CopyText.Append(DataRow.ToString());
                //CopyText.Append("\r \n");
                CopyText.AppendLine();
            }
            CopyText.Remove(CopyText.Length - 1, 1);
            Clipboard.SetText(CopyText.ToString());
        }

        private void SelectAllRowclick()
        {
            lboutput.BeginUpdate();
            for (int i = 0; i < lboutput.Items.Count; i++)
            {
                lboutput.SetSelected(i, true);
            }
            lboutput.EndUpdate();
        }

        private void ctCopy_Click(object sender, EventArgs e)
        {
            Copyclick();
        }

        private void ctSelect_Click(object sender, EventArgs e)
        {
            SelectAllRowclick();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            GridColumn();
        }

        private void GridColumn()
        {
            //DataGridViewColumn myDataGridViewColumn = new DataGridViewColumn();
            //DataGridViewTextBoxCell myDataGridViewTextBoxCell = new DataGridViewTextBoxCell();
            //myDataGridViewColumn.CellTemplate = myDataGridViewTextBoxCell;
            //myDataGridViewColumn.Name = "ปีที่";
            //DTG01.Columns.Add(myDataGridViewColumn);

            DataTable myDataTable = new DataTable("MainGrid");
            m_dsMainGrid.Tables.Add(myDataTable);
            DataColumn myDataColumn;

            int ProfitPercent = 5;

            myDataColumn = new DataColumn();
            myDataColumn.DataType = System.Type.GetType("System.Int32");
            myDataColumn.ColumnName = "ปีที่";
            myDataTable.Columns.Add(myDataColumn);

            while (ProfitPercent <= 50)
            {

                myDataColumn = new DataColumn();
                myDataColumn.DataType = System.Type.GetType("System.Int64");
                myDataColumn.ColumnName = "เงินต้นปี (" + ProfitPercent.ToString() + "%)";
                myDataTable.Columns.Add(myDataColumn);

                myDataColumn = new DataColumn();
                myDataColumn.DataType = System.Type.GetType("System.Int64");
                myDataColumn.ColumnName = "กำไล (" + ProfitPercent.ToString() + "%)";
                myDataTable.Columns.Add(myDataColumn);

                myDataColumn = new DataColumn();
                myDataColumn.DataType = System.Type.GetType("System.Int64");
                myDataColumn.ColumnName = "เงินปลายปี (" + ProfitPercent.ToString() + "%)";
                myDataTable.Columns.Add(myDataColumn);

                ProfitPercent += 5;

            }

            DTG01.DataSource = m_dsMainGrid.Tables["MainGrid"];
        }
    }
}
