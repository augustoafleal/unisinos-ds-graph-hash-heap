using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Heap
{
    class MinPQ<K> : PQ<K> where K : IComparable<K>
    {
        protected override bool CompareTo(int i, int j)
        {
            return pq[i].CompareTo(pq[j]) > 0;
        }

        public override void Increase(int i, K key){
            base.Increase(i, key);
            TopDownHeapify(i);
        }
        
        public override void Decrease(int i, K key){
            base.Decrease(i, key);
            BottomUpHeapify(i);
        }

    }
}
