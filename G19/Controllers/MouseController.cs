using Microsoft.AspNetCore.Mvc;


namespace G19.Controllers;

[ApiController]
[Route("[controller]")]
public class  MouseController: ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private G19Context _G19Context;
    private IConfiguration _config;
    public MouseController(ILogger<UserController> logger, G19Context g19Context, IConfiguration config)
    {
        _logger = logger;
        _G19Context = g19Context;
        _config = config;
    }

[HttpGet]
[Route("/Mouses")]
public ActionResult ReadAll()
{
var all = _G19Context.Mouses;
return Ok(all);
}

[HttpGet]
[Route("/Mouse/{id}")]
public async Task<ActionResult> Read(long id)
{
var Mouse = await _G19Context.Mouses.FindAsync(id);
return Ok(Mouse);
}

[HttpPost]
[Route("/Mouse")]
public async Task<ActionResult> Create(Mouse mouse)
{
var manufacturer = await _G19Context.Manufacturers.FindAsync(mouse.Manufacturer.ManufacturerId);
if(manufacturer == null){
    return BadRequest();
}
mouse.Manufacturer = manufacturer;
var result = await _G19Context.Mouses.AddAsync(mouse);
manufacturer.Mouses.Add (result.Entity);
_G19Context.SaveChanges();
return Ok(mouse.GetMouseDTO());
}

[HttpPut]
[Route("/Mouse")]
public async Task<ActionResult> Update(Mouse mouse)
{
var find = await _G19Context.Mouses.FindAsync(mouse.MouseId);
if(find == null)
{
    return BadRequest();
}
find.Name = mouse.Name;
find.Updated = DateTime.UtcNow;
find.Description = mouse.Description;
find.Price = mouse.Price;
_G19Context.SaveChanges();
return Ok(find);
}

[HttpDelete]
[Route("/Mouse/{id}")]
public async Task<ActionResult> Delete(long id)
{
var find = await _G19Context.Mouses.FindAsync(id);
if (find == null)
{
    return BadRequest();
}
var deletus = _G19Context.Mouses.Remove(find);
_G19Context.SaveChanges();
return Ok(deletus.Entity);
}
}