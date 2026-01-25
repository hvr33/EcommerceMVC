using Serenity.Services;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<Serene3.com.paymentsRow>;
using MyRow = Serene3.com.paymentsRow;

namespace Serene3.com;

public interface IpaymentsListHandler : IListHandler<MyRow, MyRequest, MyResponse> { }

public class paymentsListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IpaymentsListHandler
{
    public paymentsListHandler(IRequestContext context)
            : base(context)
    {
    }
}