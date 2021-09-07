using System;
using ZHES.Collections;
using ZHES.Entities;

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

            someCollection.Remove(49); //testing remove
            someCollection.Remove(5);
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

            //testing ZHES
            HMS zhes = new HMS();
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
        }
    }
}
