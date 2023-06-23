public class LeftBrow:Feature
{
    public override string name { get;}
    public override int xCoord { get; set;}
    public override int yCoord { get; set;}
    public override char style { get; set;}
    public override int rotate { get; set;}
    
     //public LeftBrow(int xCoord,int yCoord,int rotate, char style)
     public LeftBrow()
    {
        //this.xCoord=xCoord;
        //this.yCoord=yCoord;
        //this.rotate=rotate;
        //this.style = style;
        name = "left-brow";
        style = 'A';
    }
    public LeftBrow(Feature f)
    {
        name = f.name;
        style=f.style;
    }

    public override string printElement()
    {
        
        switch(style)
        {
            case 'A': return "<!-- left-brow  -->\n<path stroke=\"#000\" d=\"m55.23596,36.36197a16.01081,8.93515 0 0 0 -29.26337,0\" stroke-width=\"2\" stroke-miterlimit=\"10\" stroke-linecap=\"round\" fill=\"none\" xmlns=\"http://www.w3.org/2000/svg\"/>";
            
            case 'B': return "<!-- left-brow  -->\n<path fill=\"none\" stroke=\"#000\" opacity=\"undefined\" d=\"m27.86616,32.54546l22.10808,12.85354\" stroke-width=\"5\"/>";
            
            case 'C': return "<!-- left-brow  -->\n<path fill=\"none\" stroke-linecap=\"round\" stroke-linejoin=\"round\" stroke-miterlimit=\"10\" stroke-width=\"2\" d=\"m22.65413,35.65993c1.37925,1.26505 7.49577,6.58819 16.38649,6.01781c7.21271,-0.46299 12.05012,-4.53542 13.65535,-6.01781\" stroke=\"#000000\"/>";

            default: return null;
        }
        
    }
}