public class polygon:shape
{
    public string points {get;}
    public string style {get;}

    public polygon(string points,string style)
    {
        this.points=points;
        this.style=style;
    }

    public override string printshape()
    {
        string data = "<polygon points=\""+this.points+"\""+style+"/>";
        return data;
    }
}