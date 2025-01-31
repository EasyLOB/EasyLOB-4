﻿using EasyLOB.Resources;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System;

namespace EasyLOB.Extensions.Mail
{
    public partial class MailManager : IMailManager
    {
        #region Properties

        public string FromName { get; private set; }

        public string FromAddress { get; private set; }

        public string UserName { get; private set; }

        public string Password { get; private set; }

        #endregion Properties

        #region Methods Interface

        public void Mail(string toAddress,
            string subject, string body, bool isHtml = false)
        {
            Mail(null, toAddress,
                subject, body, isHtml);
        }

        public void Mail(string toName, string toAddress,
            string subject, string body, bool isHtml = false, string[] fileAttachmentPaths = null)
        {
            toName = toName ?? "";
            toAddress = toAddress ?? "";
            subject = subject ?? "";
            body = body ?? "";

            if (string.IsNullOrEmpty(toAddress))
            {
                throw new Exception(string.Format(ErrorResources.EMailInvalidTo, toAddress));
            }

            string fromName = null;
            if (!string.IsNullOrEmpty(FromName))
            {
                fromName = FromName;
            }

            string fromAddress;
            if (!string.IsNullOrEmpty(FromAddress))
            {
                fromAddress = FromAddress;
            }
            else
            {
                fromAddress = ConfigurationHelper.AppSettings<string>("EasyLOB.Mail.FromAddress");
            }
            if (string.IsNullOrEmpty(fromAddress))
            {
                throw new Exception(string.Format(ErrorResources.EMailInvalidFrom, fromAddress));
            }

            MimeMessage message = new MimeMessage();
            message.From.Add(new MailboxAddress(fromName, fromAddress));
            foreach (var address in toAddress.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
            {
                message.To.Add(new MailboxAddress(address));
            }
            message.Subject = subject;

            //if (isHtml)
            //{
            //    message.Body = new TextPart(TextFormat.Html)
            //    {
            //        Text = body
            //    };
            //}
            //else
            //{
            //    message.Body = new TextPart(TextFormat.Text)
            //    {
            //        Text = body
            //    };
            //}

            var builder = new BodyBuilder();

            if (isHtml)
            {
                builder.HtmlBody = body;
            }
            else
            {
                builder.TextBody = body;
            }

            if (fileAttachmentPaths != null)
            {
                foreach (string path in fileAttachmentPaths)
                {
                    builder.Attachments.Add(path);
                }
            }

            message.Body = builder.ToMessageBody();

            Mail(message);
        }

        public void Set(string fromName = null,
            string fromAddress = null,
            string userName = null,
            string password = null)
        {
            FromName = fromName;
            FromAddress = fromAddress;
            UserName = userName;
            Password = password;
        }

        #endregion Methods Interface

        #region Methods MailKit

        private void Mail(MimeMessage message)
        {
            if (message != null)
            {
                string host = ConfigurationHelper.AppSettings<string>("EasyLOB.Mail.Host");
                int port = ConfigurationHelper.AppSettings<int>("EasyLOB.Mail.Port");
                string userName = ConfigurationHelper.AppSettings<string>("EasyLOB.Mail.UserName");
                string password = ConfigurationHelper.AppSettings<string>("EasyLOB.Mail.Password");
                bool ssl = ConfigurationHelper.AppSettings<bool>("EasyLOB.Mail.SSL");

                Mail(message,
                    host, port, userName, password, ssl);
            }
        }

        private void Mail(MimeMessage message,
            string host, int port, string userName, string password, bool ssl)
        {
            host = host ?? "";
            userName = userName ?? "";
            password = password ?? "";

            if (!string.IsNullOrEmpty(UserName))
            {
                userName = UserName;
                password = Password;
            }

            string toAddress = ConfigurationHelper.AppSettings<string>("EasyLOB.Mail.ToAddress");
            if (!string.IsNullOrEmpty(toAddress))
            {
                string[] addresses = toAddress.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                if (addresses.Length > 0)
                {
                    message.To.Clear();
                    foreach (var address in addresses)
                    {
                        message.To.Add(new MailboxAddress(address));
                    }
                }
            }

            // GMail
            // 465 = SSL
            // 587 = TLS
            // How do I access GMail using MailKit?
            // http://www.mimekit.net/docs/html/Frequently-Asked-Questions.htm#GMailAccess
            // Less Secure Accounts
            // https://myaccount.google.com/lesssecureapps
            SmtpClient smtp = new SmtpClient();
            //smtp.ServerCertificateValidationCallback = (s, c, h, e) => true;
            smtp.Connect(host, port, ssl ? SecureSocketOptions.Auto : SecureSocketOptions.None);
            //smtp.Connect(host, port, ssl); // SSL
            //smtp.Connect(host, port, SecureSocketOptions.StartTls); // TLS
            smtp.Authenticate(userName, password);
            smtp.Send(message);
            smtp.Disconnect(true);
        }

        #endregion Methods MailKit

        #region Methods IDispose

        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                }

                disposed = true;
            }
        }

        #endregion Methods IDispose
    }
}