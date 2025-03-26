namespace Algorithms.NodePackage;

public class DNode<E>
{
    
    public E Element { get; set; }

    public DNode<E>? Next { get; set; }

    public DNode<E>? Previous { get; set; }
    
    public DNode(E element)
    {
        this.Element = element;
        this.Next = this.Previous = null;
    }


}