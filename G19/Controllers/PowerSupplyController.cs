using Microsoft.AspNetCore.Mvc;


namespace G19.Controllers;

[ApiController]
[Route("[controller]")]
public class  PowerSupplyController: ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private G19Context _G19Context;
    private IConfiguration _config;
    public PowerSupplyController(ILogger<UserController> logger, G19Context g19Context, IConfiguration config)
    {
        _logger = logger;
        _G19Context = g19Context;
        _config = config;
    }

[HttpGet]
[Route("/PowerSupplys")]
public ActionResult ReadAll()
{
var all = _G19Context.PowerSupplies;
return Ok(all);
}

[HttpGet]
[Route("/PowerSupply/{id}")]
public async Task<ActionResult> Read(long id)
{
var PowerSupply = await _G19Context.PowerSupplies.FindAsync(id);
return Ok(PowerSupply);
}

[HttpPost]
[Route("/PowerSupply")]
public async Task<ActionResult> Create(PowerSupply powerSupply)
{
var manufacturer = await _G19Context.Manufacturers.FindAsync(powerSupply.Manufacturer.ManufacturerId);
if(manufacturer == null){
    return BadRequest();
}
powerSupply.Manufacturer = manufacturer;
var result = await _G19Context.PowerSupplies.AddAsync(powerSupply);
manufacturer.PowerSupplies.Add (result.Entity);
_G19Context.SaveChanges();
return Ok(powerSupply.GetPowerSupplyDTO());
}

[HttpPut]
[Route("/PowerSupply")]
public async Task<ActionResult> Update(PowerSupply powerSupply)
{
var find = await _G19Context.PowerSupplies.FindAsync(powerSupply.PowerSupplyId);
if(find == null)
{
    return BadRequest();
}
find.Name = powerSupply.Name;
find.Updated = DateTime.UtcNow;
find.Description = powerSupply.Description;
find.Price = powerSupply.Price;
_G19Context.SaveChanges();
return Ok(find);
}

[HttpDelete]
[Route("/PowerSupply/{id}")]
public async Task<ActionResult> Delete(long id)
{
var find = await _G19Context.PowerSupplies.FindAsync(id);
if (find == null)
{
    return BadRequest();
}
var deletus = _G19Context.PowerSupplies.Remove(find);
_G19Context.SaveChanges();
return Ok(deletus.Entity);
}
}