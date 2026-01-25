using Serenity.Services;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<Serene3.com.orderRow>;
using MyRow = Serene3.com.orderRow;

namespace Serene3.com;

public interface IorderListHandler : IListHandler<MyRow, MyRequest, MyResponse> { }

public class orderListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IorderListHandler
{
    public orderListHandler(IRequestContext context)
            : base(context)
    {
    }
}