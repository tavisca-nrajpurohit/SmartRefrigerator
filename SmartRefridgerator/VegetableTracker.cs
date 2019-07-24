using System.Collections.Generic;

namespace SmartRefrigerator
{
    public class VegetableTracker
    {
        public List<KeyValuePair<Vegetable, int>> GetInsufficientVegetableQuantity(List<KeyValuePair<Vegetable,int>> vegetableQuantity, ConfigurationManager configurationManager)
        {
            var InsufficientVegetables = new List<KeyValuePair<Vegetable, int>>();

            foreach(var item in vegetableQuantity)
            {
                if(item.Value <= configurationManager.GetMinimumQuantity(item.Key))
                {
                    InsufficientVegetables.Add(new KeyValuePair<Vegetable, int>(item.Key, item.Value));
                }
            }

            return InsufficientVegetables;
        }
    }
}
