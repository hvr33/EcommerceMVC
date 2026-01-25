using Serenity.Services;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<Serene3.com.productimageRow>;
using MyRow = Serene3.com.productimageRow;

namespace Serene3.com;

public interface IproductimageRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> { }

public class productimageRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IproductimageRetrieveHandler
{
    public productimageRetrieveHandler(IRequestContext context)
            : base(context)
    {
    }
}