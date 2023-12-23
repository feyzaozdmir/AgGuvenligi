using System;
using System.Windows.Forms;

namespace şifreleme
{
    public partial class Form1 : Form
    {
        SifreleveCoz Sifrele = new SifreleveCoz();
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonsifreleme_Click(object sender, EventArgs e)
        {
            textBox2.Text = Sifrele.sifrele(textBox1.Text);
            
        }

        private void buttoncozumle_Click(object sender, EventArgs e)
        {
            
            if(textBox2.Text == string.Empty)
            {
                MessageBox.Show("Çözümlenecek Şifre YOK!");
            }
            else
            {
                textBox3.Text = Sifrele.sifre_Coz(textBox2.Text);

            }
        }
    }
}
