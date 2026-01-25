using Serenity.Services;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<Serene3.com.paymentsRow>;
using MyRow = Serene3.com.paymentsRow;

namespace Serene3.com;

public interface IpaymentsRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> { }

public class paymentsRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IpaymentsRetrieveHandler
{
    public paymentsRetrieveHandler(IRequestContext context)
            : base(context)
    {
    }
}