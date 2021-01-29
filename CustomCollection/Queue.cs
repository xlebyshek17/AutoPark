using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Autopark.CustomCollection
{
    public class Queue<T> : IEnumerable
    {
        public T[] Array { get; private set; }
        private int head;
        private int tail;

        /// <summary>
        /// Number of items in the Queue
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Queue size
        /// </summary>
        public int Size { get; private set; }

        /// <summary>
        /// Default capacity is 0
        /// </summary>
        public Queue()
        {
            Array = new T[0];
        }


        public Queue(int capacity)
        {
            if (capacity > 0)
            {
                Array = new T[capacity];
                head = 0;
                tail = 0;
                Count = 0;
                Size = capacity;
            }
            else
                throw new ArgumentOutOfRangeException();
            
        }

        /// <summary>
        /// Add object to the end of the Queue
        /// </summary>
        /// <param name="item"></param>
        public void Enqueue(T item)
        {
            if (IsFull())
            {
                var capacity = Size * 2;
                ChangeCapacity(capacity);
            }

            Array[tail++] = item;
            Count++;
        }

        /// <summary>
        /// Returns and deletes object from the beginning of the Queue
        /// </summary>
        /// <returns></returns>
        public T Dequeue()
        {
            if (IsEmpty())
                throw new InvalidOperationException();

            T item = Array[head];
            Count--;
            Array[head] = default(T);
            head++;

            if (head == tail)
            {
                head = 0;
                tail = 0;
            }

            return item;
        }

        /// <summary>
        /// Returns object from the beginning of the Queue
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            if (IsEmpty())
                throw new Exception("Queue is empty!");

            return Array[head];
        }


        /// <summary>
        /// Clear Queue
        /// </summary>
        public void Clear()
        {
            System.Array.Clear(Array, 0, Size);
            head = 0;
            tail = 0;
            Count = 0;
        }

        /// <summary>
        /// Сhecks whether the Queue contains the specified object
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(T item)
        {
            foreach (var i in Array)
            {
                if (item.Equals(i))
                    return true;
            }

            return false;
        }

        private void ChangeCapacity(int capacity)
        {
            T[] newArray = new T[capacity];

            System.Array.Copy(Array, newArray, Size);

            Array = newArray;
        }

        private bool IsFull()
        {
            return tail == Size;
        }

        private bool IsEmpty()
        {
            return Count == 0;
        }

        public IEnumerator GetEnumerator()
        {
            return Array.GetEnumerator();
        }
    }
}
