using Microsoft.AspNetCore.Mvc;
using JT_Server.Models;
using JT_Server.Services;

namespace JT_Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        [HttpPost]
        public IActionResult ReceiveData([FromBody] TaskData data)
        {
            if (data == null)
            {
                return BadRequest("Invalid data.");
            }

            try
            {
                var formFiller = new FormFillerService();
                formFiller.FillMicrosoftForm("https://forms.office.com/Pages/ResponsePage.aspx?id=WL3MEVufXE6vUQ4Xhymhu2X5xXGQ58dEmybbfveU6INUN0EzRE0xU1IwOUY5MjlLVUI2WFA2WENZMCQlQCN0PWcu", data);

                return Ok("Data sent to Microsoft Forms successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error while processing: {ex.Message}");
            }
        }

    }
}
