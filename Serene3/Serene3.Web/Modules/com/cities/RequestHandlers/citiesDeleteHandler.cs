using Serenity.Services;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = Serene3.com.citiesRow;

namespace Serene3.com;

public interface IcitiesDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> { }

public class citiesDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IcitiesDeleteHandler
{
    public citiesDeleteHandler(IRequestContext context)
            : base(context)
    {
    }
}