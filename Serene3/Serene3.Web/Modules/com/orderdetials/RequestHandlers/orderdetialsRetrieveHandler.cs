using Serenity.Services;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<Serene3.com.orderdetialsRow>;
using MyRow = Serene3.com.orderdetialsRow;

namespace Serene3.com;

public interface IorderdetialsRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> { }

public class orderdetialsRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IorderdetialsRetrieveHandler
{
    public orderdetialsRetrieveHandler(IRequestContext context)
            : base(context)
    {
    }
}