using Serenity.Services;
using MyRequest = Serenity.Services.SaveRequest<Serene3.com.reviewRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = Serene3.com.reviewRow;

namespace Serene3.com;

public interface IreviewSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> { }

public class reviewSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IreviewSaveHandler
{
    public reviewSaveHandler(IRequestContext context)
            : base(context)
    {
    }
}