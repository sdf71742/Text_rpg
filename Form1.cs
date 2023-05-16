using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // 복사 필수

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            int k = 1;
            if (namebox.Text == "")
            {
                MessageBox.Show("이름을 입력해주세요");
            }
            else
            {
                if (k == 0)
                {
                    character character = new character();
                    character.name = namebox.Text;
                    Form2 form2 = new Form2(ref character);
                    this.Hide();
                    form2.ShowDialog();
                    this.Show();
                }
                else
                {
                    character character = new character();
                    character.name = namebox.Text;
                    C_1_0 form2 = new C_1_0(ref character);
                    this.Hide();
                    form2.ShowDialog();
                    this.Show();
                }
                
            }
        }
    }
}
