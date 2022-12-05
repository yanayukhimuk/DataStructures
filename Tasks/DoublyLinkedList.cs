using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Tasks.DoNotChange;

namespace Tasks
{
    public class DoublyLinkedList<T> : IDoublyLinkedList<T>
    {
        private DoubleNode<T> _head;
        private DoubleNode<T> _tail;
        private int _count;
        
        public DoublyLinkedList()
        {
            this._head = null;
            this._tail = null;
            this._count = 0;
        }
        public int Length => this._count;
        public object this[int index]
        {
            get
            {
                if (index >= _count || index < 0)
                {
                    throw new IndexOutOfRangeException("Out of range!");
                }
                DoubleNode<T> currentNode = this._head;
                for (int i = 0; i < index; i++)
                {
                    currentNode = currentNode.Next;
                }
                return currentNode.Element;
            }
            set
            {
                if (index >= _count || index < 0)
                {
                    throw new IndexOutOfRangeException("Out of range!");
                }
                DoubleNode<T> currentNode = this._head;
                for (int i = 0; i < index; i++)
                {
                    currentNode = currentNode.Next;
                }
                currentNode.Element = value;
            }
        }

        public void Add(T e)
        {
            if (this._head == null)
            {
                this._head = new DoubleNode<T>(e);
                this._tail = this._head;
            }
            else
            {
                DoubleNode<T> newItem = new DoubleNode<T>(e, _tail);
                this._tail = newItem;
            }
            _count++;
        }

        public void AddAt(int index, T e)
        {
            _count++;
            if (index >= _count || index < 0)
            {
                throw new IndexOutOfRangeException("Out of range!");
            }
            DoubleNode<T> newItem = new DoubleNode<T>(e);
            int currentIndex = 0;
            DoubleNode<T> currentItem = this._head;
            DoubleNode<T> prevItem = null;
            while (currentIndex < index)
            {
                prevItem = currentItem;
                currentItem = currentItem.Next;
                currentIndex++;
            }
            if (index == 0)
            {
                newItem.Previous = this._head.Previous;
                newItem.Next = this._head;
                this._head.Previous = newItem;
                this._head = newItem;
            }
            else if (index == _count - 1)
            {
                newItem.Previous = this._tail;
                this._tail.Next = newItem;
                newItem = this._tail;
            }
            else
            {
                newItem.Next = prevItem.Next;
                prevItem.Next = newItem;
                newItem.Previous = currentItem.Previous;
                currentItem.Previous = newItem;
            }
        }

        public T ElementAt(int index)
        {
            if (index >= this._count || index < 0)
            {
                throw new IndexOutOfRangeException("Out of range!");
            }

            int currentIndex = 0;
            T foundItem;
            DoubleNode<T> currentItem = this._head;
            DoubleNode<T> prevItem = null;

            while (currentIndex < index)
            {
                prevItem = currentItem;
                currentItem = currentItem.Next;
                currentIndex++;
            }
            if (index == currentIndex)
            {
                foundItem = (T)currentItem.Element;
            }
            else
                foundItem = default;
            return foundItem;
        }

        public void Remove(T item)
        {
            int currentIndex = 0;
            DoubleNode<T> currentItem = this._head;
            DoubleNode<T> prevItem = null;
            while (currentItem != null)
            {
                if ((currentItem.Element != null &&
                currentItem.Element.Equals(item)) ||
                (currentItem.Element == null) && (item == null))
                {
                    break;
                }
                prevItem = currentItem;
                currentItem = currentItem.Next;
                currentIndex++;
            }
            if (currentItem != null)
            {
                _count--;
                if (_count == 0)
                {
                    this._head = null;
                }
                else if (prevItem == null)
                {
                    this._head = currentItem.Next;
                    this._head.Previous = null;
                }
                else if (currentItem == _tail)
                {
                    currentItem.Previous.Next = null;
                    this._tail = currentItem.Previous;
                }
                else
                {
                    currentItem.Previous.Next = currentItem.Next;
                    currentItem.Next.Previous = currentItem.Previous;
                }
            }
        }

        public T RemoveAt(int index)
        {
            if (index >= this._count || index < 0)
            {
                throw new IndexOutOfRangeException("Out of range!");
            }

            int currentIndex = 0;
            T removedItem;
            DoubleNode<T> currentItem = this._head;
            DoubleNode<T> prevItem = null;
            while (currentIndex < index)
            {
                prevItem = currentItem;
                currentItem = currentItem.Next;
                currentIndex++;
            }
            if (this._count == 0)
            {
                this._head = null;
                removedItem = default;
            }
            else if (prevItem == null)
            {
                this._head = currentItem.Next;
                this._head.Previous = null;
                removedItem = default;
            }
            else if (index == _count - 1)
            {
                removedItem = (T)currentItem.Element;
                prevItem.Next = currentItem.Next;
                _tail = prevItem;
                currentItem = null;
            }
            else 
            {
                removedItem = (T)currentItem.Element;
                prevItem.Next = currentItem.Next;
                currentItem.Next.Previous = prevItem;
            }
            _count--;
            return removedItem;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator<DoubleNode<T>> GetEnumerator()
        {
            DoubleNode<T> current = _head;
            while (current != null)
            {
                yield return current;
                current = current.Next;
            }
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
