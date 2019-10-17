using Shop.Domain;
using System;
using System.Collections.Generic;

namespace Shop.DataAccess.Abstract
{
    public interface ICategoryRepository
    {
        void Add(Category category);
        void Delete(Guid categoryId);
        void Update(Category category);
        ICollection<Category> GetAll();
    }
}
