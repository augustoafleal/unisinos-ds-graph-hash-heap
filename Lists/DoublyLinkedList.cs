using System;
using System.Text;
using Algorithms.NodePackage;

namespace Algorithms.Lists;

public class DoublyLinkedList <E> : IList<E>
{
    
    private DNode<E>? _head;
    private DNode<E>? _tail;
    private int _numElements;

    public bool IsEmpty()
    {
        return _head == null;
    }

    public bool IsFull()
    {
        return false;
    }

    public void InsertFirst(E e)
    {
        if (e == null)
        {
            throw new ArgumentNullException(nameof(e));
        }
        
        var newNode = new DNode<E>(e);
        
        if (IsEmpty())
        {
            _head = _tail = newNode;
        }
        else
        {
            _head.Previous = newNode;
            newNode.Next = _head;
            _head = newNode;
        }
        
        _numElements++;
    }

    public void InsertLast(E e)
    {
        if (e == null)
        {
            throw new ArgumentNullException(nameof(e));
        }
        
        var newNode = new DNode<E>(e);
        
        if (IsEmpty())
        {
            _head = _tail = newNode;
        }
        else
        {
            _tail.Next = newNode;
            newNode.Previous = _tail;
            _tail = newNode;
        }
        
        _numElements++;
    }
    
    public void Insert(E e, int pos)
    {
        if (e == null)
        {
            throw new ArgumentNullException(nameof(e));
        }

        if (pos < 0 || pos >= _numElements)
        {
            throw new ArgumentOutOfRangeException(nameof(pos));
        }

        if (pos == 0)
        {
            InsertFirst(e);
        }
        else if (pos == _numElements)
        {
            InsertLast(e);
        }
        else
        {
            DNode<E> prev = _head;
            
            for (int i = 0; i < pos - 1; i++)
            {
                prev = prev.Next;
            }
            
            var newNode = new DNode<E>(e);
            
            newNode.Previous = prev;
            newNode.Next = prev.Next;
            prev.Next.Previous = newNode;
            prev.Next = newNode;
            _numElements++;
        }
    }

    public E RemoveFirst()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("The list is empty");
        }

        E removedItem = _head.Element;

        if (_head == _tail)
        {
            _head = _tail = null;
        }
        else
        {
            _head = _head.Next;
            _head.Previous = null;
        }

        _numElements--;
        return removedItem;
    }
    
    public E RemoveLast()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("The list is empty");
        }

        E removedItem = _tail.Element;

        if (_head == _tail)
        {
            _head = _tail = null;
        }
        else
        {
            _tail = _tail.Previous;
            _tail.Next = null;
        }

        _numElements--;
        return removedItem;
    }

    public E Remove(int pos)
    {
        if (pos < 0 || pos >= _numElements)
        {
            throw new ArgumentOutOfRangeException(nameof(pos));
        }

        if (pos == 0)
        {
            return RemoveFirst();
        }

        if (pos < _numElements - 1 / 2)
        {
            DNode<E> prev = _head;
            for (int i = 0; i < pos - 1; i++)
            {
                prev = prev.Next;
            }
            E e = prev.Next.Element;
            prev.Next = prev.Next.Next;
            prev.Next.Previous = prev;
                
            _numElements--;
            return e;
        }
        else
        {
            DNode<E> prev = _tail;

            for (int i = _numElements - 1; i >= pos; i--)
            {
                prev = prev.Previous;
            }
            
            E e = prev.Next.Element;
            
            prev.Next = prev.Next.Next;
            prev.Next.Previous = prev;
            _numElements--;
            return e;
        }
        
    }

    public E Get(int pos)
    {
        if (pos < 0 || pos >= _numElements)
        {
            throw new ArgumentOutOfRangeException(nameof(pos));
        }
        
        DNode<E> current = _head;

        for (int i = 0; i < pos; i++)
        {
            current = current.Next;
        }
        
        return current.Element;
    }

    public int Search(E e)
    {
        if (e == null)
        {
            throw new ArgumentNullException(nameof(e));
        }
        
        DNode<E> current = _head;
        int i = 0;
        while (current != null)
        {
            if (e.Equals(current.Element))
            {
                return i;
            }

            i++;
            current = current.Next;
        }

        return -1;
    }
    
    public override String ToString() {
        if(this.IsEmpty()){
            return "[EMPTY]";
        }
        StringBuilder s = new StringBuilder(_head.Element.ToString());

        DNode<E> current = _head.Next;
        while (current != null) {
            s.Append(" - ").Append(current.Element.ToString());
            current = current.Next;
        }
        return s.ToString();

    }
}