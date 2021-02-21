/*
 * Design a stack which supports the following operations.
Implement the CustomStack class:

CustomStack(int maxSize) Initializes the object with maxSize which is the maximum number of elements in the stack or do nothing if the stack reached the maxSize.
void push(int x) Adds x to the top of the stack if the stack hasn't reached the maxSize.
int pop() Pops and returns the top of stack or -1 if the stack is empty.
void inc(int k, int val) Increments the bottom k elements of the stack by val. If there are less than k elements in the stack, just increment all the elements in the stack.
 */
// Status = AC

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dev
{
    public class CustomStack
    {
        public int maxSize = 0;
        public int currentSize = 0;
        public IList<int> stack = null;

        public CustomStack(int maxSize)
        {
            this.stack = new List<int>();
            this.maxSize = maxSize;
            this.currentSize = 0;
        }

        public void Push(int x)
        {
            if (this.currentSize >= maxSize)
            {
                return;
            }

            this.stack.Add(x);
            this.currentSize++;
        }

        public int Pop()
        {
            if (currentSize == 0)
            {
                return -1;
            }

            var elem = this.stack.Last();
            this.stack.RemoveAt(this.currentSize - 1);
            this.currentSize--;
            return elem;
        }

        public void Increment(int k, int val)
        {
            int m = this.currentSize < k ? this.currentSize : k;

            for (int i = 0; i < m; i++)
            {
               this.stack[i] += val;
            }
        }
    }
}
