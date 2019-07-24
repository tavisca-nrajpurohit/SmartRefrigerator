using System.Collections.Generic;

namespace SmartRefrigerator
{
    public class OrderManager
    {
        INotificationChannel _notificationChannel = NotificationFactory.GetNotificationChannel("email");
        public void OrderVegetables(List<KeyValuePair<Vegetable, int>> insufficientVegetables)
        {
            // updating stock in the refrigerator
            _notificationChannel.Notify("Order Placed!");
        }
    }
}
