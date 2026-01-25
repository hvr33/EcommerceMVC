using Serenity.Services;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<Serene3.com.orderRow>;
using MyRow = Serene3.com.orderRow;

namespace Serene3.com;

public interface IorderRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> { }

public class orderRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IorderRetrieveHandler
{
    public orderRetrieveHandler(IRequestContext context)
            : base(context)
    {
    }
}