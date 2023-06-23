public class ellipse:shape
{
    public int rx { get; }//radis on the x axis
    public int ry { get; }//radis on the y axis
    public int xCoord { get; }
    public int yCoord { get; }
    public string style {get;}

    public ellipse(int xCoord,int yCoord, int rx, int ry,string style)
    {
        this.xCoord=xCoord;
        this.yCoord=yCoord;
        this.rx=rx;
        this.ry=ry;
        this.style=style;
    }

    public override string printshape()
    {
        string data = "<ellipse cx=\""+this.xCoord+"\" cy=\""+this.yCoord+"\" rx=\""+this.rx+"\" ry=\""+this.ry+"\""+style+"/>";
        return data;
    }
}