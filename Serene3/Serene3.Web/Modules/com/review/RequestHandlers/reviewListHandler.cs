using Serenity.Services;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<Serene3.com.reviewRow>;
using MyRow = Serene3.com.reviewRow;

namespace Serene3.com;

public interface IreviewListHandler : IListHandler<MyRow, MyRequest, MyResponse> { }

public class reviewListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IreviewListHandler
{
    public reviewListHandler(IRequestContext context)
            : base(context)
    {
    }
}