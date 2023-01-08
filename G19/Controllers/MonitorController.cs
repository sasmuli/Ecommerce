using Microsoft.AspNetCore.Mvc;


namespace G19.Controllers;

[ApiController]
[Route("[controller]")]
public class  MonitorController: ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private G19Context _G19Context;
    private IConfiguration _config;
    public MonitorController(ILogger<UserController> logger, G19Context g19Context, IConfiguration config)
    {
        _logger = logger;
        _G19Context = g19Context;
        _config = config;
    }

[HttpGet]
[Route("/Monitors")]
public ActionResult ReadAll()
{
var all = _G19Context.Monitors;
return Ok(all);
}

[HttpGet]
[Route("/Monitor/{id}")]
public async Task<ActionResult> Read(long id)
{
var Monitor = await _G19Context.Monitors.FindAsync(id);
return Ok(Monitor);
}

[HttpPost]
[Route("/Monitor")]
public async Task<ActionResult> Create(Monitor monitor)
{
var manufacturer = await _G19Context.Manufacturers.FindAsync(monitor.Manufacturer.ManufacturerId);
if(manufacturer == null){
    return BadRequest();
}
monitor.Manufacturer = manufacturer;
var result = await _G19Context.Monitors.AddAsync(monitor);
manufacturer.Monitors.Add (result.Entity);
_G19Context.SaveChanges();
return Ok(monitor.GetMonitorDTO());
}

[HttpPut]
[Route("/Monitor")]
public async Task<ActionResult> Update(Monitor monitor)
{
var find = await _G19Context.Monitors.FindAsync(monitor.MonitorId);
if(find == null)
{
    return BadRequest();
}
find.Name = monitor.Name;
find.Updated = DateTime.UtcNow;
find.Description = monitor.Description;
find.Price = monitor.Price;
_G19Context.SaveChanges();
return Ok(find);
}

[HttpDelete]
[Route("/Monitor/{id}")]
public async Task<ActionResult> Delete(long id)
{
var find = await _G19Context.Monitors.FindAsync(id);
if (find == null)
{
    return BadRequest();
}
var deletus = _G19Context.Monitors.Remove(find);
_G19Context.SaveChanges();
return Ok(deletus.Entity);
}
}