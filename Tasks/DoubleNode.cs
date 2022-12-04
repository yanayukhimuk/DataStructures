using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks
{
    public class DoubleNode
    {
        private object element;
        private DoubleNode next;
        private DoubleNode previous;

        public DoubleNode(object element)
        {
            this.element = element;
            this.next = null;
            this.previous = null;
        }

        public DoubleNode(object element, DoubleNode prevNode)
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

        public DoubleNode Next
        {
            get { return this.next; }
            set { this.next = value; }
        }

        public DoubleNode Previous
        {
            get { return this.previous; }
            set { this.previous = value; }
        }
    }
}
