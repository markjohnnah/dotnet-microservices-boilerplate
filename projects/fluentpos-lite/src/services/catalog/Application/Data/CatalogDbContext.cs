﻿using FluentPOS.Lite.Catalog.Domain.Entities;
using FSH.Persistence.MongoDb;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace FluentPOS.Lite.Catalog.Application.Data;

public class CatalogDbContext : MongoDbContext
{
    public IMongoCollection<Product> Products { get; }
    public CatalogDbContext(IOptions<MongoOptions> options) : base(options)
    {
        Products = GetCollection<Product>();
    }
}
