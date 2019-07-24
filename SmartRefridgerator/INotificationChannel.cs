namespace SmartRefrigerator
{
    public interface INotificationChannel
    {
        void Notify(string message);

        string Acknowledge(string message);
    }
}
