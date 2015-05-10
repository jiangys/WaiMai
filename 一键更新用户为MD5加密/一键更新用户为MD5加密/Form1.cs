using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 一键更新用户为MD5加密
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;//ConfigurationManager.AppSettings["connStr"];

        private void button1_Click(object sender, EventArgs e)
        {
            string strSQL = "select * from [user]";
            string strNonQuery = string.Empty;
            var reader = DBUtility.SqlHelper.ExecuteReader(ConnectionString, CommandType.Text, strSQL);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string pwd = reader.GetString(2);
                    var decrypt = Security.UEncypt.DESDecrypt(pwd);
                    var md5 = Security.UEncypt.MD5(decrypt);
                    strNonQuery = "update [user] set [Password]='" + md5 + "' where UserID=" + id;
                    DBUtility.SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, strNonQuery);
                }
            }
            MessageBox.Show("更新成功");
        }

    }
}
