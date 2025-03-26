using System;
using System.Text;
using Algorithms.NodePackage;

namespace Algorithms.Lists;

public class SinglyLinkedList<E> : IList<E>
{
    private Node<E>? _head;
    private Node<E>? _tail;
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
        
        Node<E> newNode = new Node<E>(e);

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
    public void InsertLast(E e) {
        if (e == null) {
            throw new ArgumentNullException(nameof(e));
        }

        Node<E> newNode = new Node<E>(e);
        if (IsEmpty()) {
            _head = _tail = newNode;
        } else {
            _tail.Next = newNode;
            _tail = newNode;
        }
        _numElements++;
    }

    public E RemoveFirst()  {
        if (IsEmpty()) {
            throw new InvalidOperationException("The list is empty.");
        }

        E e = _head.Element;

        if (_head == _tail) {
            _head = _tail = null;
        } else {
            _head = _head.Next;
        }

        _numElements--;
        return e;
    }

    public E RemoveLast() {
        if (IsEmpty()) {
            throw new InvalidOperationException("The list is empty.");
        }

        E element = _tail.Element;

        if (_head == _tail) {
            _head = _tail = null;
        } else {
            Node<E> current = _head;
            while (current.Next != _tail) {
                current = current.Next;
            }
            _tail = current;
            current.Next = null;
        }

        _numElements--;
        return element;
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
        else if

            (pos == _numElements)
        {
            InsertLast(e);
        }
        else
        {
            Node<E> current = _head;
            for (int i = 0; i < pos - 1; i++)
            {
                current = current.Next;
            }
            var newNode = new Node<E>(e);
            newNode.Next = current.Next;
            current.Next = newNode;
            _numElements++;
        }
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

        if (pos == _numElements - 1)
        {
            return RemoveLast();
        }

        Node<E> current = _head;
        
        for (int i = 0; i < pos - 1; i++)
        {
            current = current.Next;
        }
        
        E e = current.Next.Element;
        current.Next = current.Next.Next;

        _numElements--;
        return e;
    }

    public E Get(int pos)
    {
        if (pos < 0 || pos >= _numElements)
        {
            throw new ArgumentOutOfRangeException(nameof(pos));
        }
        
        Node<E> current = _head;
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
        
        Node<E> current = _head;
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

        Node<E> current = _head.Next;
        while (current != null) {
            s.Append(" - ").Append(current.Element.ToString());
            current = current.Next;
        }
        return s.ToString();

    }
}