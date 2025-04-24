﻿using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.DeleteSale
{
    public class DeleteSaleHandler : IRequestHandler<DeleteSaleCommand, bool>
    {
        private readonly ISaleRepository _saleRepository;

        public DeleteSaleHandler(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public async Task<bool> Handle(DeleteSaleCommand request, CancellationToken cancellationToken)
        {
            var deleted = await _saleRepository.DeleteAsync(request.Id, cancellationToken);
            return deleted;
        }
    }
}
