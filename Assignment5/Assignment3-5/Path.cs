public class path:shape
{
    public string p { get; }
    public string styles { get; }

    public path(string p,string styles)
    {
        this.p=p;
        this.styles=styles;
    }

   public override string printshape()
    {
        string data = "<path p=\""+this.p+"\" stroke=\"black\""+styles+"/>";
        return data;
    }
}