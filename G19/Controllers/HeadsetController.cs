using Microsoft.AspNetCore.Mvc;


namespace G19.Controllers;

[ApiController]
[Route("[controller]")]
public class  HeadsetController: ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private G19Context _G19Context;
    private IConfiguration _config;
    public HeadsetController(ILogger<UserController> logger, G19Context g19Context, IConfiguration config)
    {
        _logger = logger;
        _G19Context = g19Context;
        _config = config;
    }

[HttpGet]
[Route("/Headsets")]
public ActionResult ReadAll()
{
var all = _G19Context.Headsets;
return Ok(all);
}

[HttpGet]
[Route("/Headset/{id}")]
public async Task<ActionResult> Read(long id)
{
var headset = await _G19Context.Headsets.FindAsync(id);
return Ok(headset);
}

[HttpPost]
[Route("/Headset")]
public async Task<ActionResult> Create(Headset headset)
{
var manufacturer = await _G19Context.Manufacturers.FindAsync(headset.Manufacturer.ManufacturerId);
if(manufacturer == null){
    return BadRequest();
}
headset.Manufacturer = manufacturer;
var result = await _G19Context.Headsets.AddAsync(headset);
manufacturer.Headsets.Add (result.Entity);
_G19Context.SaveChanges();
return Ok(headset.GetHeadsetDTO());
}

[HttpPut]
[Route("/Headset")]
public async Task<ActionResult> Update(Headset headset)
{
var find = await _G19Context.Headsets.FindAsync(headset.HeadsetId);
if(find == null)
{
    return BadRequest();
}
find.Name = headset.Name;
find.Updated = DateTime.UtcNow;
find.Description = headset.Description;
find.Price = headset.Price;
_G19Context.SaveChanges();
return Ok(find);
}

[HttpDelete]
[Route("/Headset/{id}")]
public async Task<ActionResult> Delete(long id)
{
var find = await _G19Context.Headsets.FindAsync(id);
if (find == null)
{
    return BadRequest();
}
var deletus = _G19Context.Headsets.Remove(find);
_G19Context.SaveChanges();
return Ok(deletus.Entity);
}
}