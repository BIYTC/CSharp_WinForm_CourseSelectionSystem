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
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();//结束整个程序
        }

        private void 选课ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string CID = dataGridView1.SelectedCells[0].Value.ToString();//获取选中课程的编号
            string sql = string.Format("Insert into 选课记录表 values('{0}','{1}')", SID, CID);
            Dao dao = new Dao();
            dao.Connect();
            if (dao.AppendData(sql))
            {
                MessageBox.Show("选课成功");
            }
            else
            {
                MessageBox.Show("选课失败", "失败", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
