using Microsoft.AspNetCore.Mvc;


namespace G19.Controllers;

[ApiController]
[Route("[controller]")]
public class  KeyboardController: ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private G19Context _G19Context;
    private IConfiguration _config;
    public KeyboardController(ILogger<UserController> logger, G19Context g19Context, IConfiguration config)
    {
        _logger = logger;
        _G19Context = g19Context;
        _config = config;
    }

[HttpGet]
[Route("/Keyboards")]
public ActionResult ReadAll()
{
var all = _G19Context.Keyboards;
return Ok(all);
}

[HttpGet]
[Route("/Keyboard/{id}")]
public async Task<ActionResult> Read(long id)
{
var Keyboard = await _G19Context.Keyboards.FindAsync(id);
return Ok(Keyboard);
}

[HttpPost]
[Route("/Keyboard")]
public async Task<ActionResult> Create(Keyboard keyboard)
{
var manufacturer = await _G19Context.Manufacturers.FindAsync(keyboard.Manufacturer.ManufacturerId);
if(manufacturer == null){
    return BadRequest();
}
keyboard.Manufacturer = manufacturer;
var result = await _G19Context.Keyboards.AddAsync(keyboard);
manufacturer.Keyboards.Add (result.Entity);
_G19Context.SaveChanges();
return Ok(keyboard.GetKeyboardDTO());
}

[HttpPut]
[Route("/Keyboard")]
public async Task<ActionResult> Update(Keyboard keyboard)
{
var find = await _G19Context.Keyboards.FindAsync(keyboard.KeyboardId);
if(find == null)
{
    return BadRequest();
}
find.Name = keyboard.Name;
find.Updated = DateTime.UtcNow;
find.Description = keyboard.Description;
find.Price = keyboard.Price;
_G19Context.SaveChanges();
return Ok(find);
}

[HttpDelete]
[Route("/Keyboard/{id}")]
public async Task<ActionResult> Delete(long id)
{
var find = await _G19Context.Keyboards.FindAsync(id);
if (find == null)
{
    return BadRequest();
}
var deletus = _G19Context.Keyboards.Remove(find);
_G19Context.SaveChanges();
return Ok(deletus.Entity);
}
}