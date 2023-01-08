using Microsoft.AspNetCore.Mvc;


namespace G19.Controllers;

[ApiController]
[Route("[controller]")]
public class  ComputerController: ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private G19Context _G19Context;
    private IConfiguration _config;
    public ComputerController(ILogger<UserController> logger, G19Context g19Context, IConfiguration config)
    {
        _logger = logger;
        _G19Context = g19Context;
        _config = config;
    }

[HttpGet]
[Route("/Computers")]
public ActionResult ReadAll()
{
var all = _G19Context.Computers;
return Ok(all);
}

[HttpGet]
[Route("/Computer/{id}")]
public async Task<ActionResult> Read(long id)
{
var computer = await _G19Context.Computers.FindAsync(id);
return Ok(computer);
}

[HttpPost]
[Route("/Computer")]
public async Task<ActionResult> Create(Computer computer)
{
var _case = await _G19Context.Cases.FindAsync(computer.Case.CaseId);
var cooler = await _G19Context.Coolers.FindAsync(computer.Cooler.CoolerId);
var graphicsCard = await _G19Context.GraphicsCards.FindAsync(computer.GraphicsCard.GraphicsCardId);
var motherboard = await _G19Context.Motherboards.FindAsync(computer.Motherboard.MotherboardId);
var powerSuppy = await _G19Context.PowerSupplies.FindAsync(computer.PowerSupply.PowerSupplyId);
var processor = await _G19Context.Processors.FindAsync(computer.Processor.ProcessorId);
var ram = await _G19Context.Rams.FindAsync(computer.Ram.RamId);

if(_case == null || cooler == null || graphicsCard == null || motherboard == null || powerSuppy == null || processor == null || ram == null)
{
    return BadRequest();
}
var newComputer = new Computer();
newComputer.Case = _case;
newComputer.Cooler = cooler;
newComputer.GraphicsCard = graphicsCard;
newComputer.Motherboard = motherboard;
newComputer.PowerSupply = powerSuppy;
newComputer.Processor = processor;
newComputer.Ram = ram;
newComputer.Description = computer.Description;
newComputer.Name = computer.Name;

_G19Context.Computers.Add(newComputer);
_G19Context.SaveChanges();
return Ok(computer);
}

[HttpPut]
[Route("/Computer")]
public async Task<ActionResult> Update(Case _case)
{

{
    return BadRequest();
}

}

[HttpDelete]
[Route("/Computer/{id}")]
public async Task<ActionResult> Delete(long id)
{

{
    return BadRequest();
}

}
}