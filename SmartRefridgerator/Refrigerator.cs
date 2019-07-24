using System.Collections.Generic;

namespace SmartRefrigerator
{
    public class Refrigerator
    {
        private VegetableTray _vegetableTray = new VegetableTray();
        private ConfigurationManager _configurationManager = new ConfigurationManager(StorageFactory.GetStorage("inMemory"));
        private VegetableTracker _vegetableTracker = new VegetableTracker();
        private OrderManager _orderManager = new OrderManager();

        public void AddVegetable(Vegetable vegetable, int quantity)
        {
            _vegetableTray.Add(vegetable, quantity);
        }

        public void SetVegetableMinimumQuantity(Vegetable vegetable, int minimumQuantity)
        {
            _configurationManager.SetMinimumQuantity(vegetable, minimumQuantity);
        }

        public void TakeOutVegetable(Vegetable vegetable, int quantity)
        {
            _vegetableTray.TakeOut(vegetable,quantity);

            var vegetableQuantity = _vegetableTray.GetVegetableQuantity();
            var insufficientVegetables = _vegetableTracker.GetInsufficientVegetableQuantity(vegetableQuantity,_configurationManager);
            _orderManager.OrderVegetables(insufficientVegetables);
        }

        public List<KeyValuePair<Vegetable, int>> CheckRefrigeratorContents()
        {
            var vegetableQuantity = _vegetableTray.GetVegetableQuantity();
            return vegetableQuantity;
        }
    }
}
