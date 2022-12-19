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
        public async Task<ResponseService<List<GetProductDto>>> AddProduct(AddProductDto newProduct)
        {
            var responseService = new ResponseService<List<GetProductDto>>();
            Product product = _mapper.Map<Product>(newProduct);
            products.Add(product);
            responseService.Data = products.Select(_mapper.Map<GetProductDto>).ToList();
            return responseService;
        }

        public async Task<ResponseService<List<GetProductDto>>> GetAllProducts()
        {
            return new ResponseService<List<GetProductDto>> 
            { 
                Data = products.Select(p => _mapper.Map<GetProductDto>(p)).ToList()
            };
        }

        public async Task<ResponseService<GetProductDto>> GetProductById(int id)
        {
            var responseService = new ResponseService<GetProductDto>();
            var product = products.FirstOrDefault(x => x.Id == id);
            responseService.Data = _mapper.Map<GetProductDto>(product);
            return responseService;
        }


    }
}
