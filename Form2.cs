using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace demo
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            timer1.Start();
            Table();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();//结束整个程序
        }
        public void Table()//让表显示数据
        {
            dataGridView1.Rows.Clear();//清空表内内容
            string sql = "select * from 学生表";
            Dao dao = new Dao();
            dao.Connect();
            var dr = dao.ReadData(sql);
            
            while (dr.Read())
            {
                string a, b, c, d, e;
                a = dr["SID"].ToString();
                b = dr["Name"].ToString();
                c = dr["Class"].ToString();
                d = dr["Birthday"].ToString();
                e = dr["籍贯"].ToString();
                string[] str = { a, b, c, d, e };
                dataGridView1.Rows.Add(str);
            }
            dr.Close();
        }

        private void 添加学生信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form21 f = new Form21();
            f.ShowDialog();
            Table();
        }

        private void 修改学生信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] str = {dataGridView1.SelectedCells[0].Value.ToString(),
            dataGridView1.SelectedCells[1].Value.ToString(),
            dataGridView1.SelectedCells[2].Value.ToString(),
            dataGridView1.SelectedCells[3].Value.ToString(),
            dataGridView1.SelectedCells[4].Value.ToString()};
            Form21 f = new Form21(str);
            f.ShowDialog();
            Table();
        }

        private void 删除学生信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("确定要删除吗？","提示",MessageBoxButtons.OKCancel);
            if (r==DialogResult.OK)
            {
                string id, name;
                id = dataGridView1.SelectedCells[0].Value.ToString();
                name = dataGridView1.SelectedCells[1].Value.ToString();
                string sql = string.Format("delete from 学生表 where SID='{0}' and Name='{1}'", id, name);
                Dao dao = new Dao();
                dao.Connect();
                dao.AppendData(sql);
                dao.oleDb.Close();
                Table();
            }
            
        }

        private void flash_Click(object sender, EventArgs e)
        {
            Table();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();//结束整个程序
        }
    }
}
