using CourseWork.Application.Dtos.Country;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Application.Services.Implementations
{
    public class CountryService
    {
        public async Task<ResponseCountryDto> GetById(int id)
        {
            var entity = _repository.getbyid(id);
            return Mapper.Map<Dtos>(entitty);
        }
    }
}
