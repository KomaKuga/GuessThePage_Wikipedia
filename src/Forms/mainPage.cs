using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuessThePage_Wikipedia.Forms
{
    public partial class mainPage : Form
    {
        string playerName;
        public mainPage()
        {
            InitializeComponent();
            

        }

        public mainPage(string playerName)
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None; // Remove window borders and title bar
            this.WindowState = FormWindowState.Maximized; // Maximize to full screen
            this.Text = "Enter your name"; // Set the title of the form
            this.playerName = playerName;
            playerLabel.Text = "Hello , " + playerName + "! Welcome to the game!";
        }
    }
}
