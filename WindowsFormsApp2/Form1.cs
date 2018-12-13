using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        Form2 f2;
        string Uname = null;
        DataSet dset;
        SqlDataAdapter sda;
        public Form1(Form2 F2, string name)
        {
            InitializeComponent();
            f2 = F2;
            Uname = name;
        }

        protected override void OnClosed(EventArgs e)
        {
            f2.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //createDataSet();
            label3.Text = Uname;
            string sql = "select * from mytable";
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\ANY_PROJECT\C#\Csharp_db_functions\WindowsFormsApp2\Database1.mdf;Integrated Security=True";
            dset = new DataSet();
            SqlConnection scon = new SqlConnection(constr);
            //scon.Open();
            sda = new SqlDataAdapter(sql, scon);
            sda.Fill(dset);
            dataGridView1.DataSource = dset.Tables[0];
        }

        void createDataSet()
        {
            DataSet dset = new DataSet("det1");
            DataTable dtable = new DataTable("stud");
            DataColumn dc = new DataColumn("id");
            dtable.Columns.Add(dc);
            dc = new DataColumn("name");
            dtable.Columns.Add(dc);
            dc = new DataColumn("age");
            dtable.Columns.Add(dc);
            DataRow row1 = dtable.NewRow();
            row1[0] = "1";
            row1[1] = "Harry";
            row1[2] = 18;
            dtable.Rows.Add(row1);
            DataRow row2 = dtable.NewRow();
            row2[0] = "1";
            row2[1] = "Loeen";
            row2[2] = 17;
            dtable.Rows.Add(row2);
            dset.Tables.Add(dtable);
            dataGridView1.DataSource = dset.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\XEBY\source\repos\WindowsFormsApp2\WindowsFormsApp2\Database1.mdf;Integrated Security=True";
            string sql = "insert into mytable(name,password) values('xiao','20')";
            SqlConnection con = new System.Data.SqlClient.SqlConnection(constr);
            
            try
            {
                con.Open();
                MessageBox.Show("Successful!");
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = con;
                sqlcmd.CommandText = sql;
                int n = sqlcmd.ExecuteNonQuery();
                Console.WriteLine(n);

            }catch(Exception eq) {
                Console.WriteLine(eq);
            }
            finally
            {
                con.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sql = "select * from mytable";
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\XEBY\source\repos\WindowsFormsApp2\WindowsFormsApp2\Database1.mdf;Integrated Security=True";
            SqlConnection con = new System.Data.SqlClient.SqlConnection(constr);
            SqlCommand sqlcmd = new SqlCommand(sql, con);
            SqlDataReader dr = null;
            try
            {
                con.Open();
                //MessageBox.Show("Successful!");
                dr = sqlcmd.ExecuteReader();
                while (dr.Read())
                {
                    string name = dr.GetString(1);
                    string pwd = dr.GetString(2);
                    int id = dr.GetInt32(0);
                    Console.WriteLine("{0},{1} {2}", name, pwd, id);
                }
            }
            catch (Exception eq)
            {
                Console.WriteLine(eq);
            }
            finally
            {
                dr.Close();
                con.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string password = textBox2.Text;
            string sql = string.Format("select count(*) from mytable where name='{0}' and password='{1}'",name,password);
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\XEBY\source\repos\WindowsFormsApp2\WindowsFormsApp2\Database1.mdf;Integrated Security=True";
            SqlConnection con = new System.Data.SqlClient.SqlConnection(constr);
            SqlCommand sqlcmd = new SqlCommand(sql, con);
            try
            {
                con.Open();
                //MessageBox.Show("Successful!");
                string n = sqlcmd.ExecuteScalar().ToString();
                int x = Int32.Parse(n);
                if (x > 0)
                {
                    MessageBox.Show("su");
                }
                else
                {
                    MessageBox.Show("121");
                }
            }
            catch (Exception eq)
            {
                Console.WriteLine(eq);
            }
            finally
            {
                con.Close();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void button5_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text.Trim();
            string xb = textBox2.Text.Trim();
            string sql = "select * from mytable where 1=1";
            if (name != null && name != "")
            {
                sql = sql + " and name=N'" + name + "'";
            }
            if (xb != null && xb != "")
            {
                sql = sql + " and gendar='" + xb + "'";
            }
            //string sql = "select * from mytable where name =N'张三'";
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\ANY_PROJECT\C#\Csharp_db_functions\WindowsFormsApp2\Database1.mdf;Integrated Security=True";
            dset = new DataSet();
            SqlConnection scon = new SqlConnection(constr);
            //scon.Open();
            sda = new SqlDataAdapter(sql, scon);
            sda.Fill(dset);
            dataGridView1.DataSource = dset.Tables[0];
            sda.Update(dset.Tables[0]);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SqlCommandBuilder scb = new SqlCommandBuilder(sda);
            sda.Update(dset);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}