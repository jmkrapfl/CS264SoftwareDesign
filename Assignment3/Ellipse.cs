public class ellipse:shape
{
    public int rx { get; }//radis on the x axis
    public int ry { get; }//radis on the y axis
    public int xCoord { get; }
    public int yCoord { get; }

    public ellipse(int xCoord,int yCoord, int rx, int ry)
    {
        this.xCoord=xCoord;
        this.yCoord=yCoord;
        this.rx=rx;
        this.ry=ry;
    }

    public override string printshape()
    {
        string data = "<ellipse cx=\""+this.xCoord+"\" cy=\""+this.yCoord+"\" rx=\""+this.rx+"\" ry=\""+this.ry+"\"/>";
        return data;
    }
}