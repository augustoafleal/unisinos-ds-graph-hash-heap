namespace Algorithms.NodePackage;

public class Node<E>
{
    public E Element { get; set; }
    public Node<E>? Next { get; set; }

    public Node(E element)
    {
        this.Element = element;
        this.Next = null;
    }
    
}