using System;
using System.Text;

namespace Algorithms.Heap
{
    public abstract class PQ<K> where K : IComparable<K>
    {
        private const int INIT_CAPACITY = 10;
        protected K[] pq;
        protected int n;

        public PQ()
        {
            Clear();
        }

        public bool IsEmpty()
        {
            return n == 0;
        }

        public int Size()
        {
            return n;
        }

        public void Clear()
        {
            pq = new K[INIT_CAPACITY];
            n = 0;
        }

        protected void Resize()
        {
            K[] temp = new K[pq.Length * 2];
            for (var i = 0; i < n; i++)
            {
                temp[i] = pq[i];
            }

            pq = temp;
        }

        protected void BottomUpHeapify(int i)
        {
            int parent = (i - 1) / 2;
            if (i > 0 && CompareTo(parent, i))
            {
                Exchange(i, parent);
                BottomUpHeapify(parent);
            }
        }

        protected void TopDownHeapify(int i)
        {
            int temp = 2 * i + 1;
            if (temp + 1 < n && CompareTo(temp, temp + 1))
            {
                temp++;
            }
            if (temp < n && CompareTo(i, temp))
            {
                Exchange(i, temp);

                //Console.WriteLine();
                //Console.WriteLine(string.Join(", ", pq));
                TopDownHeapify(temp);
            }
        }

        protected void Exchange(int i, int j)
        {
            K swap = pq[i];
            pq[i] = pq[j];
            pq[j] = swap;
        }

        protected abstract bool CompareTo(int i, int j);

        public virtual void Increase(int i, K key)
        {
            if (i < 0 || i >= n)
            {
                throw new ArgumentException("Invalid index!");
            }
            if (key.CompareTo(pq[i]) < 0)
            {
                throw new ArgumentException("Key is less than the key in the priority queue!");
            }
            pq[i] = key;
        }

        public virtual void Decrease(int i, K key)
        {
            if (i < 0 || i >= n)
            {
                throw new ArgumentException("Invalid index!");
            }
            if (key.CompareTo(pq[i]) > 0)
            {
                throw new ArgumentException("Key is greater than the key in the priority queue!");
            }

            pq[i] = key;
        }

        public K Key()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Priority queue is empty!");
            }
            return pq[0];
        }

        public int Search(K key)
        {
            if (IsEmpty())
            {
                return -1;
            }

            for (int i = 0; i < n; i++)
            {
                if (pq[i].Equals(key))
                {
                    return i;
                }
            }
            
            return -1;
        }
        public void Insert(K key)
        {
            if (n == pq.Length)
            {
                Resize();
            }
            pq[n] = key;
            BottomUpHeapify(n++);
        }
        public K? Extract()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Priority queue is empty");
            }
            K key = pq[0];
            Exchange(0, --n);

            TopDownHeapify(0);
            pq[n] = default(K);
            //Console.WriteLine(ToTree());
            return key;
        }

        public override string ToString()
        {
            int iMax = n - 1;
            if (iMax == -1)
            {
                return "[]";
            }
            StringBuilder b = new StringBuilder("[");
            for (int i = 0; ; i++)
            {
                b.Append(pq[i]);
                if (i == iMax)
                    return b.Append(']').ToString();
                b.Append(", ");
            }
        }

        public String ToTree()
        {
            return IsEmpty() ? "empty" : PrintTree(new StringBuilder());
        }

        private string PrintTree(StringBuilder sb)
        {
            if (n > 2)
            {
                PrintTree(2, true, sb, "");
            }
            sb.Append(pq[0] + "\n");
            if (n > 1)
            {
                PrintTree(1, false, sb, "");
            }
            return sb.ToString();
        }
         private void PrintTree(int index, bool isRight, StringBuilder sb, String indent)
        {
            if (index * 2 + 2 < n)
            {
                PrintTree(index * 2 + 2, true, sb, indent + (isRight ? "        " : " |      "));
            }
            sb.Append(indent + (isRight ? " /" : " \\") + "----- " + pq[index] + "\n");
            if (index * 2 + 1 < n)
            {
                PrintTree(index * 2 + 1, false, sb, indent + (isRight ? " |      " : "        "));
            }
        }
    }

}