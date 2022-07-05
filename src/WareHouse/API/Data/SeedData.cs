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
        Category softDrinks;
        Category naturalSoftDrinks;
        Category artificialSoftDrinks;
        Category juice;
        Category naturalJuices;
        Category artificialJuices;
        Category drinks;
        Category nonAlcoholDrinks;
        Category withAlcoholDrinks;
        Category meats;
        Category curatedMeats;
        Category freshMeats;
        Category birdMeat;
        Category animalMeat;
        Category grains;
        Category beans;
        Category rice;
        Category fish;
        Category freshFish;
        Category processedFish;
        Category condiments;
        Category naturalCondiments;
        Category processedCondiments;
        MeasureUnit onza;
        MeasureUnit libra;
        MeasureUnit kilogramo;
        MeasureUnit tonelada;
        MeasureUnit quintal;
        MeasureUnit unidad;
        MeasureUnit par;
        MeasureUnit docena;
        MeasureUnit vaso;
        MeasureUnit copa;
        MeasureUnit litro;
        MeasureUnit galon;
        MeasureUnit milimetro;
        MeasureUnit centimetro;
        MeasureUnit decimetro;
        MeasureUnit metro;
        MeasureUnit caja;
        MeasureUnit paquete;
        MeasureUnit parlet;
        AttributeName weight;
        AttributeName color;
        AttributeName size;
        AttributeName quantity;
        AttributeName volumen;
        Attribute colorW;
        Attribute colorB;
        Attribute colorY;
        Attribute colorR;
        Attribute size2Pack;
        Attribute size1Box;
        Attribute size12Pack;

        if (!context.MeasureUnits.Any())
        {
            onza = new MeasureUnit { Name = "Onza", Code = "onz", Cast = Cast.ToDecimal };
            libra = new MeasureUnit { Name = "Libra", Code = "lib", Cast = Cast.ToDecimal };
            kilogramo = new MeasureUnit { Name = "Kilogramo", Code = "kg", Cast = Cast.ToDecimal };
            tonelada = new MeasureUnit { Name = "Tonelada", Code = "ton", Cast = Cast.ToDecimal };
            quintal = new MeasureUnit { Name = "Quintal", Code = "qnt", Cast = Cast.ToDecimal };
            unidad = new MeasureUnit { Name = "Unidad", Code = "u", Cast = Cast.ToDecimal };
            par = new MeasureUnit { Name = "Par", Code = "par", Cast = Cast.ToDecimal };
            docena = new MeasureUnit { Name = "Docena", Code = "dozen", Cast = Cast.ToDecimal };
            vaso = new MeasureUnit { Name = "Vaso", Code = "vaso", Cast = Cast.ToDecimal };
            copa = new MeasureUnit { Name = "Copa", Code = "copa", Cast = Cast.ToDecimal };
            litro = new MeasureUnit { Name = "Litro", Code = "lt", Cast = Cast.ToDecimal };
            galon = new MeasureUnit { Name = "Galon", Code = "gal", Cast = Cast.ToDecimal };
            milimetro = new MeasureUnit { Name = "Milimetro", Code = "mm", Cast = Cast.ToDecimal };
            centimetro = new MeasureUnit { Name = "Centimetro", Code = "cm", Cast = Cast.ToDecimal };
            decimetro = new MeasureUnit { Name = "Decimetro", Code = "dcm", Cast = Cast.ToDecimal };
            metro = new MeasureUnit { Name = "Metro", Code = "m", Cast = Cast.ToDecimal };
            caja = new MeasureUnit { Name = "Caja", Code = "caja", Cast = Cast.ToDecimal };
            paquete = new MeasureUnit { Name = "Paquete", Code = "paq", Cast = Cast.ToDecimal };
            parlet = new MeasureUnit { Name = "Parlet", Code = "parlet", Cast = Cast.ToDecimal };

            context.MeasureUnits.AddRange(new MeasureUnit[]
            {
                onza, libra, kilogramo, tonelada, quintal, unidad, par, docena, vaso, copa, litro, 
                galon, milimetro, centimetro, decimetro, metro, caja, paquete, parlet
            });
            context.SaveChanges();
        }

        if (!context.Categories.Any())
        {
            softDrinks = new Category { Name = "Refrescos", Code = "softdrinks" };
            naturalSoftDrinks = new Category { Name = "Refresco Natural", Code = "natural-softdrinks" };
            artificialSoftDrinks = new Category { Name = "Refresco Artificial", Code = "artificial-softdrinks" };
            juice = new Category { Name = "Jugos", Code = "juices" };
            naturalJuices = new Category { Name = "Jugos Naturales", Code = "natural-juices" };
            artificialJuices = new Category { Name = "Jugos Artificiales", Code = "artificial-juices" };
            drinks = new Category { Name = "Bebidas", Code = "beberage" };
            nonAlcoholDrinks = new Category { Name = "Bebidas sin alcohol", Code = "non-alcohol-drinks" };
            withAlcoholDrinks = new Category { Name = "Bebidas con alcohol", Code = "with-alcohol-drinks" };
            meats = new Category { Name = "Carnes", Code = "meats" };
            curatedMeats = new Category { Name = "Carnes Curadas", Code = "curated-meats" };
            freshMeats = new Category { Name = "Carnes frescas", Code = "fresh-meats" };
            birdMeat = new Category { Name = "Carne de aves", Code = "bird-meat" };
            animalMeat = new Category { Name = "Carne de animales", Code = "animal-meat" };
            grains = new Category { Name = "Granos", Code = "granes" };
            beans = new Category { Name = "Frijoles", Code = "beans" };
            rice = new Category { Name = "Arroz", Code = "rice" };
            fish = new Category { Name = "Pescado", Code = " fish" };
            freshFish = new Category { Name = "Pescado fresco", Code = "fresh-fish" };
            processedFish = new Category { Name = "Pescado procesado", Code = "processeds-fish" };
            condiments = new Category { Name = "Condimentos", Code = "condiments" };
            naturalCondiments = new Category { Name = "Condimentos naturales", Code = "natural-condiments" };
            processedCondiments = new Category { Name = "Condimentos procesados", Code = "processed-condiments" };

            // save all new categories
            context.Categories.AddRange( new Category[] 
            {
                softDrinks, naturalSoftDrinks, artificialSoftDrinks, juice, naturalJuices, 
                artificialJuices, drinks, nonAlcoholDrinks, withAlcoholDrinks, meats, curatedMeats, 
                freshMeats, birdMeat, animalMeat, grains, beans, rice, fish, freshFish, processedFish, 
                condiments, naturalCondiments, processedCondiments
            });
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

        if (!context.AttributeNames.Any())
        {
            weight = new AttributeName { Name = "Peso" };
            color = new AttributeName { Name = "Color" };
            size = new AttributeName { Name = "Tamaño" };
            quantity = new AttributeName { Name = "Cantidad" };
            volumen = new AttributeName { Name = "Volumen" };
            context.AttributeNames.AddRange(new AttributeName[]
            {
                weight, color, size, quantity, volumen
            });
            context.SaveChanges();
        }

        if(!context.Attributes.Any())
        {
            weight = context?.AttributeNames.FirstOrDefault(x => x.Name == "Peso")!;
            color = context?.AttributeNames.FirstOrDefault(x => x.Name == "Color")!;
            size = context?.AttributeNames.FirstOrDefault(x => x.Name == "Tamaño")!;
            quantity = context?.AttributeNames.FirstOrDefault(x => x.Name == "Cantidad")!;
            volumen = context?.AttributeNames.FirstOrDefault(x => x.Name == "Volumen")!;

            unidad = context.MeasureUnits.FirstOrDefault(x => x.Name == "Unidad");
            caja = context.MeasureUnits.FirstOrDefault(x => x.Name == "Caja");
            paquete = context.MeasureUnits.FirstOrDefault(x => x.Name == "Paquete");
            
            colorW = new Attribute { Value = "Color Blanco", AttributeName = color};
            colorB = new Attribute { Value = "Color Negro", AttributeName = color};
            colorY = new Attribute { Value = "Color Amarillo", AttributeName = color};
            colorR = new Attribute { Value = "Color Rojo", AttributeName = color};
            size2Pack = new Attribute { Value = "Pack de 2", AttributeName = size, MeasureUnit = unidad};
            size1Box = new Attribute { Value = "1 Caja", AttributeName = size, MeasureUnit = unidad};
            size12Pack = new Attribute { Value = "Pack de 12", AttributeName = size, MeasureUnit = unidad};

            context.Attributes.AddRange(new Attribute[]
            {
                colorW, colorB, colorY, colorR, size12Pack, size1Box, size12Pack
            });

            context.SaveChanges();
        }
    }
}