using System;
using ZHES.Collections;

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
        }
    }
}
