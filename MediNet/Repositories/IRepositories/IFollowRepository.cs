namespace MediNet.Repositories.IRepositories
{
    public interface IFollowRepository
    {
        public Task<int> DeleteFollowAsync(int Id);
    }
}
