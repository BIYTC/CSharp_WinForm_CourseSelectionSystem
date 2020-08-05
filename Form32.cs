using System;
using System.Windows.Forms;

namespace demo
{
    public partial class Form32 : Form
    {
        private string SID;

        public Form32(string SID)
        {
            this.SID = SID;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str1 = textBox1.Text;
            string str2 = textBox2.Text;
            if (str1==""||str2=="")
            {
                MessageBox.Show("密码不能为空！","错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(str1 != str2)
            {
                MessageBox.Show("密码不一致！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //这里的sql语句很奇怪，[PassWord]必须要加上[],否则sql语句语法错误！不知道为什么
                //string sql = string.Format($"UPDATE 学生表 SET [PassWord] = '{str2}' WHERE SID = '{SID}'");
                string sql = string.Format("update 学生表 set [PassWord]='{0}' where SID = '{1}'",str2, SID);
                
                Dao dao = new Dao();
                dao.Connect();
                if (dao.AppendData(sql))
                {
                    MessageBox.Show("密码修改成功！");
                    Close();
                }
                else
                {
                    MessageBox.Show("密码修改失败！");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox2.Text = null;
        }
    }
}
