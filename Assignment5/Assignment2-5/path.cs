//###### PATH #######
public class path:shape
{
    public string p { get; }
    public int id { get; }
    public string style { get; }
    

    public path(int id,string p,string style)
    {
        this.p=p;
        this.id=id;
        this.style=style;
    }

   public override string printshape()
    {
        string data = "<path p=\""+this.p+"\" "+style+"/>";
        return data;
    }
}