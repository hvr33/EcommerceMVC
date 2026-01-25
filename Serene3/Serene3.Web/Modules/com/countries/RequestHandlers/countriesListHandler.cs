using Serenity.Services;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<Serene3.com.countriesRow>;
using MyRow = Serene3.com.countriesRow;

namespace Serene3.com;

public interface IcountriesListHandler : IListHandler<MyRow, MyRequest, MyResponse> { }

public class countriesListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IcountriesListHandler
{
    public countriesListHandler(IRequestContext context)
            : base(context)
    {
    }
}