namespace LasMarias.BusinessLogic.Product;

public class ProductUpdate : IAsyncMiddleware<ProductUpdateInputModel, Domain.Models.Product>, IMiddlewarePlugin
{
    private IServiceScope? _scope;

    private IProductRepository? _repository;

    private IAttributeRepository? _aRepository;

    private ICategoryRepository? _cRepository;

    private IMeasureUnitRepository? _muRepository;

    private IProductPhotoRepository? _ppRepository;

    private IProductBrandRepository? _pbRepository;

    private IBrandRepository? _bRepository;

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

    public WebApplication? Configure(WebApplication builder)
    {
        _scope = builder.Services.CreateScope();
        return builder;
    }

    public IServiceCollection? ConfigureServices(IServiceCollection services)
    {
        return services;
    }

    public ProductUpdate()
    {
        Name = "Product Update Business Logic plugin";
        Version = "0.0.1";
        PluginId = Guid.NewGuid();
        Author = "Orun Innovations LLC";
        Description = "Updates an existing Product";
        ShortName = "Update Product";
        Enable = true;
        Level = 0;
        Dependencies = new List<Dependency>();
        EventCode = EventCodes.ProductUpdate;
    }

    public async Task<Domain.Models.Product> Run(
       Domain.DataModels.Product.ProductUpdateInputModel parameter,
       Func<ProductUpdateInputModel, Task<Domain.Models.Product>> next
   )
    {
        try
        {
            Log.Debug($"Executing plugin '{ShortName}': event '{EventCode}'");
            _repository = _scope?.ServiceProvider.GetService<IProductRepository>();
            _aRepository = _scope?.ServiceProvider.GetService<IAttributeRepository>();
            _cRepository = _scope?.ServiceProvider.GetService<ICategoryRepository>();
            _pbRepository = _scope?.ServiceProvider.GetService<IProductBrandRepository>();
            _bRepository = _scope?.ServiceProvider.GetService<IBrandRepository>();
            _muRepository = _scope?.ServiceProvider.GetService<IMeasureUnitRepository>();
            _ppRepository = _scope?.ServiceProvider.GetService<IProductPhotoRepository>();

            if (_repository == null)
            {
                throw new NullReferenceException($"Product: Repository could not be null");
            }

            if (Is.NullOrEmpty(_aRepository!, _cRepository!, _muRepository!, _ppRepository!, _pbRepository!, _bRepository!))
            {
                throw new Exception("Product Update: Repository(s) could not be null");
            }

            Domain.Models.Product entity = await next(parameter);

            if (entity == null)
            {
                var id = parameter.Id;
                var data = _repository.Mapper.Map<Domain.Models.Product>(parameter);
                entity = await _repository.GetOne(x => x.ProductId == id);
                if (entity == null)
                {
                    throw new Exception($"Product Update: Entity with id {id} was not found");
                }

                if (!Is.NullOrAnyNull(parameter.AttributesIds))
                {
                    foreach (var attribute in parameter.AttributesIds.Value!)
                    {
                        var attr = await _aRepository!.GetOne(x => x.AttributeId == attribute);
                        if (Is.NullOrEmpty(attr))
                        {
                            throw new Exception($"Attribute with id {attribute} was not found");
                        }
                        if (entity.Attributes!.Any(x => x.AttributeId == attribute))
                        {
                            entity.Attributes!.Add(attr);
                        }
                    }
                }
                else
                {
                    throw new Exception("Product Update: AttributeIds must not contain null or empty values");
                }

                if (!Is.NullOrAnyNull(parameter.CategoriesIds))
                {
                    foreach (var eid in parameter.CategoriesIds.Value!)
                    {
                        var ent = await _cRepository!.GetOne(x => x.CategoryId == eid);
                        if (Is.NullOrEmpty(ent))
                        {
                            throw new Exception($"Attribute with id {eid} was not found");
                        }
                        if (entity.Categories!.Any(x => x.CategoryId == eid))
                        {
                            entity.Categories!.Add(ent);
                        }
                    }
                }
                else
                {
                    throw new Exception("Product Update: CategoriesIds must not contain null or empty values");
                }

                if (!Is.NullOrAnyNull(parameter.ProductPhotosIds))
                {
                    foreach (var eid in parameter.ProductPhotosIds.Value!)
                    {
                        var ent = await _ppRepository!.GetOne(x => x.ProductPhotoId == eid);
                        if (Is.NullOrEmpty(ent))
                        {
                            throw new Exception($"ProdutPhoto with id {eid} was not found");
                        }
                        if (entity.ProductPhotos!.Any(x => x.ProductPhotoId == eid))
                        {
                            entity.ProductPhotos!.Add(ent);
                        }
                    }
                }
                else
                {
                    throw new Exception("Product Update: ProductPhotosIds must not contain null or empty values");
                }

                if (!Is.NullOrAnyNull(parameter.ProductBrandsIds))
                {
                    foreach (var eid in parameter.ProductBrandsIds.Value!)
                    {
                        var ent = await _pbRepository!.GetOne(x => x.ProductBrandId == eid);
                        if (Is.NullOrEmpty(ent))
                        {
                            throw new Exception($"ProdutBrand with id {eid} was not found");
                        }
                        if (entity.ProductBrands!.Any(x => x.ProductBrandId == eid))
                        {
                            entity.ProductBrands!.Add(ent);
                        }
                    }
                }
                else
                {
                    throw new Exception("Product Update: ProductPhotosIds must not contain null or empty values");
                }

                entity.Name = Is.ThenIfNullOrEmpty(parameter.Name.Value, entity.Name)!;
                entity.Description = Is.ThenIfNullOrEmpty(parameter.Description.Value, entity.Description)!;
                entity.Note = Is.ThenIfNullOrEmpty(parameter.Note.Value, entity.Description)!;
                entity.Price = Is.ThenIfNullOrEmpty(parameter.Price.Value, entity.Price)!;
                entity.SellingPrice = Is.ThenIfNullOrEmpty(parameter.SellingPrice.Value, entity.SellingPrice)!;
                entity.Amount = Is.ThenIfNullOrEmpty(parameter.Amount.Value, entity.Amount)!;
                entity.ReOrderLevel = Is.ThenIfNullOrEmpty(parameter.ReOrderLevel.Value, entity.ReOrderLevel)!;


                await _repository.Update(id, entity);
            }

            await _repository.UnitOfWork.SaveAsync();

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