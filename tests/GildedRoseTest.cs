using GildedRose.Core;
using GildedRose.Core.Items;
using System.Collections.Generic;
using Xunit;

namespace GildedRose.Tests;

public class GildedRoseTest
{
    [Fact]
    public void foo()
    {
        var items = new List<Item> { new() { Name = "foo", SellIn = 0, Quality = 0 } };
        var app = new Core.GildedRose(items, new ItemTypeFactory([new NormalItem { Name = "foo" }]));
        app.UpdateQuality();
        Assert.Equal("foo", items[0].Name);
    }
}