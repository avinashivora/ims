using System;
using System.Windows.Forms;
using ims.UI.Forms;
using ims.Utils;
using ims.Services;

namespace ims
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ShowLoginForm();
        }

        public static void ShowLoginForm()
        {
            using var loginForm = new LoginForm();
            // Subscribe to events
            loginForm.LoginSuccessful += (sender, e) =>
            {
                // Close the login form and run the main application
                ((Form)sender).DialogResult = DialogResult.OK;
            };

            loginForm.RegisterRequested += (sender, e) =>
            {
                // Open the register form
                using var registerForm = new RegisterForm(false);
                if (registerForm.ShowDialog() == DialogResult.OK)
                {
                    // If registration was successful, return to login form
                    MessageBox.Show("Registration successful!",
                        "Registration Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            };

            loginForm.InvitedUserRequested += (sender, e) =>
            {
                // Open the register form in invited user mode
                using var registerForm = new RegisterForm(true);
                if (registerForm.ShowDialog() == DialogResult.OK)
                {
                    // If registration was successful, return to login form
                    MessageBox.Show("Registration successful! You can now log in.",
                        "Registration Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            };

            loginForm.ResetPasswordRequested += (sender, e) =>
            {
                // Open the password reset form
                using var resetForm = new PasswordResetForm();
                resetForm.ShowDialog();
            };

            // Show the login form
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                // User successfully logged in, run the main application
                Application.Run(new MainForm());
            }
            else
            {
                // User canceled login or closed the form
                Application.Exit();
            }
        }
    }
}