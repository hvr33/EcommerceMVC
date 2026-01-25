using Serenity.Services;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<Serene3.com.orderdetialsRow>;
using MyRow = Serene3.com.orderdetialsRow;

namespace Serene3.com;

public interface IorderdetialsListHandler : IListHandler<MyRow, MyRequest, MyResponse> { }

public class orderdetialsListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IorderdetialsListHandler
{
    public orderdetialsListHandler(IRequestContext context)
            : base(context)
    {
    }
}