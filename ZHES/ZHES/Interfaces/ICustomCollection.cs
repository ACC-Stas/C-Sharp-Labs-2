﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHES.Interfaces {
    interface ICustomCollection<T> {
        T this[int index] { get; set; }
        void Reset();
        void Next();
        void Previous();
        T Current();
        int Count { get; }
        void Add(T item);
        void Remove(T item);
        T RemoveCurrent();
    }
}
