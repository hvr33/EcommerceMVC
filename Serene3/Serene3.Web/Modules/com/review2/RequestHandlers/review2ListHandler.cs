using Serenity.Services;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<Serene3.com.review2Row>;
using MyRow = Serene3.com.review2Row;

namespace Serene3.com;

public interface Ireview2ListHandler : IListHandler<MyRow, MyRequest, MyResponse> { }

public class review2ListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, Ireview2ListHandler
{
    public review2ListHandler(IRequestContext context)
            : base(context)
    {
    }
}