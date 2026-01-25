using Serenity.Services;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = Serene3.com.countriesRow;

namespace Serene3.com;

public interface IcountriesDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> { }

public class countriesDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IcountriesDeleteHandler
{
    public countriesDeleteHandler(IRequestContext context)
            : base(context)
    {
    }
}