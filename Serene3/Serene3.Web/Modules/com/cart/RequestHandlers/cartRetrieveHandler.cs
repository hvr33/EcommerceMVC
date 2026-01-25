using Serenity.Services;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<Serene3.com.cartRow>;
using MyRow = Serene3.com.cartRow;

namespace Serene3.com;

public interface IcartRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> { }

public class cartRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IcartRetrieveHandler
{
    public cartRetrieveHandler(IRequestContext context)
            : base(context)
    {
    }
}