using System;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using Algorithms.Lists;

namespace Algorithms.Hashs;

public class OpenHashing<K, V> : IHashing<K, V>
{
    private const int InitCapacity = 10;
    private SinglyLinkedListKV<K, V>[] _table;
    private int _m;
    private int _n;
    
    public OpenHashing() : this(InitCapacity) { }

    public OpenHashing(int capacity)
    {
        _m = capacity;
        Clear();
    }
    
    public bool IsEmpty()
    {
        return _n == 0;
    }

    public int Size()
    {
        return _n;
    }
    
    public void Clear()
    {
        _n = 0;
        _table = new SinglyLinkedListKV<K, V>[_m];

        for (var i = 0; i < _m; i++)
        {
            _table[i] = new SinglyLinkedListKV<K, V>();  
            _table[i].Clear();  
        }
    }
    private int H(K key)
    {
        return (5 * (key.GetHashCode() & 0x7fffffff)) % _m;
    }
    public void Insert(K key, V value)
    {
        int i = H(key);
        
        // DEBUG
        //Console.WriteLine($"Indice do OpenHash: {i} -> Key: {key}, Value: {value}");
        
        if (_table[i].Search(key) == null)
        {
            _n++;
        }
        _table[i].Insert(key, value);
    }

    public V Search(K key)
    {
        int i = H(key);
        return _table[i].Search(key);
    }

    public bool Delete(K key)
    {
        int i = H(key);
        if (_table[i].Search(key) != null)
        {
            _table[i].Delete(key);
            _n--;
            return true;
        }

        return false;
    }
    
    public override string ToString() {
        StringBuilder b = new StringBuilder();
        int iMax = _m - 1;
        if (iMax == -1)
        {
            b.Append("[]");
        }
        
        string aux;
        
        for (var i = 0; i < _m; i++) {
            b.Append("[" + i + "] " + _table[i] +
                     "\n");
        }
        
        return b.ToString();
    }
}