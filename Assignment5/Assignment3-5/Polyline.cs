public class polyline:shape
{
    public string points { get; }
    public string styles { get; }

    public polyline(string points,string styles)
    {
        this.points=points;
        this.styles=styles;
    }
    public override string printshape()
    {
        string data = "<polyline points=\""+this.points+"\" "+styles+"/>";
        return data;
    }
}