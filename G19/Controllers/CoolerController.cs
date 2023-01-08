using Microsoft.AspNetCore.Mvc;


namespace G19.Controllers;

[ApiController]
[Route("[controller]")]
public class  CoolerController: ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private G19Context _G19Context;
    private IConfiguration _config;
    public CoolerController(ILogger<UserController> logger, G19Context g19Context, IConfiguration config)
    {
        _logger = logger;
        _G19Context = g19Context;
        _config = config;
    }

[HttpGet]
[Route("/Coolers")]
public ActionResult ReadAll()
{
var all = _G19Context.Coolers;
return Ok(all);
}

[HttpGet]
[Route("/Cooler/{id}")]
public async Task<ActionResult> Read(long id)
{
var Cooler = await _G19Context.Coolers.FindAsync(id);
return Ok(Cooler);
}

[HttpPost]
[Route("/Cooler")]
public async Task<ActionResult> Create(Cooler cooler)
{
var manufacturer = await _G19Context.Manufacturers.FindAsync(cooler.Manufacturer.ManufacturerId);
if(manufacturer == null)
{
    return BadRequest();
}
cooler.Manufacturer = manufacturer;
var result = await _G19Context.Coolers.AddAsync(cooler);
manufacturer.Coolers.Add (result.Entity);
_G19Context.SaveChanges();
return Ok(cooler.GetCoolerDTO());
}

[HttpPut]
[Route("/Cooler")]
public async Task<ActionResult> Update(Cooler cooler)
{
var find = await _G19Context.Coolers.FindAsync(cooler.CoolerId);
if(find == null)
{
    return BadRequest();
}
find.Name = cooler.Name;
find.Updated = DateTime.UtcNow;
find.Description = cooler.Description;
find.Price = cooler.Price;
_G19Context.SaveChanges();
return Ok(find);
}

[HttpDelete]
[Route("/Cooler/{id}")]
public async Task<ActionResult> Delete(long id)
{
var find = await _G19Context.Coolers.FindAsync(id);
if (find == null)
{
    return BadRequest();
}
var deletus = _G19Context.Coolers.Remove(find);
_G19Context.SaveChanges();
return Ok(deletus.Entity);
}
}