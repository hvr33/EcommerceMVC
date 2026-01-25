using Serenity.Services;
using MyRequest = Serenity.Services.SaveRequest<Serene3.com.cartRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = Serene3.com.cartRow;

namespace Serene3.com;

public interface IcartSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> { }

public class cartSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IcartSaveHandler
{
    public cartSaveHandler(IRequestContext context)
            : base(context)
    {
    }
}