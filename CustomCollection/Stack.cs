using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Autopark.CustomCollection
{
    public class Stack<T> : IEnumerable
    {
        public T[] Array { get; private set; }
        private int head;

        /// <summary>
        /// Number of items in the Stack
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Stack size
        /// </summary>
        public int Size { get; private set; }

        public Stack(int count)
        {
            Array = new T[count];
            head = -1;
            Count = 0;
            Size = count;
        }

        /// <summary>
        /// Inserts an object at the top of the Stack
        /// </summary>
        /// <param name="item"></param>
        public void Push(T item)
        {
            if (IsFull())
                ChangeCapacity(Size * 2);

            Array[++head] = item;
            Count++;
        }

        /// <summary>
        /// Removes and returns the object at the top of the Stack
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException();

            T item = Array[head];
            Array[head] = default(T);
            head--;
            Count--;

            return item;
        }

        /// <summary>
        /// Returns the object at the top of the Stack without removing it
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException();

            return Array[head];
        }

        public void Clear()
        {
            System.Array.Clear(Array, 0, Size);
            head = 0;
            Count = 0;
        }

        public bool IsFull()
        {
            return head == Size - 1;
        }

        private bool IsEmpty()
        {
            return Count == 0;
        }

        private void ChangeCapacity(int capacity)
        {
            T[] newArray = new T[capacity];

            System.Array.Copy(Array, newArray, Size);

            Array = newArray;
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
            {
                yield return Array[i];
            }
        }
    }
}
