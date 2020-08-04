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
    public partial class Form3 : Form
    {
        string SID;
        public Form3(string SID)
        {
            this.SID = SID;
            InitializeComponent();

        }
        public void Table()//让表显示数据
        {
            dataGridView1.Rows.Clear();//清空表内内容
            string sql = "select * from 课程表";
            Dao dao = new Dao();
            dao.Connect();
            var dr = dao.ReadData(sql);

            while (dr.Read())
            {
                string a, b, c, d;
                a = dr["CID"].ToString();
                b = dr["Name"].ToString();
                c = dr["Teacher"].ToString();
                d = dr["学分"].ToString();
                string[] str = { a, b, c, d };
                dataGridView1.Rows.Add(str);
            }
            dr.Close();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = $"欢迎学号为{SID}的同学登陆选课系统";
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();//结束整个程序
        }

        private void 选课ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string CID = dataGridView1.SelectedCells[0].Value.ToString();//获取选中课程的编号
            Dao dao = new Dao();
            dao.Connect();
            string sql1 = string.Format("select * from 选课记录表 where SID='{0}' and CID='{1}'", SID, CID);
            var dr = dao.ReadData(sql1);
            if (!dr.Read())
            {
                string sql = string.Format("Insert into 选课记录表 values('{0}','{1}')", SID, CID);
                if (dao.AppendData(sql))
                {
                    MessageBox.Show("选课成功");
                }
                else
                {
                    MessageBox.Show("选课失败", "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("不允许重复选课", "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            timer1.Start();
            Table();
        }

        private void 我的课程ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form31 f = new Form31(SID);
            f.Show();
        }
    }
}
