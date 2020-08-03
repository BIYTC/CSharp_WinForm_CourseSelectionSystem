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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Dao dao;
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pictureBox1.Location.X<150)
            {
                pictureBox1.Location = new Point(pictureBox1.Location.X + 1, pictureBox1.Location.Y);
            }
            else
            {
                //dao.oleDb.Close();//及时关闭数据库！！！
                if (comboBox1.Text=="学生")
                {
                    string SID;
                    string sql = string.Format("SELECT SID FROM 学生表 " +
                     "WHERE(Name = '{0}') AND([PassWord] = '{1}')", textBox1.Text, textBox2.Text);
                    var dr = dao.ReadData(sql);
                    dr.Read();
                    SID = dr["SID"].ToString();
                    Form3 form3= new Form3(SID);
                    form3.Show();
                    this.Hide();
                    //this.Close();因为主窗体是Form1，所以不能关闭
                }
                else if (comboBox1.Text == "老师")
                {
                    Form2 form2 = new Form2();
                    form2.Show();
                    this.Hide();
                }
                else
                {
                    Form4 form4 = new Form4();
                    form4.Show();
                    this.Hide();
                }
                
                timer1.Stop();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (login())
            {
                timer1.Start();
                textBox1.Visible = false;
                textBox2.Visible = false;
                comboBox1.Visible = false;
                button1.Visible = false;
                button2.Visible = false;
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
            }
            else
            {
                MessageBox.Show("用户名或密码错误","错误", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }
        private bool login()
        {
            if (textBox1.Text==""||textBox2.Text==""||comboBox1.Text=="")
            {
                MessageBox.Show("输入不完整请检查","提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return false;
            }
            if (comboBox1.Text=="学生")
            {
                //string sql = "select * from 学生表 where Name = ''GaoHan' and PassWord='123456'";
                string sql = string.Format("SELECT  SID, Name, Class, Birthday, [PassWord], " +
                    "籍贯 FROM 学生表 " +
                    "WHERE(Name = '{0}') AND([PassWord] = '{1}')",textBox1.Text,textBox2.Text);
                var dr = dao.ReadData(sql);
                if(dr.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            if (comboBox1.Text == "老师")
            {
                string sql = string.Format("select * FROM 教师表 " +
                    "WHERE(Name = '{0}') AND([PassWord] = '{1}')", textBox1.Text, textBox2.Text);
                var dr = dao.ReadData(sql);
                if (dr.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            if (comboBox1.Text == "管理员")
            {
                if (textBox1.Text=="admin"&&textBox2.Text=="admin")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox2.Text = null;
            comboBox1.Text = null;
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dao = new Dao();
            if(dao.Connect())
            {
                MessageBox.Show("数据库连接成功！");
            }
            else
            {
                MessageBox.Show("数据库连接失败！", "错误", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }
    }
}
