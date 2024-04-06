public interface IRepository<T>
{
    void Add(T item);
    void Update(T updatedItem);
    void Delete(int id);
    T Find(Func<T, bool> filter);
    IList<T> GetAll();
}
