namespace MyWebApi.Repo.Interface
{
    public interface IBase<TKey, TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(TKey Id);

        void Add(TEntity entity);
        void Edit(TEntity entity);

        void Delete(TKey Id);
    }
}
