using Serenity.Services;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<Serene3.com.cetogeryRow>;
using MyRow = Serene3.com.cetogeryRow;

namespace Serene3.com;

public interface IcetogeryListHandler : IListHandler<MyRow, MyRequest, MyResponse> { }

public class cetogeryListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IcetogeryListHandler
{
    public cetogeryListHandler(IRequestContext context)
            : base(context)
    {
    }
}