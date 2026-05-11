using CarRentalManagementSystem.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CarRentalManagementSystem.Forms
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {
            // Optional: any load-time initialization
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            {
                progressBar1.Increment(2);

                if (progressBar1.Value == 100)
                {
                    timer1.Stop();

                    CarRentalManagementSystem.Forms.LoginForm login =
                        new CarRentalManagementSystem.Forms.LoginForm();

                    login.Show();

                    this.Hide();
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}