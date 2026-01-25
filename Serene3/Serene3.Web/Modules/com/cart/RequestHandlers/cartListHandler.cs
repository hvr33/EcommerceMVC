using Serenity.Services;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<Serene3.com.cartRow>;
using MyRow = Serene3.com.cartRow;

namespace Serene3.com;

public interface IcartListHandler : IListHandler<MyRow, MyRequest, MyResponse> { }

public class cartListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IcartListHandler
{
    public cartListHandler(IRequestContext context)
            : base(context)
    {
    }
}