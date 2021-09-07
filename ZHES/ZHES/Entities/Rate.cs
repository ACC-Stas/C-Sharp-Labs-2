using System;
using ZHES.Collections;

enum Consumable {
    Gas,
    Whater,
    Electricity
}

namespace ZHES.Entities {
    class Rate {
        public Rate (string fullName, params Tuple<Consumable,uint>[] tuples) {
            Name = fullName;
            for (int i = 0; i < tuples.Length; i++) {
                cost.Add(tuples[i]);
            }
        }
        public string Name { get; set; }
        public MyCustomCollection<Tuple<Consumable, uint>> cost = new MyCustomCollection<Tuple<Consumable, uint>>();
    }
}
