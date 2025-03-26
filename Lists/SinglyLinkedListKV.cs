using System;
using System.Text;
using Algorithms.NodePackage;

namespace Algorithms.Lists;

public class SinglyLinkedListKV<K, V> : IListKV<K, V>
{
    private NodeKV<K, V>? _head;
    private NodeKV<K, V>? _tail;
    private int _numElements;

    public bool IsEmpty()
    {
        return _head == null;
    }

    public bool IsFull()
    {
        return false;
    }

    public void Insert(K key, V value)
    {
        if (key == null || value == null)
        {
            throw new ArgumentNullException();
        }
        
        NodeKV<K, V> newNode = new NodeKV<K, V>(key, value);

        if (IsEmpty())
        {
            _head = _tail = newNode;
        }
        else
        {
            newNode.Next = _head;
            _head = newNode;
        }

        _numElements++;
    }
    
    public string Delete(K key)
    {
        if (_head == null)
        {
            throw new InvalidOperationException("List is empty");
        } 
        
        NodeKV<K, V> current = _head;
        NodeKV<K, V>? previous = null;
        
        if (current.Key!.Equals(key))
        {
            _head = current.Next;
            _numElements--;
            return current.Value.ToString();
        }
        
        while (current != null && !current.Key!.Equals(key))
        {
            previous = current;
            current = current.Next;
        }

        if (current == null)
        {
            throw new InvalidOperationException($"Key {key} not found.");
        }

        previous!.Next = current.Next;
        _numElements--;
        return current.ToString();
    }
    
    public V Search(K key)
    {
        if (key == null)
        {
            throw new ArgumentNullException(nameof(key));
        }

        NodeKV<K, V>? current = _head;

        while (current != null)
        {
            if (key.Equals(current.Key))
            {
                return current.Value; 
            }
            
            current = current.Next;
        }

        return default;
    }

    public void Clear()
    {
        _head = null;
        _numElements = 0;
    }

    public override string ToString()
    {
        if (this.IsEmpty())
        {
            return "[EMPTY]";
        }

        StringBuilder s = new StringBuilder(_head.Value.ToString()); 

        NodeKV<K, V> current = _head.Next;
        while (current != null)
        {
            s.Append(" - ").Append(current.Value.ToString());
            current = current.Next;
        }

        return s.ToString();
    }


}