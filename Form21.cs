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
    public partial class Form21 : Form
    {
        private string[] str = new string[5];

        public Form21()
        {
            InitializeComponent();
            button3.Visible = false;
        }
        public Form21(string[] a)
        {
            InitializeComponent();
            for (int i = 0; i < 5; i++)
            {
                str[i]= a[i];
            }
            textBox1.Text = str[0];
            textBox2.Text = str[1];
            textBox3.Text = str[2];
            textBox4.Text = str[3];
            textBox5.Text = str[4];
            button1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == ""|| textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                string sql = string.Format("Insert into 学生表 values('{0}','{1}','{2}','{3}','123456','{4}')", textBox1.Text, textBox2.Text,
                textBox3.Text, textBox4.Text, textBox5.Text);
                MessageBox.Show("存在空项！"+sql ,"提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                string sql = string.Format("Insert into 学生表 values('{0}','{1}','{2}','{3}','123456','{4}')", textBox1.Text, textBox2.Text,
                textBox3.Text, textBox4.Text, textBox5.Text);
                //MessageBox.Show(sql);
                Dao dao = new Dao();
                dao.Connect();
                if (dao.AppendData(sql))
                {
                    MessageBox.Show("插入成功！");
                    //textBox1.Text = null;
                    //textBox2.Text = null;
                    //textBox3.Text = null;
                    //textBox4.Text = null;
                    //textBox5.Text = null;
                    Close();
                }
                else
                {
                    MessageBox.Show("插入失败！");
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("存在空项！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);    
            }
            else
            {
                Dao dao = new Dao();
                dao.Connect();
                if (str[0]!=textBox1.Text)
                {
                    string sql = string.Format("update 学生表 set SID='{0}' where SID = '{1}' and Name ='{2}'",textBox1.Text,str[0],str[1]);
                    //MessageBox.Show(sql);
                    //Dao dao = new Dao();
                    //dao.Connect();
                    if (dao.AppendData(sql))
                    {
                        MessageBox.Show("SID修改成功！");
                        str[0] = textBox1.Text;
                    }
                    else
                    {
                        MessageBox.Show("SID修改失败！");
                    }
                }
                if (str[1] != textBox2.Text)
                {
                    string sql = string.Format("update 学生表 set Name='{0}' where SID = '{1}' and Name ='{2}'", textBox2.Text, str[0], str[1]);
                    //MessageBox.Show(sql);
                    //Dao dao = new Dao();
                    //dao.Connect();
                    if (dao.AppendData(sql))
                    {
                        MessageBox.Show("Name修改成功！");
                        str[1] = textBox2.Text;
                    }
                    else
                    {
                        MessageBox.Show("Name修改失败！");
                    }
                }
                if (str[2] != textBox3.Text)
                {
                    string sql = string.Format("update 学生表 set Class='{0}' where SID = '{1}' and Name ='{2}'", textBox3.Text, str[0], str[1]);
                    //MessageBox.Show(sql);
                    //Dao dao = new Dao();
                    //dao.Connect();
                    if (dao.AppendData(sql))
                    {
                        MessageBox.Show("Class修改成功！");
                        str[2] = textBox3.Text;
                    }
                    else
                    {
                        MessageBox.Show("Class修改失败！");
                    }
                }
                if (str[3] != textBox4.Text)
                {
                    string sql = string.Format("update 学生表 set Birthday='{0}' where SID = '{1}' and Name ='{2}'", textBox4.Text, str[0], str[1]);
                    ////MessageBox.Show(sql);
                    //Dao dao = new Dao();
                    //dao.Connect();
                    if (dao.AppendData(sql))
                    {
                        MessageBox.Show("Birthday修改成功！");
                        str[3] = textBox4.Text;
                    }
                    else
                    {
                        MessageBox.Show("Birthday修改失败！");
                    }
                }
                if (str[4] != textBox5.Text)
                {
                    string sql = string.Format("update 学生表 set 籍贯='{0}' where SID = '{1}' and Name ='{2}'", textBox5.Text, str[0], str[1]);
                    //MessageBox.Show(sql);
                    //Dao dao = new Dao();
                    //dao.Connect();
                    if (dao.AppendData(sql))
                    {
                        MessageBox.Show("籍贯修改成功！");
                        str[4] = textBox5.Text;
                    }
                    else
                    {
                        MessageBox.Show("籍贯修改失败！");
                    }
                }
                Close();
            }
        }

        private void Form21_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
    }
}
