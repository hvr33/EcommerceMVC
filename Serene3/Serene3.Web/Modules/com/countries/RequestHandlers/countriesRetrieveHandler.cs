using Serenity.Services;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<Serene3.com.countriesRow>;
using MyRow = Serene3.com.countriesRow;

namespace Serene3.com;

public interface IcountriesRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> { }

public class countriesRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IcountriesRetrieveHandler
{
    public countriesRetrieveHandler(IRequestContext context)
            : base(context)
    {
    }
}