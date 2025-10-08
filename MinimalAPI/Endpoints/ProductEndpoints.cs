using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MinimalAPI.Common.Validators;
using MinimalAPI.Entities;
using MinimalAPI.Models.DTO.Request;
using MinimalAPI.Services.Interface;

namespace MinimalAPI.Endpoints
{
    public static class ProductEndpoints
    {
        public static void RegisterProductAPIs(this IEndpointRouteBuilder app)
        {
            var productApiGroup = app.MapGroup("api/product");

            productApiGroup.MapGet("/get-products", GetAllProducts);
            productApiGroup.MapGet("/{id:int}", GetProductById);
            productApiGroup.MapPost("/add", AddProduct);
            productApiGroup.MapPut("/update/{id:int}", UpdateProduct);
            productApiGroup.MapDelete("/delete/{id:int}", DeleteProduct);
        }

        public async static Task<IResult> GetAllProducts(IProductService service)
        {
            var result = await service.GetAllProductsAsync();
            return result != null ? Results.Ok(result) : Results.NotFound();
        }

        public async static Task<IResult> GetProductById(int id, IProductService service)
        {
            var result = await service.GetProductByIdAsync(id);
            return result != null ? Results.Ok(result) : Results.NotFound();
        }

        public async static Task<IResult> AddProduct(ProductDTO requestObject, IProductService service, IMapper _mapper)
        {
            if (requestObject == null) return Results.BadRequest("Invalid request object");

            var validator = new ProductValidator();
            var validationResult = validator.Validate(requestObject);

            if (validationResult.IsValid)
            {
                var result = await service.AddProductAsync(requestObject);
                return result != null ? Results.Ok(result) : Results.BadRequest(result);
            }
            else
            {
                return Results.BadRequest(validationResult.Errors.Select(e => new
                {
                    Field = e.PropertyName,
                    Error = e.ErrorMessage
                }));
            }
        }

        public async static Task<IResult> UpdateProduct(int id, ProductDTO requestObject, IProductService service, IMapper _mapper)
        {
            if (requestObject == null) return Results.BadRequest("Invalid request object");

            var validator = new ProductValidator();
            var validationResult = validator.Validate(requestObject);

            if (validationResult.IsValid)
            {
                var result = await service.UpdateProductAsync(id, requestObject);
                return result != null ? Results.Ok(result) : Results.BadRequest(result);
            }
            else
            {
                return Results.BadRequest(validationResult.Errors.Select(e => new
                {
                    Field = e.PropertyName,
                    Error = e.ErrorMessage
                }));
            }
        }

        public async static Task<IResult> DeleteProduct(int id, IProductService service)
        {
            var result = await service.DeleteProductAsync(id);
            return result != null ? Results.Ok(result) : Results.NotFound(result);
        }
    }
}