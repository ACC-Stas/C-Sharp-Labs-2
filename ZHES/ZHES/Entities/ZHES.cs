using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZHES.Collections;

namespace ZHES.Entities
{
    class HMS {
        public delegate void ChangedLogers(Loger loger, bool insertion);
        public event ChangedLogers NotifyLogersChange;
        public delegate void ChangedRates(string fullname, Rate newRate);
        public event ChangedRates NotifyRateChange;
        public delegate void ChangedConsumption(string fullname, Consumable name, uint quantity);
        public event ChangedConsumption NotifyConsumptionChange;

        MyCustomCollection<Loger> logers = new MyCustomCollection<Loger>();

        public void AddLoger(string fullname, Rate rate) {
            Loger loger = new Loger(fullname, rate);
            logers.Reset();
            for (int i = 0; i < logers.Count; i++) {
                if (logers.Current().Name == fullname) {
                    throw new ArgumentException($"There is already Loger with name {fullname}");
                }
                logers.Next();
            }
            logers.Add(loger);
            NotifyLogersChange?.Invoke(loger, true);
        }
        public void RemoveLoger(string fullname) {
            logers.Reset();
            for (int i = 0; i < logers.Count; i++) {
                if (logers.Current().Name == fullname) {
                    NotifyLogersChange?.Invoke(logers.Current(), false);
                    logers.RemoveCurrent();
                    break;
                }
                logers.Next();
            }
        }
        public void AddConsumption(string fullName, Consumable name, uint quantity) {
            FindLoger(fullName).AddConsumption(name, quantity);
            NotifyConsumptionChange?.Invoke(fullName, name, quantity);
        }
        public uint GetConsumption(string fullname) {
            return FindLoger(fullname).Consumption;
        }
        public uint GetAllConsumption() {
            uint allConsumption = 0;
            logers.Reset();
            for (int i = 0; i < logers.Count; i++) {
                allConsumption += logers.Current().Consumption;
                logers.Next();
            }
            return allConsumption;
        }
        private Loger FindLoger(string fullName) {
            logers.Reset();
            for (int i = 0; i < logers.Count; i++) {
                if (logers.Current().Name == fullName) {
                    return logers.Current();
                }
                logers.Next();
            }
            throw new ArgumentException($"There is no logers with name {fullName}");
        }
        public bool Listed(string fullName) {
            logers.Reset();
            for (int i = 0; i < logers.Count; i++) {
                if (logers.Current().Name == fullName) {
                    return true;
                }
                logers.Next();
            }
            return false;
        }
        public void ChangeRate(string fullName, Rate rate) {
            FindLoger(fullName).Rate = rate;
            NotifyRateChange?.Invoke(fullName, rate);
        }
    }
}
