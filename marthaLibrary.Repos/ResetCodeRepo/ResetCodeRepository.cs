using marthaLibrary.CoreData.AppContexts;
using marthaLibrary.CoreData.DatabaseModels;
using marthaLibrary.Repos.Generic;

namespace marthaLibrary.Repos.ResetCodeRepo
{
    internal class ResetCodeRepository : GenericRepository<ResetCode>, IResetCodeRepository
    {
        public ResetCodeRepository(LibraryDbContext context) : base(context)
        {
        }
    }
}
