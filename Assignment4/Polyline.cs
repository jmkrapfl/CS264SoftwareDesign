public class polyline:shape
{
    public string points { get; }

    public polyline(string points)
    {
        this.points=points;
    }
    public override string printshape()
    {
        string data = "<polyline points=\""+this.points+"\" style=\"fill:none;stroke:black;stroke-width:3\"/>";
        return data;
    }
}