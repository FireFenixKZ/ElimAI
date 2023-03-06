using KDS.Primitives.FluentResult;
using MediatR;

namespace Catalog.Application.Features.GetProductByIdQuery
{
    public class GetProductByIdQuery : IRequest<Result>
    {
        public int Id { get; set; }

        public GetProductByIdQuery(int id)
        {
            Id = id;
        }
    }
}
