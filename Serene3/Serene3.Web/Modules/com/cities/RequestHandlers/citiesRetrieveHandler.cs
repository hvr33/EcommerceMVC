using Serenity.Services;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<Serene3.com.citiesRow>;
using MyRow = Serene3.com.citiesRow;

namespace Serene3.com;

public interface IcitiesRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> { }

public class citiesRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IcitiesRetrieveHandler
{
    public citiesRetrieveHandler(IRequestContext context)
            : base(context)
    {
    }
}