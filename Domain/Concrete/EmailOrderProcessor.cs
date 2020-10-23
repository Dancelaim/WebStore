using WowCarry.Domain.Entities;

using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using WowCarry.Domain.Abstract;

namespace WowCarry.Domain.Concrete
{
    public class EmailSettings
    {
        public string MailToAddress = "orders@example.com";
        public string MailFromAddress = "gamestore@example.com";
        public bool UseSsl = true;
        public string Username = "MySmtpUsername";
        public string Password = "MySmtpPassword";
        public string ServerName = "smtp.example.com";
        public int ServerPort = 587;
        public bool WriteAsFile = true;
        public string FileLocation = @"c:\WowCarry_emails";
    }

    public class EmailOrderProcessor : IOrderProcessor
    {
        private EmailSettings emailSettings;

        public EmailOrderProcessor(EmailSettings settings)
        {
            emailSettings = settings;
        }

        public void ProcessOrder(Cart cart, OrderDetails orderDetails)
        {
            using (var smtpClient = new SmtpClient())
            {
                smtpClient.EnableSsl = emailSettings.UseSsl;
                smtpClient.Host = emailSettings.ServerName;
                smtpClient.Port = emailSettings.ServerPort;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials
                    = new NetworkCredential(emailSettings.Username, emailSettings.Password);

                if (emailSettings.WriteAsFile)
                {
                    smtpClient.DeliveryMethod
                        = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    smtpClient.PickupDirectoryLocation = emailSettings.FileLocation;
                    smtpClient.EnableSsl = false;
                }

                StringBuilder body = new StringBuilder()
                    .AppendLine("New Order")
                    .AppendLine("---")
                    .AppendLine("Products:");

                foreach (var line in cart.Lines)
                {
                    var subtotal = line.Product.ProductPrice.Select(p=>p.Price).FirstOrDefault() * line.Quantity;
                    body.AppendFormat("{0} x {1} (total: {2:c}",
                        line.Quantity, line.Product.ProductName, subtotal);
                }

                body.AppendFormat("Total Cost: {0:c}", cart.ComputeTotalValue())
                    .AppendLine("---")
                    .AppendLine("Details:")
                    .AppendLine(orderDetails.Email)
                    .AppendLine(orderDetails.Discord)
                    .AppendLine(orderDetails.BattleTag ?? "")
                    .AppendLine("---");

                MailMessage mailMessage = new MailMessage(
                                       emailSettings.MailFromAddress,	
                                       emailSettings.MailToAddress,		
                                       "Новый заказ отправлен!",		
                                       body.ToString()); 				

                if (emailSettings.WriteAsFile)
                {
                    mailMessage.BodyEncoding = Encoding.UTF8;
                }

                smtpClient.Send(mailMessage);
            }
        }
    }
}