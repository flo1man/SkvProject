namespace SkvProject.Services.Data.Forum
{
    using System.Linq;

    using SkvProject.Data.Common.Repositories;
    using SkvProject.Data.Models;

    public class UsersService : IUsersService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;

        public UsersService(IDeletableEntityRepository<ApplicationUser> usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public string GetNewestMember()
        {
            var username = this.usersRepository
                .All().OrderByDescending(x => x.CreatedOn)
                .FirstOrDefault().UserName;

            return username;
        }

        public int GetUsersCount()
        {
            return this.usersRepository
                .All().Count();
        }
    }
}
