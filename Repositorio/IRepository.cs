public interface IRepository<T>
{
    T Add(T item);
    T Update(T updatedItem);
    void Delete(int id);
    T Find(Func<T, bool> filter);
    IList<T> FindAll();
}
