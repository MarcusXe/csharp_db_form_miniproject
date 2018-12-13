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
    public partial class Form2 : Form
    {
        string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\ANY_PROJECT\C#\Csharp_db_functions\WindowsFormsApp2\Database1.mdf;Integrated Security=True";
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();
            //字符串的拼接
            string sql = "select count(*) from mytable where"
                + " name=N'" + name + "' and password='" + password + "'";
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand(sql, con);
            //Form1 fr;
            try
            {
                con.Open();
                int n=0;
                //查询 ExecuteScalar返回结果集中的第一行第一列
                if (name != null && password != null)
                {
                    n = (int)cmd.ExecuteScalar();
                    if (n > 0)
                    {
                        // fr=
                        new Form1(this, name).Show();
                        con.Close();
                        this.Visible = false;
                        //fr.ti=""
                    }
                    else MessageBox.Show("请检查用户名密码!");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
