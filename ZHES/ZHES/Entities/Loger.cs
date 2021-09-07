using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHES.Entities {
    class Loger {
        public Loger (string name, Rate rate) {
            Name = name;
            Rate = rate;
        }
        public string Name { get; set; }
        public Rate Rate { get; set; }
        public uint Consumption { get; private set; }
        public void AddConsumption(Consumable name, uint quantity) {
            uint costIndex = 1;
            bool Found = false;
            Rate.cost.Reset();
            for (int i = 0; i < Rate.cost.Count; i++) {
                if (Rate.cost.Current().Item1 == name) {
                    costIndex = Rate.cost.Current().Item2;
                    Found = true;
                    break;
                }
                Rate.cost.Next();
            }

            if (!Found) {
                throw new ArgumentException($"Rate {Rate.Name} doesn't have Consumable {name}");
            }
            Consumption += quantity * costIndex;
        }
    }
}
