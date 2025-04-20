using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Configuration;
using ims.Models;

namespace ims.Services
{
    public class EmailService
    {
        private readonly string _smtpServer;
        private readonly int _smtpPort;
        private readonly string _smtpUsername;
        private readonly string _smtpPassword;
        private readonly string _senderEmail;
        private readonly string _senderName;

        public EmailService()
        {
            _smtpServer = ConfigurationManager.AppSettings["SmtpServer"];
            _smtpPort = int.Parse(ConfigurationManager.AppSettings["SmtpPort"]);
            _smtpUsername = ConfigurationManager.AppSettings["SmtpUsername"];
            _smtpPassword = ConfigurationManager.AppSettings["SmtpPassword"];
            _senderEmail = ConfigurationManager.AppSettings["SenderEmail"];
            _senderName = ConfigurationManager.AppSettings["SenderName"];
        }

        private async Task SendEmailAsync(string to, string subject, string body, bool isHtml = true)
        {
            try
            {
                var client = new SmtpClient(_smtpServer, _smtpPort)
                {
                    EnableSsl = true,
                    Credentials = new NetworkCredential(_smtpUsername, _smtpPassword)
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(_senderEmail, _senderName),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = isHtml
                };
                mailMessage.To.Add(to);

                await client.SendMailAsync(mailMessage);
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Failed to send email: {ex.Message}");
                throw;
            }
        }

        public async Task SendSignupCodeAsync(string email, string code)
        {
            var subject = "IMS Account Registration";
            var body = $@"
                <html>
                <body>
                    <h2>Welcome to IMS!</h2>
                    <p>Your signup verification code is: <strong>{code}</strong></p>
                    <p>This code will expire in 24 hours.</p>
                </body>
                </html>";

            await SendEmailAsync(email, subject, body);
        }

        public async Task SendInvitationAsync(string email, string code, string inviterEmail)
        {
            var subject = "Invitation to IMS";
            var body = $@"
                <html>
                <body>
                    <h2>You've been invited to IMS!</h2>
                    <p>You've been invited by {inviterEmail} to join the IMS platform.</p>
                    <p>Your verification code is: <strong>{code}</strong></p>
                    <p>This code will expire in 24 hours.</p>
                </body>
                </html>";

            await SendEmailAsync(email, subject, body);
        }

        public async Task SendPasswordResetCodeAsync(string email, string code)
        {
            var subject = "IMS Password Reset";
            var body = $@"
                <html>
                <body>
                    <h2>Reset Your Password</h2>
                    <p>Your password reset code is: <strong>{code}</strong></p>
                    <p>This code will expire in 1 hour.</p>
                    <p>If you did not request this reset, please ignore this email.</p>
                </body>
                </html>";

            await SendEmailAsync(email, subject, body);
        }

        public async Task SendAccountDeletionNotificationAsync(string email)
        {
            var subject = "IMS Account Deleted";
            var body = $@"
                <html>
                <body>
                    <h2>Account Deleted</h2>
                    <p>Your IMS account has been deleted.</p>
                    <p>If you believe this was done in error, please contact your administrator.</p>
                </body>
                </html>";

            await SendEmailAsync(email, subject, body);
        }

        public async Task SendDeleteConfirmationCodeAsync(string email, string code, bool isOrganization)
        {
            var subject = isOrganization ?
                "Confirm Organization Deletion" :
                "Confirm Account Deletion";

            var body = $@"
                <html>
                <body>
                    <h2>{subject}</h2>
                    <p>Your confirmation code is: <strong>{code}</strong></p>
                    <p>This code will expire in 1 hour.</p>
                    <p>If you did not request this action, please contact support immediately.</p>
                </body>
                </html>";

            await SendEmailAsync(email, subject, body);
        }
    }
}