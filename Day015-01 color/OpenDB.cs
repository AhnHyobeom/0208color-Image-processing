using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Day015_01_color
{
    public partial class OpenDB : Form
    {
        String connStr = "Server=192.168.56.101;Uid=winuser;Pwd=4321;Database=image_db;Charset=UTF8";
        MySqlConnection conn; // 교량
        MySqlCommand cmd; // 트럭
        String sql = "";  // 물건박스
        MySqlDataReader reader; // 트럭이 가져올 끈
        const int RGB = 3, RR = 0, GG = 1, BB = 2;
        public OpenDB()
        {
            InitializeComponent();
        }
        private void OpenDB_Load(object sender, EventArgs e)
        {
            conn = new MySqlConnection(connStr);
            conn.Open();
            cmd = new MySqlCommand("", conn);
            sql = "SELECT i_id, i_fname, i_extname, i_width, i_height FROM image"; // 짐 싸기
            cmd.CommandText = sql;  // 짐을 트럭에 싣기
            reader = cmd.ExecuteReader(); // 짐을 서버에 부어넣고, 끈으로 묶어서 끈만 가져옴.
            int i_id, i_width, i_height;
            String i_fname, i_extname; // 톡!하고 땡겨올 짐을 담을 변수.
            String[] file_list = { };
            // 끈을 톡!하고 당기기
            while (reader.Read())
            {
                i_id = (int)reader["i_id"];
                i_fname = (String)reader["i_fname"];
                i_extname = (String)reader["i_extname"];
                i_width = (int)reader["i_width"];
                i_height = (int)reader["i_height"];
                String str = i_id + "/" + i_fname + "." + i_extname + "/" + i_width + "x" + i_height;
                Array.Resize(ref file_list, file_list.Length + 1); //배열크기 한개 증가
                file_list[file_list.Length - 1] = str;
            }
            reader.Close();
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(file_list);
        }
        private void OpenDB_FormClosed(object sender, FormClosedEventArgs e)
        {
            conn.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String selectStr = comboBox1.SelectedItem.ToString();
            int i_id = int.Parse(selectStr.Split('/')[0]);
            Form1.return_i_id = i_id;
            int i_width = int.Parse(selectStr.Split('/')[2].Split('x')[0]);
            int i_height = int.Parse(selectStr.Split('/')[2].Split('x')[1]);
            sql = "SELECT p_row, p_col, p_valueR, p_valueG, p_valueB FROM pixel WHERE i_id = " + i_id; // 짐 싸기
            cmd.CommandText = sql;  // 짐을 트럭에 싣기
            reader = cmd.ExecuteReader(); // 짐을 서버에 부어넣고, 끈으로 묶어서 끈만 가져옴.
            int row, col;
            Form1.dbImage = new byte[RGB, i_width, i_height];
            while (reader.Read())
            {
                row = int.Parse(reader["p_row"].ToString());
                col = int.Parse(reader["p_col"].ToString());
                Form1.dbImage[RR, row, col] = (byte)(int.Parse(reader["p_valueR"].ToString()));
                Form1.dbImage[GG, row, col] = (byte)(int.Parse(reader["p_valueG"].ToString()));
                Form1.dbImage[BB, row, col] = (byte)(int.Parse(reader["p_valueB"].ToString()));
            }
            reader.Close();
            this.DialogResult = DialogResult.OK;
        }
    }
}
