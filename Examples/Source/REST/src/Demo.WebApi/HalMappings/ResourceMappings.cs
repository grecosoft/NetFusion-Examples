// ReSharper disable RedundantUsingDirective
using System.Net.Http;
using System.Threading.Tasks;
using Demo.WebApi.Controllers;
using Demo.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using NetFusion.Rest.Common;
using NetFusion.Rest.Server.Hal;

namespace Demo.WebApi.HalMappings
{
#pragma warning disable CS4014
    namespace ApiHost.Relations
    {
        public class ResourceMappings : HalResourceMap
        {
            protected override void OnBuildResourceMap()
            {
                // ------------------------------------------------------
                // For Example: Controller/Model Lambda Expression
                // ------------------------------------------------------
                
                // Map<ListingModel>()    
                //     .LinkMeta<ListingController>(meta =>
                //     {
                //         meta.Url(RelationTypes.Self, (c, r) => c.GetListing(r.ListingId));
                //         meta.Url("listing:update", (c, r) => c.UpdateListing(r.ListingId, default));
                //         meta.Url("listing:delete", (c, r) => c.DeleteListing(r.ListingId));
                //     })
                //
                //     .LinkMeta<PriceHistoryController>(meta => {
                //         meta.Url(RelationTypes.History.Archives, (c, r) => c.GetPriceHistoryEvents(r.ListingId));
                //     });
                
                // ------------------------------------------------------
                // For Example: Hard-Coded URL
                // ------------------------------------------------------
                
                // Map<ListingModel>()
                //     .LinkMeta(meta => meta.Href("conn", HttpMethod.Get, "https://www.realtor.com/propertyrecord-search/Connecticut"))
                //     .LinkMeta(meta => meta.Href("conn-cheshire", HttpMethod.Get, "https://www.realtor.com/realestateandhomes-search/Cheshire_CT"));
                
                // ------------------------------------------------------
                // For Example: Resource String Interpolated URL String
                // ------------------------------------------------------
                
                // Map<ListingModel>()
                //     .LinkMeta(meta => meta.Href(RelationTypes.Alternate, HttpMethod.Get, 
                //         r => $"http://www.homes.com/for/sale/{r.ListingId}"));
                
                // ------------------------------------------------------
                // URL Template
                // ------------------------------------------------------
                
                // Map<ListingModel>()
                //     .LinkMeta<PriceHistoryController>(meta => meta.UrlTemplate<int, IActionResult>(
                //         "listing:prices", c => c.GetPriceHistoryEvents));
                
                // ------------------------------------------------------
                // Embedded Resources and Models
                // ------------------------------------------------------
                
                // Map<ListingModel>()
                //     .LinkMeta<ListingController>(meta =>
                //     {
                //         meta.Url(RelationTypes.Self, (c, r) => c.GetListing(r.ListingId));
                //         meta.Url("listing:update", (c, r) => c.UpdateListing(r.ListingId, default));
                //         meta.Url("listing:delete", (c, r) => c.DeleteListing(r.ListingId));
                //     });
                //
                // Map<PriceHistoryModel>()
                //     .LinkMeta<PriceHistoryController>(meta =>
                //     {
                //         meta.Url(RelationTypes.Self, (c, r) => c.GetPriceHistory(r.PriceHistoryId));
                //         meta.Url("events", (c, r) => c.GetPriceHistoryEvents(r.ListingId));
                //     });
            }
        }
    }
}