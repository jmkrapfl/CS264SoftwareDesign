//###### POLYGON #######
public class polygon:shape
{
    public string points {get;}
    public int id {get;}
    public string style { get; }
    

    public polygon(int id,string points,string style)
    {
        this.points=points;
        this.id=id;
        this.style=style;
    }

    public override string printshape()
    {
        string data = "<polygon points=\""+this.points+"\" "+style+"/>";
        return data;
    }
}
