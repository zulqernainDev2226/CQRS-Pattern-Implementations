﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Data;
using ProductCatalog.Models;


namespace ProductCatalog.Resources.Queries
{
    public class GetAllProductsQuery : IRequest<IEnumerable<Product>>
    {
    }

    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
    {
        private readonly ProductDBContext _context;

        public GetAllProductsQueryHandler(ProductDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Products.ToListAsync(cancellationToken);
        }
    }
}