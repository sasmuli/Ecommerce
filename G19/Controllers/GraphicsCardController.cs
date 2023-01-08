using Microsoft.AspNetCore.Mvc;


namespace G19.Controllers;

[ApiController]
[Route("[controller]")]
public class  GraphicsCardController: ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private G19Context _G19Context;
    private IConfiguration _config;
    public GraphicsCardController(ILogger<UserController> logger, G19Context g19Context, IConfiguration config)
    {
        _logger = logger;
        _G19Context = g19Context;
        _config = config;
    }

[HttpGet]
[Route("/GraphicsCards")]
public ActionResult ReadAll()
{
var all = _G19Context.GraphicsCards;
return Ok(all);
}

[HttpGet]
[Route("/GraphicsCard/{id}")]
public async Task<ActionResult> Read(long id)
{
var GraphicsCard = await _G19Context.GraphicsCards.FindAsync(id);
return Ok(GraphicsCard);
}

[HttpPost]
[Route("/GraphicsCard")]
public async Task<ActionResult> Create(GraphicsCard graphicsCard)
{
var manufacturer = await _G19Context.Manufacturers.FindAsync(graphicsCard.Manufacturer.ManufacturerId);
if(manufacturer == null){
    return BadRequest();
}
graphicsCard.Manufacturer = manufacturer;
var result = await _G19Context.GraphicsCards.AddAsync(graphicsCard);
manufacturer.GraphicsCards.Add (result.Entity);
_G19Context.SaveChanges();
return Ok(graphicsCard.GetGraphicsCardDTO());
}

[HttpPut]
[Route("/GraphicsCard")]
public async Task<ActionResult> Update(GraphicsCard graphicsCard)
{
var find = await _G19Context.GraphicsCards.FindAsync(graphicsCard.GraphicsCardId);
if(find == null)
{
    return BadRequest();
}
find.Name = graphicsCard.Name;
find.Updated = DateTime.UtcNow;
find.Description = graphicsCard.Description;
find.Price = graphicsCard.Price;
_G19Context.SaveChanges();
return Ok(find);
}

[HttpDelete]
[Route("/GraphicsCard/{id}")]
public async Task<ActionResult> Delete(long id)
{
var find = await _G19Context.GraphicsCards.FindAsync(id);
if (find == null)
{
    return BadRequest();
}
var deletus = _G19Context.GraphicsCards.Remove(find);
_G19Context.SaveChanges();
return Ok(deletus.Entity);
}
}