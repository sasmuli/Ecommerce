using Microsoft.AspNetCore.Mvc;


namespace G19.Controllers;

[ApiController]
[Route("[controller]")]
public class  RamController: ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private G19Context _G19Context;
    private IConfiguration _config;
    public RamController(ILogger<UserController> logger, G19Context g19Context, IConfiguration config)
    {
        _logger = logger;
        _G19Context = g19Context;
        _config = config;
    }

[HttpGet]
[Route("/Rams")]
public ActionResult ReadAll()
{
var all = _G19Context.Rams;
return Ok(all);
}

[HttpGet]
[Route("/Ram/{id}")]
public async Task<ActionResult> Read(long id)
{
var Ram = await _G19Context.Rams.FindAsync(id);
return Ok(Ram);
}

[HttpPost]
[Route("/Ram")]
public async Task<ActionResult> Create(Ram ram)
{
var manufacturer = await _G19Context.Manufacturers.FindAsync(ram.Manufacturer.ManufacturerId);
if(manufacturer == null){
    return BadRequest();
}
ram.Manufacturer = manufacturer;
var result = await _G19Context.Rams.AddAsync(ram);
manufacturer.Rams.Add (result.Entity);
_G19Context.SaveChanges();
return Ok(ram.GetRamDTO());
}

[HttpPut]
[Route("/Ram")]
public async Task<ActionResult> Update(Ram ram)
{
var find = await _G19Context.Rams.FindAsync(ram.RamId);
if(find == null)
{
    return BadRequest();
}
find.Name = ram.Name;
find.Updated = DateTime.UtcNow;
find.Description = ram.Description;
find.Price = ram.Price;
_G19Context.SaveChanges();
return Ok(find);
}

[HttpDelete]
[Route("/Ram/{id}")]
public async Task<ActionResult> Delete(long id)
{
var find = await _G19Context.Rams.FindAsync(id);
if (find == null)
{
    return BadRequest();
}
var deletus = _G19Context.Rams.Remove(find);
_G19Context.SaveChanges();
return Ok(deletus.Entity);
}
}