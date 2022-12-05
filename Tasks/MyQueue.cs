using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Tasks
{
    public class MyQueue<T>
    {
        private int index;
        private DoublyLinkedList<T> list;
        public MyQueue()
        {
            list = new DoublyLinkedList<T>();
            index = -1;
        }
        public int Count
        {
            get { return list.Length; }
        }
        public void Enqueue(T e)
        {
            list.Add(e);
            index++;
        }
        public T Dequeue()
        {
            T obj = list.ElementAt(0);
            list.RemoveAt(0);
            index--;
            return obj;
        }

        public void Push (T e)
        {
            list.Add(e);    
        }

        public T Pop()
        {
            T obj = list.ElementAt(list.Length - 1);
            list.RemoveAt(list.Length - 1);
            return obj;
        }
    }
}
