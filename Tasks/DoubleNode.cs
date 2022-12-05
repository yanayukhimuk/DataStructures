using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks
{
    public class DoubleNode<T>
    {
        private object element;
        private DoubleNode<T> next;
        private DoubleNode<T> previous;

        public DoubleNode(object element)
        {
            this.element = element;
            this.next = null;
            this.previous = null;
        }

        public DoubleNode(object element, DoubleNode<T> prevNode)
        {
            this.element = element;
            this.previous = prevNode;
            prevNode.next = this;
        }

        public object Element
        {
            get { return this.element; }
            set { this.element = value; }
        }

        public DoubleNode<T> Next
        {
            get { return this.next; }
            set { this.next = value; }
        }

        public DoubleNode<T> Previous
        {
            get { return this.previous; }
            set { this.previous = value; }
        }
    }
}
