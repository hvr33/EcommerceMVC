using Serenity.Services;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<Serene3.com.productimageRow>;
using MyRow = Serene3.com.productimageRow;

namespace Serene3.com;

public interface IproductimageListHandler : IListHandler<MyRow, MyRequest, MyResponse> { }

public class productimageListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IproductimageListHandler
{
    public productimageListHandler(IRequestContext context)
            : base(context)
    {
    }
}