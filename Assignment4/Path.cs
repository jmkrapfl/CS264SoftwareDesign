public class path:shape
{
    public string p { get; }

    public path(string p)
    {
        this.p=p;
    }

   public override string printshape()
    {
        string data = "<path p=\""+this.p+"\" stroke=\"black\"/>";
        return data;
    }
}