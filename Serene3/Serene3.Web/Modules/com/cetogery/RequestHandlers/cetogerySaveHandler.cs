using Serenity.Services;
using MyRequest = Serenity.Services.SaveRequest<Serene3.com.cetogeryRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = Serene3.com.cetogeryRow;

namespace Serene3.com;

public interface IcetogerySaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> { }

public class cetogerySaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IcetogerySaveHandler
{
    public cetogerySaveHandler(IRequestContext context)
            : base(context)
    {
    }
}