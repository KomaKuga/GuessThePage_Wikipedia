using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GuessThePage_Wikipedia.Logic.Entities;
using GuessThePage_Wikipedia.Logic.Servicies;


namespace GuessThePage_Wikipedia.Forms
{
    public partial class mainPage : Form
    {
        string playerName;
        GameLogic gameLogic = new GameLogic();
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
            this.Load += MainPage_Load;  // Subscribe here, since this is the actual constructor being used


        }

        private async void MainPage_Load(object sender, EventArgs e)
        {
            try
            {
                Article article = await gameLogic.GetRandomArticleFromCategory("");

                //MessageBox.Show($"Person: {article.Person}\nSummary: {article.TextBody}");

                textBodyLabel.Text = article.TextBody;
                personLabel.Text = article.Person;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading article: " + ex.Message);
            }
        }

        private void playerLabel_Click(object sender, EventArgs e)
        {

        }

        private void textBodyLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
