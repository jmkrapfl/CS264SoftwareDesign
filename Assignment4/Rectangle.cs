public class rectangle:shape
{
    public int width { get; }
    public int height { get; }
    public int xCoord { get; }
    public int yCoord { get; }
    public rectangle(int width,int height,int xCoord,int yCoord)
    {
        this.xCoord=xCoord;
        this.yCoord=yCoord;
        this.width=width;
        this.height=height;
    }
    public override string printshape()
    {
        string data = "<rect width=\""+this.width+"\" height=\""+this.height+"\" x=\""+this.xCoord+"\""+" y=\""+this.yCoord+"\"/>";
        return data;
    }
}