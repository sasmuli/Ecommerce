using Microsoft.AspNetCore.Mvc;


namespace G19.Controllers;

[ApiController]
[Route("[controller]")]
public class  MotherboardController: ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private G19Context _G19Context;
    private IConfiguration _config;
    public MotherboardController(ILogger<UserController> logger, G19Context g19Context, IConfiguration config)
    {
        _logger = logger;
        _G19Context = g19Context;
        _config = config;
    }

[HttpGet]
[Route("/Motherboards")]
public ActionResult ReadAll()
{
var all = _G19Context.Motherboards;
return Ok(all);
}

[HttpGet]
[Route("/Motherboard/{id}")]
public async Task<ActionResult> Read(long id)
{
var Motherboard = await _G19Context.Motherboards.FindAsync(id);
return Ok(Motherboard);
}

[HttpPost]
[Route("/Motherboard")]
public async Task<ActionResult> Create(Motherboard motherboard)
{
var manufacturer = await _G19Context.Manufacturers.FindAsync(motherboard.Manufacturer.ManufacturerId);
if(manufacturer == null){
    return BadRequest();
}
motherboard.Manufacturer = manufacturer;
var result = await _G19Context.Motherboards.AddAsync(motherboard);
manufacturer.Motherboards.Add (result.Entity);
_G19Context.SaveChanges();
return Ok(motherboard.GetMotherboardDTO());
}

[HttpPut]
[Route("/Motherboard")]
public async Task<ActionResult> Update(Motherboard motherboard)
{
var find = await _G19Context.Motherboards.FindAsync(motherboard.MotherboardId);
if(find == null)
{
    return BadRequest();
}
find.Name = motherboard.Name;
find.Updated = DateTime.UtcNow;
find.Description = motherboard.Description;
find.Price = motherboard.Price;
_G19Context.SaveChanges();
return Ok(find);
}

[HttpDelete]
[Route("/Motherboard/{id}")]
public async Task<ActionResult> Delete(long id)
{
var find = await _G19Context.Motherboards.FindAsync(id);
if (find == null)
{
    return BadRequest();
}
var deletus = _G19Context.Motherboards.Remove(find);
_G19Context.SaveChanges();
return Ok(deletus.Entity);
}
}