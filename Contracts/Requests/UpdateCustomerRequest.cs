using Microsoft.AspNetCore.Mvc;

namespace MoviesApi.Contracts.Requests
{
    public class UpdateCustomerRequest
    {
        [FromRoute(Name = "id")] public Guid Id { get; init; }

        [FromBody] public MovieRequest Movie { get; set; } = default!;
    }
}
