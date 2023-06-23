public class path:shape
{
    public string p { get; }
    public string style {get;}

    public path(string p,string style)
    {
        this.p=p;
        this.style=style;
    }

   public override string printshape()
    {
        string data = "<path p=\""+this.p+"\" stroke=\"black\""+style+"/>";
        return data;
    }
}