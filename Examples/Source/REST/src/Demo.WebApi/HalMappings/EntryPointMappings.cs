using System.Threading.Tasks;
using Demo.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using NetFusion.Rest.Resources;
using NetFusion.Rest.Server.Hal;

#pragma warning disable CS4014
namespace Demo.WebApi.HalMappings
{
    public class EntityPointMappings : HalResourceMap
    {
        protected override void OnBuildResourceMap()
        {
            Map<EntryPointModel>()
                .LinkMeta<ListingController>(meta =>
                {
                    meta.UrlTemplate<int, Task<IActionResult>>("listing:entry", c => c.GetListing);
                })
                .LinkMeta<PriceHistoryController>(meta =>
                {
                    meta.UrlTemplate<int, IActionResult>("history:entry", c => c.GetPriceHistory);
                });
        }
    }
}
