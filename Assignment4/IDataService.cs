using System.Collections.Generic;
using Assignement4;

namespace Assignment4
{
    public interface IDataService
    {
        void CreateCategory(Category category);
        IList<Category> GetCategories();
        Category GetCategory(int categoryId);
        bool DeleteCategory(int categoryId);
    }
}