public class rectangle:shape
{
    public int width { get; }
    public int height { get; }
    public int xCoord { get; }
    public int yCoord { get; }
    public string styles { get; }
    public rectangle(int width,int height,int xCoord,int yCoord,string styles)
    {
        this.xCoord=xCoord;
        this.yCoord=yCoord;
        this.width=width;
        this.height=height;
        this.styles=styles;
    }
    public override string printshape()
    {
        string data = "<rect width=\""+this.width+"\" height=\""+this.height+"\" x=\""+this.xCoord+"\""+" y=\""+this.yCoord+"\""+styles+"/>";
        return data;
    }
}