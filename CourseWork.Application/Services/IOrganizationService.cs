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
        Task<ResponseService<List<GetProductDto>>> GetAllProducts();
        Task<ResponseService<GetProductDto>> GetProductById(int id);
        Task<ResponseService<List<GetProductDto>>> AddProduct(AddProductDto newProduct);
        Task<ResponseService<GetProductDto>> UpdateProduct(UpdateProductDto updateProduct);
        Task<ResponseService<List<GetProductDto>>> DeleteProduct(int id);

    }
}
