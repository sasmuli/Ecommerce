using Microsoft.AspNetCore.Mvc;


namespace G19.Controllers;

[ApiController]
[Route("[controller]")]
public class  ProcessorController: ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private G19Context _G19Context;
    private IConfiguration _config;
    public ProcessorController(ILogger<UserController> logger, G19Context g19Context, IConfiguration config)
    {
        _logger = logger;
        _G19Context = g19Context;
        _config = config;
    }

[HttpGet]
[Route("/Processors")]
public ActionResult ReadAll()
{
var all = _G19Context.Processors;
return Ok(all);
}

[HttpGet]
[Route("/Processor/{id}")]
public async Task<ActionResult> Read(long id)
{
var Processor = await _G19Context.Processors.FindAsync(id);
return Ok(Processor);
}

[HttpPost]
[Route("/Processor")]
public async Task<ActionResult> Create(Processor processor)
{
var manufacturer = await _G19Context.Manufacturers.FindAsync(processor.Manufacturer.ManufacturerId);
if(manufacturer == null){
    return BadRequest();
}
processor.Manufacturer = manufacturer;
var result = await _G19Context.Processors.AddAsync(processor);
manufacturer.Processors.Add (result.Entity);
_G19Context.SaveChanges();
return Ok(processor.GetProcessorDTO());
}

[HttpPut]
[Route("/Processor")]
public async Task<ActionResult> Update(Processor processor)
{
var find = await _G19Context.Processors.FindAsync(processor.ProcessorId);
if(find == null)
{
    return BadRequest();
}
find.Name = processor.Name;
find.Updated = DateTime.UtcNow;
find.Description = processor.Description;
find.Price = processor.Price;
_G19Context.SaveChanges();
return Ok(find);
}

[HttpDelete]
[Route("/Processor/{id}")]
public async Task<ActionResult> Delete(long id)
{
var find = await _G19Context.Processors.FindAsync(id);
if (find == null)
{
    return BadRequest();
}
var deletus = _G19Context.Processors.Remove(find);
_G19Context.SaveChanges();
return Ok(deletus.Entity);
}
}