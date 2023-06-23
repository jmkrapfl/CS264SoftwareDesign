public class polyline:shape
{
    public string points { get; }
    public string style {get;}

    public polyline(string points,string style)
    {
        this.points=points;
        this.style=style;
    }
    public override string printshape()
    {
        string data = "<polyline points=\""+this.points+"\""+style+"/>";
        return data;
    }
}