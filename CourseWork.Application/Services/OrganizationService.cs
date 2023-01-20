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
    public class OrganizationService : IOrganizationService
    {
        private readonly IMapper _mapper;
        public OrganizationService(IMapper mapper)
        {
            _mapper = mapper;
        }

        private static List<Organization> products = new List<Organization>();

        public async Task<ResponseService<List<GetOrganizationDto>>> AddProduct(AddOrganizationDto newProduct)
        {
            var responseService = new ResponseService<List<GetOrganizationDto>>();
            Organization product = _mapper.Map<Organization>(newProduct);
            products.Add(product);
            responseService.Data = products.Select(_mapper.Map<GetOrganizationDto>).ToList();
            return responseService;
        }

        public async Task<ResponseService<List<GetOrganizationDto>>> GetAllProducts()
        {
            return new ResponseService<List<GetOrganizationDto>> 
            { 
                Data = products.Select(p => _mapper.Map<GetOrganizationDto>(p)).ToList()
            };
        }

        public async Task<ResponseService<GetOrganizationDto>> GetProductById(int id)
        {
            var responseService = new ResponseService<GetOrganizationDto>();
            var product = products.FirstOrDefault(x => x.Id == id);
            responseService.Data = _mapper.Map<GetOrganizationDto>(product);
            return responseService;
        }

        public async Task<ResponseService<GetOrganizationDto>> UpdateProduct(UpdateOrganizationDto updateProduct)
        {
            ResponseService<GetOrganizationDto> response = new ResponseService<GetOrganizationDto>();

            try
            {
                Organization product = products.FirstOrDefault(p => p.Id == updateProduct.Id);

                _mapper.Map(updateProduct, product);

                response.Data = _mapper.Map<GetOrganizationDto>(product);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ResponseService<List<GetOrganizationDto>>> DeleteProduct(int id)
        {
            ResponseService<List<GetOrganizationDto>> response = new ResponseService<List<GetOrganizationDto>>();

            try
            {
                Organization product = products.First(p => p.Id == id);
                products.Remove(product);
                response.Data = products.Select(p => _mapper.Map<GetOrganizationDto>(p)).ToList();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
