﻿namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    public class CreateSaleResponse
    {
        public Guid Id { get; set; }
        public decimal Total { get; set; }
        public decimal Discount { get; set; }
        public decimal FinalAmount { get; set; }
    }
}