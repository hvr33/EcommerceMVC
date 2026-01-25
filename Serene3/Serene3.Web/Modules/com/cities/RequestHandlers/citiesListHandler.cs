using Serenity.Services;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<Serene3.com.citiesRow>;
using MyRow = Serene3.com.citiesRow;

namespace Serene3.com;

public interface IcitiesListHandler : IListHandler<MyRow, MyRequest, MyResponse> { }

public class citiesListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IcitiesListHandler
{
    public citiesListHandler(IRequestContext context)
            : base(context)
    {
    }
}