using canil.Services;
using Microsoft.AspNetCore.Mvc;

namespace canil.Controllers;

[ApiController]
[Route("/api/best-option")]
public class PetShopController : ControllerBase
{
    private static PetShopService _petShopService;

    public PetShopController()
    {
        _petShopService = new PetShopService();
    }

    [HttpGet()]
    public IActionResult Get(string date, int smallDogs, int largeDogs)
    {
        try
        {
            return Ok(_petShopService.getBestOption(smallDogs, largeDogs, date)); 
        }
        catch (System.Exception error)
        {
            return BadRequest(error.Message);
        }
    }
}
