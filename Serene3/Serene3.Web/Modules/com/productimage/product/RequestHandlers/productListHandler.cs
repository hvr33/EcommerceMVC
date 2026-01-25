using Serenity.Services;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<Serene3.com.productRow>;
using MyRow = Serene3.com.productRow;

namespace Serene3.com;

public interface IproductListHandler : IListHandler<MyRow, MyRequest, MyResponse> { }

public class productListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IproductListHandler
{
    public productListHandler(IRequestContext context)
            : base(context)
    {
    }
}