namespace SmartRefrigerator
{
    public class EmailNotification : INotificationChannel 
    {
        public void Notify(string message)
        {
            System.Console.WriteLine(message);
        }

        public string Acknowledge(string message)
        {
            System.Console.WriteLine(message);
            return "True";
        }
    }
}


