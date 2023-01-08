public class Keyboard 
{
    public long KeyboardId{get;set;}
    public string Name{get;set;}
    public string Description{get;set;}
    public long Price{get;set;}
    public DateTime Created{get;set;}
    public DateTime Updated{get;set;}
    public Manufacturer Manufacturer {get;set;}
     public KeyboardDTO GetKeyboardDTO()
    {
        return new KeyboardDTO(this);
    }
}