using System;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;

namespace Restaurents.Application.Common;

public class PageResult<T>
{
    public PageResult(IEnumerable<T> Items, int TotlaCount, int PageSize, int PageNumber)
    {
        this.Items = Items;
        TotalItemsCount = TotlaCount;
        TotalPages = (int)Math.Ceiling(TotlaCount / (double)PageSize);
        ItemsFrom = PageSize * (PageNumber - 1) + 1;
        ItemsTo = ItemsFrom + PageSize - 1;

    }
    public IEnumerable<T> Items { get; set; }
    public int TotalPages { get; set; }
    public int TotalItemsCount { get; set; }
    public int ItemsFrom { get; set; }
    public int ItemsTo { get; set; }
}
