using Serenity.Services;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<Serene3.com.productRow>;
using MyRow = Serene3.com.productRow;

namespace Serene3.com;

public interface IproductRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> { }

public class productRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IproductRetrieveHandler
{
    public productRetrieveHandler(IRequestContext context)
            : base(context)
    {
    }
}