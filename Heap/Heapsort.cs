using System;

namespace Algorithms.Heap
{
    class HeapsortUtil
    {
        public static void HeapSort<T>(T[] a) where T : IComparable<T>
        {
            BuildMaxHeap(a); // Fase 1
            for (var i = a.Length - 1; i > 0; i--) // Fase 2
            {
                Exchange(a, 0, i);
                MaxHeapify(a, 0, i);
            }
        }

        private static void BuildMaxHeap<T>(T[] a) where T : IComparable<T>
        {
            for(var i = a.Length / 2 - 1; i >= 0; i--)
            {
                MaxHeapify(a, i, a.Length);
            }
        }

        private static void MaxHeapify<T>(T[] a, int i, int n) where T : IComparable<T>
        {
            int max = 2 * i + 1; // Indice filho a esquerda
            if (max + 1 < n && a[max].CompareTo(a[max + 1]) < 0)
            {
                max++; // Indice filho a direita
            }
            if (max < n && a[max].CompareTo(a[i]) > 0)
            {
                Exchange(a, i, max);
                MaxHeapify(a, max, n);
            }
        }

        private static void Exchange<T>(T[] a, int i, int j) where T : IComparable<T>
        {
            T tmp = a[i];
            a[i] = a[j];
            a[j] = tmp;
        }


    }
}
