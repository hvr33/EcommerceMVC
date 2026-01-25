using Serenity.Services;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = Serene3.com.paymentsRow;

namespace Serene3.com;

public interface IpaymentsDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> { }

public class paymentsDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IpaymentsDeleteHandler
{
    public paymentsDeleteHandler(IRequestContext context)
            : base(context)
    {
    }
}