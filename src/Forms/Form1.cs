using GuessThePage_Wikipedia.Forms;

namespace GuessThePage_Wikipedia
{
    public partial class Form1 : Form
    {
        string userInput;
        public Form1()
        {
            InitializeComponent();
            

            errorLabel.Text = "";
            this.FormBorderStyle = FormBorderStyle.None; // Remove window borders and title bar
            this.WindowState = FormWindowState.Maximized; // Maximize to full screen
            this.Text = "Enter your name"; // Set the title of the form

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void startClick(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(nameTextBox.Text))
            {
                
                errorLabel.Text = "Please enter a name.";
                return;
            }
            else
            {
                errorLabel.Text = "";
                userInput = nameTextBox.Text;
                mainPage mainPage = new mainPage(userInput);
                mainPage.Show();
                this.Hide();

            }
        }
    }
}
