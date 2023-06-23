//###### RECTANGLE #######
public class rectangle:shape
{
    public int width { get; }
    public int height { get; }
    public int xCoord { get; }
    public int yCoord { get; }
    public int id { get; }
    public string style { get; }
    
    public rectangle(int id,int width,int height,int xCoord,int yCoord,string style)
    {
        this.xCoord=xCoord;
        this.yCoord=yCoord;
        this.width=width;
        this.height=height;
        this.id=id;
        this.style=style;
    }
    public override string printshape()
    {
        string data = "<rect width=\""+this.width+"\" height=\""+this.height+"\" x=\""+this.xCoord+"\""+" y=\""+this.yCoord+"\""+style+"/>";
        return data;
    }
}