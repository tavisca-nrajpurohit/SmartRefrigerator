using System;
using Xunit;
using SmartRefrigerator;
using System.Collections.Generic;

namespace SmartRegrigerator.Test
{
    public class UnitTests
    {
        [Fact]
        public void RefrigeratorTestOne()
        {
            Refrigerator refrigerator = new Refrigerator();
            Tomato tomato = new Tomato();
            Cabbage cabbage = new Cabbage();
            LadyFinger ladyFinger = new LadyFinger();

            refrigerator.AddVegetable(tomato, 25);
            refrigerator.SetVegetableMinimumQuantity(tomato, 10);
            refrigerator.AddVegetable(cabbage, 10);
            refrigerator.SetVegetableMinimumQuantity(cabbage, 2);
            refrigerator.AddVegetable(ladyFinger, 7);
            refrigerator.SetVegetableMinimumQuantity(ladyFinger, 2);

            refrigerator.TakeOutVegetable(tomato, 20);

            var actualVegetableQuantity = refrigerator.CheckRefrigeratorContents();

            var expectedVegetableQuantity = new List<KeyValuePair<Vegetable, int>>();
            expectedVegetableQuantity.Add(new KeyValuePair<Vegetable, int>(tomato, 5));
            expectedVegetableQuantity.Add(new KeyValuePair<Vegetable, int>(cabbage, 10));
            expectedVegetableQuantity.Add(new KeyValuePair<Vegetable, int>(ladyFinger, 7));

            Assert.Equal(expectedVegetableQuantity, actualVegetableQuantity);
        }

        [Fact]
        public void RefrigeratorTestTwo()
        {
            Refrigerator refrigerator = new Refrigerator();
            Tomato tomato = new Tomato();
            Cabbage cabbage = new Cabbage();
            LadyFinger ladyFinger = new LadyFinger();

            refrigerator.AddVegetable(tomato, 25);
            refrigerator.SetVegetableMinimumQuantity(tomato, 10);
            refrigerator.AddVegetable(cabbage, 10);
            refrigerator.SetVegetableMinimumQuantity(cabbage, 2);
            refrigerator.AddVegetable(ladyFinger, 7);
            refrigerator.SetVegetableMinimumQuantity(ladyFinger, 2);

            refrigerator.TakeOutVegetable(tomato, 20);
            refrigerator.TakeOutVegetable(cabbage, 7);

            var actualVegetableQuantity = refrigerator.CheckRefrigeratorContents();

            var expectedVegetableQuantity = new List<KeyValuePair<Vegetable, int>>();
            expectedVegetableQuantity.Add(new KeyValuePair<Vegetable, int>(tomato, 5));
            expectedVegetableQuantity.Add(new KeyValuePair<Vegetable, int>(cabbage, 3));
            expectedVegetableQuantity.Add(new KeyValuePair<Vegetable, int>(ladyFinger, 7));

            Assert.Equal(expectedVegetableQuantity, actualVegetableQuantity);
        }

        [Fact]
        public void VegetableTrayAddTest()
        {
            VegetableTray vegetableTray = new VegetableTray();
            Tomato tomato = new Tomato();
            Cabbage cabbage = new Cabbage();
            LadyFinger ladyFinger = new LadyFinger();

            vegetableTray.Add(tomato, 25);
            vegetableTray.Add(cabbage, 30);
            vegetableTray.Add(ladyFinger, 7);

            var actualVegetableQuantity = vegetableTray.GetVegetableQuantity();

            var expectedVegetableQuantity = new List<KeyValuePair<Vegetable, int>>();
            expectedVegetableQuantity.Add(new KeyValuePair<Vegetable, int>(tomato, 25));
            expectedVegetableQuantity.Add(new KeyValuePair<Vegetable, int>(cabbage, 30));
            expectedVegetableQuantity.Add(new KeyValuePair<Vegetable, int>(ladyFinger, 7));

            Assert.Equal(expectedVegetableQuantity, actualVegetableQuantity);
        }


        [Fact]
        public void VegetableTrayTakeOutPositiveTest()
        {
            VegetableTray vegetableTray = new VegetableTray();
            Tomato tomato = new Tomato();
            Cabbage cabbage = new Cabbage();
            LadyFinger ladyFinger = new LadyFinger();

            vegetableTray.Add(tomato, 25);
            vegetableTray.TakeOut(tomato, 20);

            var actualVegetableQuantity = vegetableTray.GetVegetableQuantity();

            var expectedVegetableQuantity = new List<KeyValuePair<Vegetable, int>>();
            expectedVegetableQuantity.Add(new KeyValuePair<Vegetable, int>(tomato, 5));

            Assert.Equal(expectedVegetableQuantity, actualVegetableQuantity);
        }

        [Fact]
        public void VegetableTrayTakeOutExceptionTest()
        {
            VegetableTray vegetableTray = new VegetableTray();
            Tomato tomato = new Tomato();
            Cabbage cabbage = new Cabbage();
            LadyFinger ladyFinger = new LadyFinger();

            vegetableTray.Add(tomato, 25);

            var actualVegetableQuantity = vegetableTray.GetVegetableQuantity();

            Assert.Throws<VegetableNotFoundException>(()=> vegetableTray.TakeOut(cabbage, 20));

        }


        [Fact]
        public void VegetableTrackerTest()
        {
            VegetableTracker vegetableTracker = new VegetableTracker();
            ConfigurationManager configurationManager = new ConfigurationManager(StorageFactory.GetStorage("inMemory"));
            Tomato tomato = new Tomato();
            Cabbage cabbage = new Cabbage();
            LadyFinger ladyFinger = new LadyFinger();


            var vegetableQuantity = new List<KeyValuePair<Vegetable, int>>();
            vegetableQuantity.Add(new KeyValuePair<Vegetable, int>(tomato, 25));
            vegetableQuantity.Add(new KeyValuePair<Vegetable, int>(cabbage, 3));
            vegetableQuantity.Add(new KeyValuePair<Vegetable, int>(ladyFinger, 2));

            configurationManager.SetMinimumQuantity(tomato,5);
            configurationManager.SetMinimumQuantity(cabbage, 5);
            configurationManager.SetMinimumQuantity(ladyFinger, 5);

            var expectedInsufficientVegetables = new List<KeyValuePair<Vegetable, int>>();
            expectedInsufficientVegetables.Add(new KeyValuePair<Vegetable, int>(cabbage, 3));
            expectedInsufficientVegetables.Add(new KeyValuePair<Vegetable, int>(ladyFinger, 2));

            var actualInsufficientVegetables = vegetableTracker.GetInsufficientVegetableQuantity(vegetableQuantity,configurationManager);

            Assert.Equal(expectedInsufficientVegetables, actualInsufficientVegetables);
        }


        [Fact]
        public void StorageFactoryInMemoryTest()
        {
            var actualMemoryObject = StorageFactory.GetStorage("inMemory");
            Assert.IsType<InMemoryStorage>(actualMemoryObject);
        }

        [Fact]
        public void StorageFactoryFileStorageTest()
        {
            Assert.Throws<NotImplementedException>(() => StorageFactory.GetStorage("fileStorage"));
        }

        [Fact]
        public void StorageFactoryDefaultTest()
        {
            Assert.Throws<NotSupportedException>(() => StorageFactory.GetStorage("Any Other Data"));
        }

        [Fact]
        public void InMemoryStorageClassTest()
        {
            InMemoryStorage storage = new InMemoryStorage();
            Tomato tomato = new Tomato();
            storage.SetVegetableMinimumQuantity(tomato,5);
            Assert.Equal(5,storage.GetVegetableMinimumQuantity(tomato));
        }

        [Fact]
        public void ConfigurationManagerTest()
        {
            ConfigurationManager configurationManager = new ConfigurationManager(StorageFactory.GetStorage("inMemory"));
            Tomato tomato = new Tomato();
            configurationManager.SetMinimumQuantity(tomato,4);
            Assert.Equal(4, configurationManager.GetMinimumQuantity(tomato));
        }

        [Fact]
        public void NotificationFactoryEmailTest()
        {
            var actualEmailNotificationChannel = NotificationFactory.GetNotificationChannel("email");
            Assert.IsType<EmailNotification>(actualEmailNotificationChannel);            
        }

        [Fact]
        public void NotificationFactoryDefaultTest()
        {
            Assert.Throws<NotSupportedException>(() => NotificationFactory.GetNotificationChannel("postcard"));
        }

        [Fact]
        public void EmailNotificationAcknowledgeTest()
        {
            EmailNotification emailNotification = new EmailNotification();
            var acknowledgedResult = emailNotification.Acknowledge("Message!!!");
            Assert.Equal("True", acknowledgedResult);
        }
    }
}
