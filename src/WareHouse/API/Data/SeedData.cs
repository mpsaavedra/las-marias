namespace LasMarias.WareHouse.Data;

using Microsoft.EntityFrameworkCore;
using LasMarias.WareHouse.Domain.Models;

public static class SeedData
{
    public static void EnsureSeedData(WebApplication app)
    {
        using (var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
        {
            var context = scope.ServiceProvider.GetService<ApplicationDbContext>();
            context?.Database.Migrate();
            EnsureSeedData(context!);
        }
    }

    private static void EnsureSeedData(ApplicationDbContext context)
    {
        if(!context.MeasureUnits.Any())
        {
            context.MeasureUnits.AddRange(new MeasureUnit[]
            {
                new MeasureUnit { Name = "Onza", Code = "onz" },
                new MeasureUnit { Name = "Libra", Code = "lib" },
                new MeasureUnit { Name = "Kilogramo", Code = "kg" },
                new MeasureUnit { Name = "Tonelada", Code = "ton" },
                new MeasureUnit { Name = "Quintal", Code = "qnt" },
                new MeasureUnit { Name = "Unidad", Code = "u" },
                new MeasureUnit { Name = "Par", Code = "par" },
                new MeasureUnit { Name = "Docena", Code = "dozen" },
                new MeasureUnit { Name = "Vaso", Code = "vaso" },
                new MeasureUnit { Name = "Copa", Code = "copa" },
                new MeasureUnit { Name = "Litro", Code = "lt" },
                new MeasureUnit { Name = "Galon", Code = "gal" },
                new MeasureUnit { Name = "Milimetro", Code = "mm" },
                new MeasureUnit { Name = "Centimetro", Code = "cm" },
                new MeasureUnit { Name = "Decimetro", Code = "dcm" },
                new MeasureUnit { Name = "Metro", Code = "m" },
                new MeasureUnit { Name = "Onza cubica", Code = "onz3" },
                new MeasureUnit { Name = "Centimetro cubico", Code = "cm3" },
                new MeasureUnit { Name = "Caja", Code = "caja" },
                new MeasureUnit { Name = "Paquete", Code = "paq" },
                new MeasureUnit { Name = "Parlet", Code = "parlet" }
            });
            context.SaveChanges();
        }

        if(!context.Categories.Any())
        {
            var softDrinks = new Category { Name = "Refrescos", Code = "softdrinks" };
            var naturalSoftDrinks = new Category { Name = "Refresco Natural", Code = "natural-softdrinks" };
            var artificialSoftDrinks = new Category { Name = "Refresco Artificial", Code = "artificial-softdrinks" };
            var juice = new Category { Name = "Jugos", Code = "juices" };
            var naturalJuices = new Category { Name = "Jugos Naturales", Code = "natural-juices" };
            var artificialJuices = new Category { Name = "Jugos Artificiales", Code = "artificial-juices" };
            var drinks = new Category { Name = "Bebidas", Code = "beberage" };
            var nonAlcoholDrinks = new Category { Name = "Bebidas sin alcohol", Code = "non-alcohol-drinks" };
            var withAlcoholDrinks = new Category { Name = "Bebidas con alcohol", Code = "with-alcohol-drinks" };
            var meats = new Category { Name = "Carnes", Code = "meats" };
            var curatedMeats = new Category { Name = "Carnes Curadas", Code = "curated-meats" };
            var freshMeats = new Category { Name = "Carnes frescas", Code = "fresh-meats" };
            var birdMeat = new Category { Name = "Carne de aves", Code = "bird-meat" };
            var animalMeat = new Category { Name = "Carne de animales", Code = "animal-meat" };
            var grains = new Category { Name = "Granos", Code = "granes" };
            var beans = new Category { Name = "Frijoles", Code = "beans" };
            var rice = new Category { Name = "Arroz", Code = "rice" };
            var fish = new Category { Name = "Pescado", Code = " fish" };
            var freshFish = new Category { Name = "Pescado fresco", Code = "fresh-fish" };
            var processedFish = new Category { Name = "Pescado procesado", Code = "processeds-fish" };
            var condiments = new Category { Name = "Condimentos", Code = "condiments" };
            var naturalCondiments = new Category { Name = "Condimentos naturales", Code = "natural-condiments" };
            var processedCondiments = new Category { Name = "Condimentos procesados", Code = "processed-condiments" };

            // save all new categories
            context.Categories.Add(softDrinks);
            context.Categories.Add(naturalSoftDrinks);
            context.Categories.Add(artificialSoftDrinks);
            context.Categories.Add(juice);
            context.Categories.Add(naturalJuices);
            context.Categories.Add(artificialJuices);
            context.Categories.Add(drinks);
            context.Categories.Add(nonAlcoholDrinks);
            context.Categories.Add(withAlcoholDrinks);
            context.Categories.Add(meats);
            context.Categories.Add(curatedMeats);
            context.Categories.Add(freshMeats);
            context.Categories.Add(birdMeat);
            context.Categories.Add(animalMeat);
            context.Categories.Add(grains);
            context.Categories.Add(beans);
            context.Categories.Add(rice);
            context.Categories.Add(fish);
            context.Categories.Add(freshFish);
            context.Categories.Add(processedFish);
            context.Categories.Add(condiments);
            context.Categories.Add(naturalCondiments);
            context.Categories.Add(processedCondiments);
            context.SaveChanges();

            // create relations
            softDrinks.ChildCategories.Add(naturalSoftDrinks);
            softDrinks.ChildCategories.Add(artificialSoftDrinks);
            juice.ChildCategories.Add(naturalJuices);
            juice.ChildCategories.Add(artificialJuices);
            drinks.ChildCategories.Add(nonAlcoholDrinks);
            drinks.ChildCategories.Add(withAlcoholDrinks);
            meats.ChildCategories.Add(curatedMeats);
            meats.ChildCategories.Add(freshMeats);
            meats.ChildCategories.Add(birdMeat);
            meats.ChildCategories.Add(animalMeat);
            grains.ChildCategories.Add(beans);
            grains.ChildCategories.Add(rice);
            fish.ChildCategories.Add(freshFish);
            fish.ChildCategories.Add(processedFish);
            condiments.ChildCategories.Add(naturalCondiments);
            condiments.ChildCategories.Add(processedCondiments);
            context.SaveChanges();
        }

        if(!context.AttributeNames.Any())
        {
            // var weight
        }
    }
}