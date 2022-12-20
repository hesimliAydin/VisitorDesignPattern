using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorDesignPattern
{
    public class Program
    {

        //public interface INotificatonSender
        //{
        //    void Send(string message);
        //    void SetupEmail();
        //    void SetupText();
        //}

        //public class InvoiceNotificationSender : INotificatonSender
        //{
        //    public void Send(string message)
        //    {
        //        Console.WriteLine($"Notification sent:{message}");
        //    }

        //    public void SetupEmail()
        //    {
        //        Console.WriteLine("Setup email");
        //    }

        //    public void SetupText()
        //    {
        //        Console.WriteLine("Setup text");
        //    }
        //}

        //public class MarketingNotificationSender : INotificatonSender
        //{
        //    public void Send(string message)
        //    {
        //        Console.WriteLine($"Notification sent:{message}");
        //    }

        //    public void SetupEmail()
        //    {
        //        Console.WriteLine("Setup email");
        //    }

        //    public void SetupText()
        //    {
        //        Console.WriteLine("Setup text");
        //    }
        //}

        ////////////////////////////////////////////////////////////////////////////////////////////////////////


        public interface INotificatonSender
        {
            void Send(string message);
            void Accept(IVisitor visitor);
        }

        public interface IVisitor
        {
            void Visit(INotificatonSender notificatonSender);
        }

        public class EmailVisitor : IVisitor
        {
            public void Visit(INotificatonSender notificatonSender)
            {
                Console.WriteLine("Setup email");
            }
        }

       

        public class TextVisitor : IVisitor
        {
            public void Visit(INotificatonSender notificatonSender)
            {
                Console.WriteLine("Setup text");
            }
        }



        public class InvoiceNotificationSender : INotificatonSender
        {
            public void Accept(IVisitor visitor)
            {
                visitor.Visit(this);
            }

            public void Send(string message)
            {
                Console.WriteLine($"Notification sent:{message}");
            }



            
        }

        public class MarketingNotificationSender : INotificatonSender
        {
            public void Accept(IVisitor visitor)
            {
                visitor.Visit(this);
            }

            public void Send(string message)
            {
                Console.WriteLine($"Notification sent:{message}");
            }

            
        }




        static void Main()
        {
            //var notificationSender1=new InvoiceNotificationSender();
            //notificationSender1.SetupEmail();
            //notificationSender1.SetupText();
            //notificationSender1.Send("Invoice");

            //var notificationSender2 = new MarketingNotificationSender();
            //notificationSender2.SetupEmail();
            //notificationSender2.SetupText();
            //notificationSender2.Send("Marketing");

            //////////////////////////////////////////////////////////////////////////

            var notificationSender1 = new InvoiceNotificationSender();
            var emailVisitor=new EmailVisitor();
            var textVisitor = new TextVisitor();

            notificationSender1.Accept(emailVisitor);
            notificationSender1.Accept(textVisitor);
            notificationSender1.Send("Invoice");

            var notificationSender2 = new MarketingNotificationSender();
            notificationSender2.Accept(emailVisitor);
            notificationSender2.Accept(textVisitor);
            notificationSender2.Send("Marketing");
        }
    }
}
