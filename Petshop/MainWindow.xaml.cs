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
        private string actualPassword = "";
        private bool showPassword = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Username_Box_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Username_Box.Text == "Username    ")
            {
                Username_Box.Text = "";
                Username_Box.Foreground = Brushes.Black;
            }
        }
        private void Username_Box_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Username_Box.Text))
            {
                Username_Box.Text = "Username    ";
                Username_Box.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF8F8FB3"));
            }
        }

        private void Password_Box_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Password_Box.Text == "Password    ")
            {
                Password_Box.Text = "";
                Password_Box.Foreground = Brushes.Black;
            }
        }

        private void Password_Box_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Password_Box.Text))
            {
                Password_Box.Text = "Password    ";
                Password_Box.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF8F8FB3"));
                actualPassword = "";
            }
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Username_Box.IsFocused || Password_Box.IsFocused)
            {
                FocusManager.SetFocusedElement(this, this);
            }
        }

        private void Forgot_Password_Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Actual Password: " + actualPassword);

            //Random rnd = new Random();
            //for(int i = 0; i < 5 ; i++) 
            //{
            //    Temporary_Password += rnd.Next(1, 10);
            //}
            //MailMessage mail = new MailMessage();
            //mail.From = new MailAddress("petshoppee1g@outlook.ph");
            //mail.To.Add("jamikosmorales18@gmail.com");
            //mail.Subject = "Temporary Password";
            //mail.Body = "idk i just need to check this";
            //SmtpClient smtpServer = new SmtpClient("smtp.office365.com");
            //smtpServer.Port = 587;
            //smtpServer.Credentials = new NetworkCredential("petshoppee1g@outlook.ph", "PetShoppee123") as ICredentialsByHost;
            //smtpServer.EnableSsl = true;

            //smtpServer.Send(mail);
        }
        private void Forgot_Password_Button_MouseEnter(object sender, MouseEventArgs e)
        {
            Forgot_Password_Button.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF0000FF"));
        }
        private void Forgot_Password_Button_MouseLeave(object sender, MouseEventArgs e)
        {
            Forgot_Password_Button.Foreground = Brushes.Black;
        }

        private void Login_Button_Click(object sender, RoutedEventArgs e)
        {
            //if (Password_Box.Text == Password && Username_Box.Text == Username)
            //{
            //    Environment.Exit(0);
            //}
            //else
            //{
            //    MessageBox.Show("Wrong username or password");
            //}
        }

        private void Password_Box_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space || e.Key == Key.Enter)
            {
                e.Handled = true;
            }
            else if (e.Key == Key.Back && !showPassword)
            {
                if (Password_Box.SelectionStart == Password_Box.Text.Length && actualPassword.Length > 0)
                {
                    actualPassword = actualPassword.Substring(0, actualPassword.Length - 1);
                }
                else
                {
                    e.Handled = true;
                }
            }
        }
        private void Password_Box_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (showPassword)
                actualPassword = Password_Box.Text;
        }

        private void Password_Box_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!showPassword)
            {
                e.Handled = true;
                actualPassword += e.Text;
                UpdateDisplayedPassword();
            }
        }

        private void UpdateDisplayedPassword()
        {
            if (showPassword)
            {
                Password_Box.Text = actualPassword;
            }
            else if (Password_Box.Text != "Password    ")
            {
                Password_Box.Text = new string('●', actualPassword.Length);
                Password_Box.SelectionStart = Password_Box.Text.Length;
            }
        }

        private void ShowPassword_Checked(object sender, RoutedEventArgs e)
        {
            showPassword = true;
            if (Password_Box.Text != "Password    ")
                UpdateDisplayedPassword();
        }

        private void ShowPassword_Unchecked(object sender, RoutedEventArgs e)
        {
            showPassword = false;
            if (Password_Box.Text != "Password    ")
                UpdateDisplayedPassword();
        }
    }
}
