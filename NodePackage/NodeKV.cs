namespace Algorithms.NodePackage;

public class NodeKV<K, V>
{
    
    public V Value { get; set; }
    public K Key { get; set; }
    public NodeKV<K, V>? Next { get; set; }

    public NodeKV(K key, V value)
    {
        this.Key = key;
        this.Value = value;
        this.Next = null;
    }
    public override string ToString()
    {
        return $"[{Key}: {Value}]";
    }
}