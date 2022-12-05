using System;
using Tasks.DoNotChange;

namespace Tasks
{
    public class HybridFlowProcessor<T> : IHybridFlowProcessor<T>
    {
        public MyQueue<T> Queue { get; set; }

        public HybridFlowProcessor()
        {
            this.Queue = new MyQueue<T>();
        }
        public T Dequeue()
        {
            if (this.Queue.Count == 0)
            {
                throw new InvalidOperationException();
            }
            return Queue.Dequeue();
        }

        public void Enqueue(T item) // 
        {
            Queue.Enqueue(item); 
        }

        public T Pop() 
        {
            if (this.Queue.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return Queue.Pop();
        }

        public void Push(T item)  
        {
            Queue.Push(item);
        }
    }
}
