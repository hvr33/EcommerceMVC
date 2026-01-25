using Serenity.Services;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<Serene3.com.statesRow>;
using MyRow = Serene3.com.statesRow;

namespace Serene3.com;

public interface IstatesListHandler : IListHandler<MyRow, MyRequest, MyResponse> { }

public class statesListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IstatesListHandler
{
    public statesListHandler(IRequestContext context)
            : base(context)
    {
    }
}