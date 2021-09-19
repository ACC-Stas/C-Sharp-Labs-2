using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHES.Exceptions {
    class NoItemException<T> : Exception {
        public T Item { get; }
        public NoItemException(string message, T item) : base(message) {
            Item = item;
        }
    }
}
