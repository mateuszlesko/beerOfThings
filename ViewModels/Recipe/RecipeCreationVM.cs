using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using beerOfThings.Models;

namespace beerOfThings.ViewModels
{
    public class RecipeCreationVM
    {
        private List<Category> _Categories;
        public int CategoryId { get; set; }
        public string Name { get; set; }

        public List<Category> GetCategories() => _Categories;

        public void SetCategories(List<Category> categories) 
        {
            _Categories = categories;
        }
    }
}
