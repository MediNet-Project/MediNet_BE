namespace MediNet.Repositories.IRepositories
{
    public interface IUnitOfWork
    {
        IGenericRepository<T> Repository<T>() where T : class;
        IUserRepository UserRepository { get; }
        IPostRepository PostRepository { get; }
        IFollowRepository FollowRepository { get; }
        ICommentRepository CommentRepository { get; }
        Task<int> Save(CancellationToken cancellationToken);
        Task<int> SaveAndRemoveCache(CancellationToken cancellationToken, params string[] cacheKeys);
        Task Rollback();
    }
}
