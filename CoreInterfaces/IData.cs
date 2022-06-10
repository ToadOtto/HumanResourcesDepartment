namespace CoreInterfaces;

public interface IData<T>
{
    void Add(T item);
    void Remove(T item);
    IEnumerable<T> ReadAll();
}
