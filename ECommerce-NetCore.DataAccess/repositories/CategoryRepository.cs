using ECommerce_NetCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_NetCore.DataAccess.repositories
{
    public class CategoryRepository : ECommerceRepositoryGeneric<Category>, ICategoryRepository
    {
        public CategoryRepository(ECommerceNetCoreDbContext context) : base(context)
        {

        }

        public async Task<string> CreateAsync(Category entity)
        {
            return await Insert(entity);
        }

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<Category> GetItemAsync(string id)
        {
            return await Select(id);
        }

        public Task<(ICollection<Category> coleccion, int total)> ListAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
