using CourseWork.Application.Dtos.Product;
using CourseWork.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Application.Services
{
    public interface IProductService
    {
        Task<List<GetProductDto>> GetAllProducts();
        Task<GetProductDto> GetProductById(int id);
        Task<List<GetProductDto>> AddProduct(AddProductDto newProduct);


    }
}
