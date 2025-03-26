namespace Algorithms.Hashs;

public interface IHashing <K, V>
{
    public bool IsEmpty();
    public int Size();
    public void Clear();
    public void Insert(K key, V value);
    public V Search(K key);
    public bool Delete(K key);
}