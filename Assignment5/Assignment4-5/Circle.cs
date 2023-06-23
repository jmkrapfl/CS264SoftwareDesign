public class circle:shape
{
    public int radius { get; }
    public int xCoord { get; }
    public int yCoord { get; }
    public string style {get;}
    
    public circle(int radius,int xCoord,int yCoord,string style)
    {
        this.xCoord=xCoord;
        this.yCoord=yCoord;
        this.radius=radius;
        this.style=style;
    }

    public override string printshape()
    {
        string data = "<circle cx=\""+this.xCoord+"\" cy=\""+this.yCoord+"\" r=\""+this.radius+"\""+style+"/>";
        return data;
    }
}