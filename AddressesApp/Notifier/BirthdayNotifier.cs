using System;
using System.Net;
using System.Net.Mail;
using AddressBooks;
using Quartz;
using Quartz.Util;

namespace AddressesApp.Notifier
{
    public class BirthdayNotifier : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            AddressBook addressBook = AddressBook.GetInstance();
            addressBook.BirthdayNotifierQuery();

            string emails = addressBook.ReturnValue;

            //Якщо сьогодні в когось з користувачів є День народження - надсилаємо повідомлення
            if (!emails.IsNullOrWhiteSpace())
            {
                try
                {
                    using (var message = new MailMessage("userbirthday.notifier@yandex.ua", emails))
                    {
                        message.Subject = "З Днем народження!";
                        message.Body = "Вітаємо з днем народження!";
                        using (SmtpClient sc = new SmtpClient())
                        {
                            //Використовуємо поштовий сервер Яндекс пошти
                            sc.EnableSsl = true;
                            sc.Host = "smtp.yandex.ua";
                            sc.Port = 587;
                            sc.DeliveryMethod = SmtpDeliveryMethod.Network;
                            sc.UseDefaultCredentials = false;
                            sc.Credentials = new NetworkCredential("userbirthday.notifier", "sg8dWlMo0JWDt#&");
                            sc.Send(message);
                        }
                    }
                    Console.WriteLine("Повідомлення з вітанням було надіслано наступним адресатам:\n" + emails);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            else
            {
                Console.WriteLine("Днів народження у користувачів сьогодні немає");
            }
        }
    }
}