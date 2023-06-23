public class Mouth:Emoji
{
    public int xCoord { get; set;}
    public int yCoord { get; set;}
    public int rotate { get; set;}
    public char style { get; set;}
     //public Mouth(int xCoord,int yCoord,int rotate, char style)
     public Mouth(char style)
    {
        //this.xCoord=xCoord;
        //this.yCoord=yCoord;
        //this.rotate=rotate;
        this.style = style;
    }

    public override string printElement(char style)
    {
        switch(style)
        {
            case 'A': return "<!-- mouth  -->\n<path transform=\"rotate(-179.992 60.6044 81.0004)\" stroke=\"#000\" d=\"m75.23613,83.65403a16.01081,8.93515 0 0 0 -29.26337,0\" stroke-width=\"2\" stroke-miterlimit=\"10\" stroke-linecap=\"round\" fill=\"none\" xmlns=\"http://www.w3.org/2000/svg\"/>";
            
            case 'B': return "<!-- mouth  -->\n<line id=\"svg_10\" y2=\"77.45418\" x2=\"47.20816\" y1=\"86.52477\" x1=\"25.81089\" stroke-width=\"5\" stroke=\"#000000\" fill=\"none\"/> \n" +
                             "<line y2=\"90.94377\" x2=\"60\" y1=\"77.22161\" x1=\"44.64979\" stroke-width=\"5\" stroke=\"#000000\" fill=\"none\"/> \n" +
                             "<line y2=\"81.17545\" x2=\"78.8389\" y1=\"90.24603\" x1=\"57.44163\" stroke-width=\"5\" stroke=\"#000000\" fill=\"none\"/> \n" +
                             "<line y2=\"94.43245\" x2=\"91.39816\" y1=\"80.71029\" x1=\"76.04795\" stroke-width=\"5\" stroke=\"#000000\" fill=\"none\"/>";
            
            case 'C': return "<!-- mouth  -->\n<path transform=\"rotate(-179.61 60.0331 85.01)\" stroke=\"#000000\" fill=\"none\" stroke-linecap=\"round\" stroke-linejoin=\"round\" stroke-miterlimit=\"10\" stroke-width=\"2\" d=\"m42.44394,78.88403c1.61507,2.55746 8.77738,13.31889 19.18821,12.16579c8.44592,-0.93599 14.11042,-9.16894 15.99011,-12.16579\"/>";

            default: return null;
        }
        
    }
}