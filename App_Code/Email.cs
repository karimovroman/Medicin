using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Net.Mail;
using System.Net;

namespace Email
{
    public class Email
    {
        /// <summary>
        /// Отправка письма GOOGLE.COM
        /// </summary>
        /// <param name="from">
        /// От кого
        /// </param>
        /// <param name="to">
        /// Кому
        /// </param>
        /// <param name="subject">
        /// Тема
        /// </param>
        /// <param name="body">
        /// Тело письма (текст)
        /// </param>
        /// <returns>
        /// Сообщение о результате
        /// </returns>
        public string SendEmailGmail(string from, string to, string subject, string body)
        {
            if (body != "")
            {
                try
                {
                    SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential("medicinsystem@gmail.com", "medicin2015");
                    smtp.EnableSsl = true;
                    MailAddress mailfrom = new MailAddress(from);
                    MailAddress mailto = new MailAddress(to);
                    MailMessage msg = new MailMessage(mailfrom, mailto);
                    msg.Subject = subject;
                    msg.Body = body;
                    smtp.Send(msg);
                    return "Письмо отправлено " + to;
                }
                catch
                {
                    return "Не удалось отправить письмо";
                }
            }
            else
                return "Пустое сообщение";
        }
        /// <summary>
        /// Отправка письма YANDEX.RU
        /// </summary>
        /// <param name="from">
        /// От кого
        /// </param>
        /// <param name="to">
        /// Кому
        /// </param>
        /// <param name="subject">
        /// Тема
        /// </param>
        /// <param name="body">
        /// Тело письма (текст)
        /// </param>
        /// <returns>
        /// Сообщение о результате
        /// </returns>
        public string SendEmailYa(string from, string to, string subject, string body)
        {
            if (body != "")
            {
                try
                {
                    SmtpClient smtp = new SmtpClient("smtp.yandex.ru", 25);
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential("roman-kmail@yandex.ru", "Rom2010viktori");
                    smtp.EnableSsl = true;
                    MailAddress mailfrom = new MailAddress(from);
                    MailAddress mailto = new MailAddress(to);
                    MailMessage msg = new MailMessage(mailfrom, mailto);
                    msg.Subject = subject;
                    msg.Body = body;
                    smtp.Send(msg);
                    return "Письмо отправлено " + to;
                }
                catch
                {
                    return "Не удалось отправить письмо";
                }
            }
            else
                return "Пустое сообщение";
        }

    }

}