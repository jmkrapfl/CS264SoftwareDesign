public class circle:shape
{
    public int radius { get; }
    public int xCoord { get; }
    public int yCoord { get; }
    
    public circle(int radius,int xCoord,int yCoord)
    {
        this.xCoord=xCoord;
        this.yCoord=yCoord;
        this.radius=radius;
    }

    public override string printshape()
    {
        string data = "<circle cx=\""+this.xCoord+"\" cy=\""+this.yCoord+"\" r=\""+this.radius+"\"/>";
        return data;
    }
}