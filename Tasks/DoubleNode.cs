using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks
{
    public class DoubleNode<T>
    {
        private object _element;
        private DoubleNode<T> _next;
        private DoubleNode<T> _previous;

        public DoubleNode(object element)
        {
            this._element = element;
            this._next = null;
            this._previous = null;
        }

        public DoubleNode(object element, DoubleNode<T> prevNode)
        {
            this._element = element;
            this._previous = prevNode;
            prevNode._next = this;
        }

        public object Element
        {
            get { return this._element; }
            set { this._element = value; }
        }

        public DoubleNode<T> Next
        {
            get { return this._next; }
            set { this._next = value; }
        }

        public DoubleNode<T> Previous
        {
            get { return this._previous; }
            set { this._previous = value; }
        }
    }
}
