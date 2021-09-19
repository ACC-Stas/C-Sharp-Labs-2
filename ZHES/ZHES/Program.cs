using System;
using ZHES.Collections;
using ZHES.Entities;
using ZHES.Exceptions;

namespace ZHES {
    class Program {
        static void Main(string[] args) {

            //testing MyCustomCollection
            MyCustomCollection<int> someCollection = new MyCustomCollection<int>();
            someCollection.Add(15); //testing add
            someCollection.Add(27);
            someCollection.Add(49);
            someCollection.Add(83);
            someCollection.Add(4);
            someCollection.Add(9);

            someCollection.Reset();
            for (int i = 0; i < someCollection.Count; i++) {
                Console.Write(someCollection.Current() + " ");
                someCollection.Next();
            }
            Console.WriteLine();


            try {
                someCollection.Remove(49); //testing remove
                someCollection.Remove(5);
            } catch (NoItemException<int> ex) {
                Console.WriteLine(ex.Message + $" {ex.Item}");
            }

            someCollection.Reset();
            for (int i = 0; i < someCollection.Count; i++) {
                Console.Write(someCollection.Current() + " ");
                someCollection.Next();
            }
            Console.WriteLine();

            someCollection.Reset();  //testing removecurrent
            someCollection.Next();
            someCollection.RemoveCurrent();
            someCollection.Reset();
            for (int i = 0; i < someCollection.Count; i++) {
                Console.Write(someCollection.Current() + " ");
                someCollection.Next();
            }
            Console.WriteLine();

            someCollection[3] = 149;  //testing indexator
            someCollection.Reset();
            for (int i = 0; i < someCollection.Count; i++) {
                Console.Write(someCollection.Current() + " ");
                someCollection.Next();
            }
            Console.WriteLine();

            Journal journal = new Journal();


            //testing ZHES
            HMS zhes = new HMS();
            zhes.NotifyLogersChange += delegate(Loger loger, bool insertion) { 
                if (insertion) {
                    journal.AddEvent("New Loger", loger.Name);
                } else {
                    journal.AddEvent("Remove Loger", loger.Name);
                }
            };
            zhes.NotifyRateChange += delegate (String fullname, Rate newRate) {
                journal.AddEvent("Change rate", $"Loger {fullname} acquired rate {newRate.Name}");
            };
            zhes.NotifyConsumptionChange += (String fullname, Consumable name, uint quantity) 
                => Console.WriteLine($"{fullname} consumed {quantity} of {name}");

            Rate rate1 = new Rate("Number1", new Tuple<Consumable, uint>(Consumable.Gas,65), 
                new Tuple<Consumable, uint>(Consumable.Electricity, 90), new Tuple<Consumable, uint>(Consumable.Whater, 15));
            Rate rate2 = new Rate("Number2", new Tuple<Consumable, uint>(Consumable.Gas, 165),
                new Tuple<Consumable, uint>(Consumable.Electricity, 190), new Tuple<Consumable, uint>(Consumable.Whater, 35));

            zhes.AddLoger("Vasili", rate1);
            zhes.AddLoger("Vana1", rate2);
            zhes.AddLoger("Vana2", rate2);
            zhes.AddLoger("Vana3", rate2);
            zhes.AddLoger("Vana4", rate2);

            zhes.AddConsumption("Vasili", Consumable.Gas, 43);
            Console.WriteLine("Vasili - " + zhes.GetConsumption("Vasili"));
            zhes.AddConsumption("Vana1", Consumable.Electricity, 143);
            zhes.AddConsumption("Vana2", Consumable.Whater, 143);
            zhes.AddConsumption("Vana3", Consumable.Gas, 43);
            zhes.AddConsumption("Vasili", Consumable.Electricity, 43);
            Console.WriteLine("Vasili - " + zhes.GetConsumption("Vasili"));
            Console.WriteLine(zhes.GetAllConsumption());

            zhes.RemoveLoger("Vana4");
            zhes.ChangeRate("Vana3", rate1);

            journal.PrintLogs();
        }
    }
}
