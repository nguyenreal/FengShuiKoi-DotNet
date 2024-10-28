﻿using FSK_BusinessObjects;
using FSK_DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSK_Repositories
{
    public class CategoryRepo : ICategoryRepo
    {
        public bool DeleteCategory(String id) => CategoryDAOs.Instance.DeleteCategory(id);

        public Category GetCategory(string id) => CategoryDAOs.Instance.GetCategory(id);

        public List<Category> GetCategories() => CategoryDAOs.Instance.GetCategories();

        public bool SaveCategory(Category category) => CategoryDAOs.Instance.SaveCategory(category);

        public bool UpdateCategory(Category category) => CategoryDAOs.Instance.UpdateCategory(category);
    }
}
