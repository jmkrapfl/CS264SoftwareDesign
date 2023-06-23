public class polygon:shape
{
    public string points {get;}
    public string styles { get; }

    public polygon(string points,string styles)
    {
        this.points=points;
        this.styles=styles;
    }

    public override string printshape()
    {
        string data = "<polygon points=\""+this.points+"\" "+styles+"/>";
        return data;
    }
}