using System;

namespace SmartRefrigerator
{
    public class StorageFactory
    {
        public static IStorage GetStorage(string storageType)
        {
            switch(storageType)
            {
                case "inMemory":
                    return new InMemoryStorage();
                case "fileStorage":
                    throw new NotImplementedException();
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
