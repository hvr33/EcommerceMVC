using Serenity.Services;
using MyRequest = Serenity.Services.SaveRequest<Serene3.com.review2Row>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = Serene3.com.review2Row;

namespace Serene3.com;

public interface Ireview2SaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> { }

public class review2SaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, Ireview2SaveHandler
{
    public review2SaveHandler(IRequestContext context)
            : base(context)
    {
    }
}