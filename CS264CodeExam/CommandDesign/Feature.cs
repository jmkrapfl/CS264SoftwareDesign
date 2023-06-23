public abstract class Feature
{
    public abstract string name {get;} 
    public abstract char style {get; set;} 
    public abstract int xCoord {get; set;} 
    public abstract int yCoord {get; set;} 
    public abstract int rotate {get; set;} 
    public abstract string printElement();
}