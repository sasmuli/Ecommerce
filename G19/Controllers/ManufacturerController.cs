using Microsoft.AspNetCore.Mvc;


namespace G19.Controllers;

[ApiController]
[Route("[controller]")]
public class  ManufacturerController: ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private G19Context _G19Context;
    private IConfiguration _config;
    public ManufacturerController(ILogger<UserController> logger, G19Context g19Context, IConfiguration config)
    {
        _logger = logger;
        _G19Context = g19Context;
        _config = config;
    }

[HttpGet]
[Route("/Manufacturers")]
public ActionResult ReadAll()
{
var all = _G19Context.Manufacturers;
return Ok(all);
}

[HttpGet]
[Route("/Manufacturer/{id}")]
public async Task<ActionResult> Read(long id)
{
var manufacturer = await _G19Context.Manufacturers.FindAsync(id);
return Ok(manufacturer);
}

[HttpPost]
[Route("/Manufacturer")]
public async Task<ActionResult> Create(Manufacturer manufacturer)
{
var result = await _G19Context.Manufacturers.AddAsync(manufacturer);
_G19Context.SaveChanges();
return Ok(result.Entity);
}

[HttpPut]
[Route("/Manufacturer")]
public async Task<ActionResult> Update(Manufacturer manufacturer)
{
var find = await _G19Context.Manufacturers.FindAsync(manufacturer.ManufacturerId);
find.Name = manufacturer.Name;
_G19Context.SaveChanges();
return Ok(manufacturer);
}

[HttpDelete]
[Route("/Manufacturer/{id}")]
public async Task<ActionResult> Delete(long id)
{
var find = await _G19Context.Manufacturers.FindAsync(id);
if (find == null){
    return BadRequest();
}
var deletus = _G19Context.Manufacturers.Remove(find);
_G19Context.SaveChanges();
return Ok(deletus.Entity);
}
}