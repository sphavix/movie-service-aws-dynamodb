using MoviesApi.Models;

namespace MoviesApi.Repositories
{
    public interface IUserService
    {
        public User Get(UserLogin userLogin);
    }
}