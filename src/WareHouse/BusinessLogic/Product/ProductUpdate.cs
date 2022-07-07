#nullable enable
namespace LasMarias.WareHouse.BusinessLogic.Product;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Serilog;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;
using Orun;
using Orun.Plugins;
using Orun.Extensions;
using LasMarias.WareHouse.Domain.DataModels.Product;
using LasMarias.WareHouse.Domain.Models;
using LasMarias.WareHouse.Domain.Repositories;

public class ProductUpdate : 
    IAsyncMiddleware<ProductUpdateInputModel, Domain.Models.Product>, IMiddlewarePlugin
{
    private IServiceScope? _scope;
    
    private IProductRepository? _repository;

    private IAttributeRepository _attrRepository;

    private ICategoryRepository _catRepository;

    private IProductPhotoRepository _prodPhotoRepository;

    private IBrandRepository _brandRepository;

    private IProductBrandRepository _productBrandRepository;

    public string Name { get; set; } 

    public string Version { get; set; } 

    public string Author { get; set; } 

    public string Description { get; set; } 

    public string EventCode { get; set; } 

    public Guid PluginId { get; set; } 

    public string ShortName { get; set; } 

    public bool Enable { get; set; } 

    public int Level { get; set; }

    public ICollection<Dependency>? Dependencies { get; set; }

    public ProductUpdate()
    {
        Name = "WareHouse Product Update Business Logic plugin";
        Version = "0.0.1";
        PluginId = Guid.NewGuid();
        Author = "Orun Innovations";
        Description = "returns a updated Product";
        ShortName = "WareHouse Product Update";
        Enable = true;
        Level = 0; // this MUST be the first plugn to execute
        Dependencies = new List<Dependency>();
        EventCode = "product-update";
    }

    public WebApplication? Configure(WebApplication builder)
    {
        Log.Debug($"Configure plugin {ShortName}: event {EventCode}");
        _scope = builder.Services.CreateScope();
        return builder;
    }
        
    public IServiceCollection? ConfigureServices(IServiceCollection services)
    {
        Log.Debug($"Configure services for plugin {ShortName}: event {EventCode}");
        return services;
    }

    // >.Run(ProductUpdateInputModel, Func<ProductUpdateInputModel, Task<Product>>)
    public async Task<Domain.Models.Product> Run(ProductUpdateInputModel parameter, 
        Func<ProductUpdateInputModel, Task<Domain.Models.Product>> next)
    {
        try
        {
            Domain.Models.Product entity;
            
            Log.Debug($"Executing plugin '{ShortName}': event '{EventCode}'");

            _repository = (IProductRepository)_scope?.ServiceProvider.GetService<IProductRepository>();
            _attrRepository = (IAttributeRepository)_scope?.ServiceProvider.GetService<IAttributeRepository>();
            _catRepository = (ICategoryRepository)_scope?.ServiceProvider.GetService<ICategoryRepository>();
            _prodPhotoRepository = (IProductPhotoRepository)_scope?.ServiceProvider.GetService<IProductPhotoRepository>();
            _productBrandRepository = (IProductBrandRepository)_scope?.ServiceProvider.GetService<IProductBrandRepository>();
            _brandRepository = (IBrandRepository)_scope?.ServiceProvider.GetService<IBrandRepository>();

            if(_repository == null)
            {
                throw new NullReferenceException($"Repository could not be null");
            }
            
            if(!(await _repository.Any(x => x.ProductId == parameter.Id)))
            {
                throw new Exception($"Product with id {parameter.Id} was not found");
            }

            // execute the chain and get entity
            entity = await next(parameter);
            
            // look if some middleware has alreay generate the entity and insert it into the
            // database, otherwise create it and save changes.
            if(entity == null)
            {    
                // map entry into a real entity
                var mappedEntity = _repository.Mapper.Map<Domain.Models.Product>(parameter);
                entity = (Domain.Models.Product)(await _repository.GetOne(x => x.ProductId == parameter.Id));

                if(entity == null)
                {
                    throw new Exception($"Attrbute with id {parameter.Id} was not found");
                }

                // map properties
                entity.Name = mappedEntity.Name.ThenIfNullOrEmpty(entity.Name);
                entity.Description = mappedEntity.Description.ThenIfNullOrEmpty(entity.Description);
                entity.Note = mappedEntity.Note.ThenIfNullOrEmpty(entity.Note);
                entity.Price = mappedEntity.Price.ThenIfNullOrEmpty(entity.Price);
                entity.SellingPrice = mappedEntity.SellingPrice.ThenIfNullOrEmpty(entity.SellingPrice);
                entity.Amount = mappedEntity.Amount.ThenIfNullOrEmpty(entity.Amount);
                entity.ReOrderLevel = mappedEntity.ReOrderLevel.ThenIfNullOrEmpty(entity.ReOrderLevel);

                // register attributes
                foreach(var attrId in parameter.AttributesIds)
                {
                    if(!(await _attrRepository.Any(x => x.AttributesId == attrId)))
                    {
                        throw new Exception($"Attribute with id: {attrId} was not found");
                    }

                    var attr = await _attrRepository.GetOne(x => x.AttributeId == attrId);
                    if(!entity.Attributes.Contains(attr))
                    {
                        entity.Attributes.Add(attr);
                    }
                }
                
                // register categories
                foreach(var catId in parameter.CategoriesIds)
                {
                    if(!(await _catRepository.Any(x => x.CategoryId == catId)))
                    {
                        throw new Exception($"Category with id: {catId} was not found");
                    }

                    var cat = await _catRepository.GetOne(x => x.CategoryId == catId);
                    if(!entity.Categories.Contains(cat))
                    {
                        entity.Categoris.Add(cat);
                    }
                }

                // register product photos
                foreach(var photoId in parameter.ProductPhotosIds)
                {
                    if(!(await _prodPhotoRepository.Any(x => x.ProductPhotoId == photoId)))
                    {
                        throw new Exception($"Product Photo with id: {photoId} was not found");
                    }

                    var photo = await _prodPhotoRepository.GetOne(x => x.ProductPhotoId == photoId);
                    if(!entity.ProductPhotos.Contains(photo))
                    {
                        entity.ProductPhotos.Add(photo);
                    }
                }

                // register product photos
                foreach(var brandId in parameter.ProductBrandsIds)
                {
                    if(!(await _brandRepository.Any(x => x.ProductBrandId == brandId)))
                    {
                        throw new Exception($"Product Photo with id: {photoId} was not found");
                    }

                    var photo = await _prodPhotoRepository.GetOne(x => x.ProductBrandId == photoId);
                    if(!entity.ProductBrands.Contains(photo))
                    {
                        entity.ProductPhotos.Add(photo);
                    }
                }

                await _repository.Update(entity.ProductId, entity);
            }
            
            // no exception throw so we are ready to save entity
            await _repository.UnitOfWork.SaveAsync();

            // return the entity of inserted data
            return await Task.FromResult(entity);
        }
        catch (Exception ex)
        {
            Log.Error($"Exception running plugin {ShortName}: event {EventCode}: {ex.FullMessage()}");
            Insist.Throw<Exception>(ex.FullMessage());
            throw;
        }
    }
}