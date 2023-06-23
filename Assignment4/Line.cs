public class line:shape
{
    public int xStart { get; }
    public int yStart { get; }
    public int xEnd { get; }
    public int yEnd { get; }

    public line(int xStart,int yStart,int xEnd,int yEnd)
    {
        this.xStart=xStart;
        this.yStart=yStart;
        this.xEnd=xEnd;
        this.yEnd=yEnd;
    }

    public override string printshape()
    {
        string data = "<line x1=\""+xStart+"\" y1=\""+yStart+"\" x2=\""+xEnd+"\" y2=\""+yEnd+"\" stroke=\"black\"/>";
        return data;
    }
}