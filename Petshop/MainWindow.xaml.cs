using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net.Mail;
using System.Net;

namespace Petshop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string Temporary_Password = "";
        string Username = "LuisOliver";
        string Password = "BG76";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Username_Box_GotFocus(object sender, RoutedEventArgs e)
        {
            if(Username_Box.Text == "Username")
            Username_Box.Text = "";
        }

        private void Username_Box_LostFocus(object sender, RoutedEventArgs e)
        {
            if(Username_Box.Text == "")
                Username_Box.Text = "Username";    
        }

        private void Password_Box_GotFocus(object sender, RoutedEventArgs e)
        { 
            if(Password_Box.Text == "Password")
            Password_Box.Text = "";
        }

        private void Password_Box_LostFocus(object sender, RoutedEventArgs e)
        {
            if(Password_Box.Text == "")
            Password_Box.Text = "Password";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(Password_Box.Text == Password && Username_Box.Text == Username)
            {
                Environment.Exit(0);
            }
            else
            {
                MessageBox.Show("Wrong username or password");
            }
        }

        private void Forgot_Password_Button_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            for(int i = 0; i < 5 ; i++) 
            {
                Temporary_Password += rnd.Next(1, 10);
            }
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("petshoppee1g@outlook.ph");
            mail.To.Add("luislabapis@gmail.com");
            mail.Subject = "goop";
            mail.Body = "idk i just need to check this";
            SmtpClient smtpServer = new SmtpClient("smtp.office365.com");
            smtpServer.Port = 587;
            smtpServer.Credentials = new NetworkCredential("petshoppee1g@outlook.ph", "PetShoppee123") as ICredentialsByHost;
            smtpServer.EnableSsl = true;

            smtpServer.Send(mail);
        }
    }
}
