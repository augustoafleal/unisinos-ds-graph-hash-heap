namespace Algorithms.NodePackage;

public class DNodeKV<K, V>
{
    
    public K Key { get; set; }
    public V Value { get; set; }

    public DNodeKV<K, V>? Next { get; set; }

    public DNodeKV<K, V>? Previous { get; set; }
    
    public DNodeKV(K key, V value)
    {
        this.Key = key;
        this.Value = value;
        this.Next = this.Previous = null;
    }

}