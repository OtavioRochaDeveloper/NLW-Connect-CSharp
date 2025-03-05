using Microsoft.AspNetCore.Mvc;
using TechLibrary.Api.UseCases.Books.Filter;
using TechLibrary.Communication.Responses;
using TechLibrary.Communication.Requests;

namespace TechLibrary.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [HttpGet("Filter")]
        [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]

        public IActionResult Filter(int pageNumber, string? title)
        {
            var useCase = new FilterBookUseCase();

            var request = new RequestFilterBooksJson
            {
                PageNumber = pageNumber,
                Title = title
            };

            var result = useCase.Execute(request);

            return Ok(result);
        }
    }
}