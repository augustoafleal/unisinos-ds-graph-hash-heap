namespace Algorithms.Lists;

public interface IListKV<K, V>
{

    bool IsEmpty();

    bool IsFull();

    void Insert(K key, V value);
    
    public string Delete(K key);
    

    public V Search(K key);

    public void Clear();

}