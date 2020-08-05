using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace demo
{
    public partial class Form41 : Form
    {
        private string[] a;

        public Form41()
        {
            InitializeComponent();
            button3.Visible = false;
        }

        public Form41(string[] a)
        {
            InitializeComponent();
            textBox1.Text = a[0];
            textBox4.Text = a[3];
            textBox2.Text = a[1];
            textBox3.Text = a[2];
            button1.Visible = false;
            this.a = a;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" )
            {
                string sql = string.Format("Insert into 教师表 values('{0}','{1}','{2}','{3}')", textBox1.Text, textBox2.Text,
                textBox3.Text, textBox4.Text);
                MessageBox.Show("存在空项！" + sql, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string sql = string.Format("Insert into 教师表 values('{0}','{1}','{2}','{3}')", textBox1.Text, textBox2.Text,
                textBox3.Text, textBox4.Text);
                //MessageBox.Show(sql);
                Dao dao = new Dao();
                dao.Connect();
                if (dao.AppendData(sql))
                {
                    MessageBox.Show("插入成功！");
                    textBox1.Text = null;
                    textBox2.Text = null;
                    textBox3.Text = null;
                    textBox4.Text = null;
                }
                else
                {
                    MessageBox.Show("插入失败！");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("存在空项！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string sql = string.Format($"delete from 教师表 where TID = '{a[0]}' and Name = '{a[1]}'");
                string sql1 = string.Format("Insert into 教师表 values('{0}','{1}','{2}','{3}')", textBox1.Text, textBox2.Text,
                    textBox3.Text, textBox4.Text);
                Dao dao = new Dao();
                dao.Connect();
                if (dao.AppendData(sql) && dao.AppendData(sql1))
                {
                    MessageBox.Show("修改成功！");
                    //textBox1.Text = null;
                    //textBox2.Text = null;
                    //textBox3.Text = null;
                    //textBox4.Text = null;
                    Close();
                }
                else
                {
                    MessageBox.Show("修改失败！");
                }
            }
            
        }
    }
}
