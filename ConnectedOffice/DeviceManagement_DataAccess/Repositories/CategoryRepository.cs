using Core;
using DeviceManagement_WebApp.Models;

namespace DeviceManagement_DataAccess.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoriesRepository
    {
        public CategoryRepository(ConnectedOfficeContext context) : base(context)
        {
        }
    }
}