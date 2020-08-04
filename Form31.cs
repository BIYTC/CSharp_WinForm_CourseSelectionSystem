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
    public partial class Form31 : Form
    {
        string SID;
        public Form31(string SID)
        {
            this.SID = SID;
            InitializeComponent();
        }
        private void Table()//让表显示数据
        {
            dataGridView1.Rows.Clear();//清空表内内容
            string sql = $"select * from 选课记录表 where SID='{SID}'";
            Dao dao = new Dao();
            dao.Connect();
            var dr = dao.ReadData(sql);

            while (dr.Read())
            {
                string CID = dr["CID"].ToString();
                string sql2 = $"select * from 课程表 where CID='{CID}'";

                var dr2 = dao.ReadData(sql2);
                dr2.Read();
                string a, b, c, d;
                a = dr2["CID"].ToString();
                b = dr2["Name"].ToString();
                c = dr2["学分"].ToString();
                d = dr2["Teacher"].ToString();
                string[] str = { a, b, c, d };
                dataGridView1.Rows.Add(str);
                dr2.Close();
            }
            dr.Close();
        }

        private void Form31_Load(object sender, EventArgs e)
        {
            Table();
        }

        private void 取消这门课ToolStripMenuItem_Click(object sender, EventArgs e)
        {              
            string CID = dataGridView1.SelectedCells[0].Value.ToString();
            string Name = dataGridView1.SelectedCells[1].Value.ToString();
            DialogResult r = MessageBox.Show($"确定要删除{Name}吗？", "提示", MessageBoxButtons.OKCancel);
            if (r == DialogResult.OK)
            {
                string sql3 = $"delete from 选课记录表 where CID='{CID}' and SID ='{SID}'";
                Dao dao = new Dao();
                dao.Connect();
                if (dao.AppendData(sql3))
                {
                    MessageBox.Show("删除成功");
                    Table();
                }
                else
                {
                    MessageBox.Show("删除失败", "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
                
        }
    }
}
