public class polygon:shape
{
    public string points {get;}

    public polygon(string points)
    {
        this.points=points;
    }

    public override string printshape()
    {
        string data = "<polygon points=\""+this.points+"\" style=\"fill:black;stroke:black;stroke-width:1\"/>";
        return data;
    }
}