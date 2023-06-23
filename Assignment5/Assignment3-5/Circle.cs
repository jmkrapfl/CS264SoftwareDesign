public class circle:shape
{
    public int radius { get; }
    public int xCoord { get; }
    public int yCoord { get; }
    public string styles { get; }
    
    public circle(int radius,int xCoord,int yCoord,string styles)
    {
        this.xCoord=xCoord;
        this.yCoord=yCoord;
        this.radius=radius;
        this.styles=styles;
    }

    public override string printshape()
    {
        string data = "<circle cx=\""+this.xCoord+"\" cy=\""+this.yCoord+"\" r=\""+this.radius+"\""+styles+"/>";
        return data;
    }
}