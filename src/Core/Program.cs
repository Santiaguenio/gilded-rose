using GildedRose.Core.Items;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GildedRose.Core;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("OMGHAI!");

        var services = new ServiceCollection();

        var knownItems = typeof(IUpdatable).Assembly
            .Modules
            .SelectMany(a => a.GetTypes())
            .Where(t => !t.IsAbstract && !t.IsInterface && typeof(IUpdatable).IsAssignableFrom(t));

        foreach (var knownItem in knownItems)
        {
            services.AddTransient(typeof(IUpdatable), knownItem);
        }

        services.AddScoped<ItemBuilder>();
        var builtServices = services.BuildServiceProvider();

        var items = new List<Item>
        {
            new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
            new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
            new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
            new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
            new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80},
            new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 15,
                Quality = 20
            },
            new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 10,
                Quality = 49
            },
            new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 5,
                Quality = 49
            },
            // this conjured item does not work properly yet
            new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
        };

        var app = new GildedRose(items, builtServices.GetRequiredService<ItemBuilder>());

        int days = 2;
        if (args.Length > 0)
        {
            days = int.Parse(args[0]) + 1;
        }

        for (var i = 0; i < days; i++)
        {
            Console.WriteLine("-------- day " + i + " --------");
            Console.WriteLine("name, sellIn, quality");
            for (var j = 0; j < items.Count; j++)
            {
                Console.WriteLine(items[j].Name + ", " + items[j].SellIn + ", " + items[j].Quality);
            }
            Console.WriteLine("");

            if (i == 5)
            {
                Console.WriteLine();
            }
            app.UpdateQuality();
        }
    }
}