Specification for Interfaces (and repos with that)

Generic Interface
The generic Interface consists of following Methods:

```C#
public interface IGenericRepo<TEntity>
{
    // Get
    Task<IEnumerable<TEntity>> GetAll();
    Task<TEntity> Get(object[] ids);

    // Set
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
}
```

