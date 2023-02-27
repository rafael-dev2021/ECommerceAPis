using AutoMapper;
using ECommerce.Application.DTOs;
using ECommerce.Application.Interfaces;
using ECommerce.Application.Products.Commands;
using ECommerce.Application.Products.Queries;
using MediatR;

namespace ECommerce.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ProductService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<IEnumerable<ProductDto>> GetFavoriteDtos()
        {
            var products = new GetListFavoritesQueries();
            if (products == null)
                throw new ArgumentNullException($"Entity could not be found");

            var result = await _mediator.Send(products);
            return _mapper.Map<IEnumerable<ProductDto>>(result);
        }

        public async Task<IEnumerable<ProductDto>> GetProductDtos()
        {
            var products = new GetListQueries();
            if (products == null)
                throw new ArgumentNullException($"Entity could not be found");

            var result = await _mediator.Send(products);
            return _mapper.Map<IEnumerable<ProductDto>>(result);
        }

        public async Task<ProductDto> GetById(int? id)
        {
            var product = new GetByIdQuery(id.Value);
            if (product == null)
                throw new ArgumentNullException($"Entity could not be found");

            var result = await _mediator.Send(product);
            return _mapper.Map<ProductDto>(result);
        }


        public async Task Add(ProductDto productDto)
        {
            var product = _mapper.Map<CreateCommand>(productDto);
            await _mediator.Send(product);
        }

        public async Task Update(ProductDto productDto)
        {
            var product = _mapper.Map<UpdateCommand>(productDto);
            if (product == null)
                throw new ArgumentNullException($"Entity could not be found");

            await _mediator.Send(product);
        }
        public async Task Delete(int? id)
        {
            var product = new RemoveCommand(id.Value);
            if (product == null)
                throw new ArgumentNullException($"Entity could not be found");

            await _mediator.Send(product);
        }
    }
}
