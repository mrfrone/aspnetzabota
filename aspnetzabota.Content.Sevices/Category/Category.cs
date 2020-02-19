using aspnetzabota.Content.Database.Repository.Category;
using aspnetzabota.Content.Datamodel.Articles;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace aspnetzabota.Content.Services.Category
{
    internal class Category : ICategory
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;
        public Category(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<ZabotaCategory>> GetCategory()
        {
            var result = await _categoryRepository.Get();
            return _mapper.Map<IEnumerable<ZabotaCategory>>(result);
        }
    }
}
