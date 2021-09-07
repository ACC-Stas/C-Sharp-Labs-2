using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZHES.Interfaces;

namespace ZHES.Collections {
    public class MyCustomCollection<T> : ICustomCollection<T> {
        private class Node {
            public Node(T data) {
                Data = data;
            }
            public T Data { get; set; }
            public Node Previous { get; set; }
            public Node Next { get; set; }
        }

        Node head;
        Node tail;
        Node cursor;
        int count;

        public T this[int index] { 
            get {
                if (index > count - 1) {
                    throw new IndexOutOfRangeException($"index {index} is bigger than number of elements {count}");
                }
                if (index < 0) {
                    throw new IndexOutOfRangeException($"index {index} is negative");
                }

                Node current = head;
                for (int i = 0; i < index; i++) {
                    current = current.Next;
                }
                return current.Data;
            }
            set {    //value of the node under index will be changed
                if (index > count - 1) {
                    throw new IndexOutOfRangeException($"index {index} is bigger than number of elements {count}");
                }
                if (index < 0) {
                    throw new IndexOutOfRangeException($"index {index} is negative");
                }

                Node current = head;
                for (int i = 0; i < index; i++) {
                    current = current.Next;
                }
                current.Data = value;
            }
        }

        public void Reset() {
            cursor = head;
        }

        public void Next() {
            if (cursor == null) {
                throw new InvalidOperationException("cursor is on null value");
            }
            cursor = cursor.Next;
        }

        public void Previous() {
            if (cursor == null) {
                throw new InvalidOperationException("cursor is on null value");
            }
            cursor = cursor.Previous;
        }

        public T Current() {
            if (cursor == null) {
                throw new InvalidOperationException("cursor is on null value");
            }
            return cursor.Data;
        }

        public void Add(T item) {
            Node node = new Node(item);

            if (head == null) {
                head = node;
            }
            else {
                tail.Next = node;
                node.Previous = tail;
            }
            tail = node;
            count++;
        }

        public void Remove(T item) {
            Node current = head;

            while (current != null) {
                if(current.Data.Equals(item)) {
                    break;
                }
                current = current.Next;
            }

            if(current != null) {
                if(current.Next != null) {
                    current.Next.Previous = current.Previous;
                }
                else {
                    tail = current.Previous;
                }

                if(current.Previous != null) {
                    current.Previous.Next = current.Next;
                } else {
                    head = current.Next;
                }
                count--;
            }
        }

        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }

        public T RemoveCurrent() {  //returns data of current cursor
            if (cursor == null) {
                throw new InvalidOperationException("cursor is at null position");
            }

            T data = cursor.Data;
            if (cursor.Next != null) {
                cursor.Next.Previous = cursor.Previous;
            }
            else {
                tail = cursor.Previous;
            }

            if (cursor.Previous != null) {
                cursor.Previous.Next = cursor.Next;
            }
            else {
                head = cursor.Next;
            }
            cursor = head;
            count--;
            return data;
        }
    }
}
