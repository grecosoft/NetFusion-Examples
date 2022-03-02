using System;
using System.Threading.Tasks;
using Demo.Domain.Queries;
using NetFusion.Base.Entity;
using NetFusion.Messaging.Filters;
using NetFusion.Messaging.Types.Contracts;

namespace Demo.Infra
{
    public class TimeQueryFilter :
        IPreQueryFilter,
        IPostQueryFilter
    {
        public Task OnPreExecuteAsync(IQuery query)
        {
            if (query is ITimestamp timestamp)
            {
                timestamp.CurrentDate = DateTime.UtcNow;
            }

            return Task.CompletedTask;
        }

        public Task OnPostExecuteAsync(IQuery query)
        {
            if (query is ITimestamp timestamp && query.Result is IAttributedEntity attributed)
            {
                attributed.Attributes.Values.DayOfWeek = timestamp.CurrentDate.DayOfWeek;
            }
            
            return Task.CompletedTask;
        }
    }
}
