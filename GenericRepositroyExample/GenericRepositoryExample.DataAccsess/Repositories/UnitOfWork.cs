using GenericRepositoryExampla.Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepositoryExample.DataAccsess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private GenericDbContext _context;
        private UserRepository _userRepository;
        private ProfileRepository _profileRepository;
        private ContentRepository _contentRepository;
        private CategoryRepository _categoryRepository;

        public UnitOfWork(GenericDbContext context) //constructer
        {
            this._context = context;
        }
        public IUserRepository Users => _userRepository = _userRepository ?? new UserRepository(_context);
        public IProfileRepository Profiles => _profileRepository = _profileRepository ?? new ProfileRepository(_context);

        public IContentRepository Contents => _contentRepository = _contentRepository ?? new ContentRepository(_context);

        public ICategoryRepository Categories => _categoryRepository = _categoryRepository ?? new CategoryRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }
        //bir nesne ile işimiz bittikten sonra dispose etmemiz ramden silmemiz gerekir
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
