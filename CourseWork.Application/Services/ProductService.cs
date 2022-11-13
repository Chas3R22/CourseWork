using AutoMapper;
using CourseWork.Application.Dtos.Product;
using CourseWork.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Application.Services
{
    public class ProductService : IProductService
    { 
        private static List<Product> products = new List<Product>
        {

        };

        private readonly IMapper _mapper;

        public ProductService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<List<GetProductDto>> AddProduct(AddProductDto newProduct)
        {
            products.Add(newProduct);
            return products;
        }

        public async Task<List<GetProductDto>> GetAllProducts()
        {
            return products;
        }

        public async Task<GetProductDto> GetProductById(int id)
        {
            return products.FirstOrDefault(p => p.Id == id);
        }
    }
}
