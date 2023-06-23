public class LeftEye:Emoji
{
    public int xCoord { get; set;}
    public int yCoord { get; set;}
    public int rotate { get; set;}
    public char style { get; set;}
     //public LeftEye(int xCoord,int yCoord,int rotate, char style)
     public LeftEye(char style)
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
            case 'A': return "<!-- left-eye  -->\n<ellipse ry=\"5\" rx=\"5\" cy=\"47.91757\" cx=\"80.52101\" stroke-width=\"3\" stroke=\"black\" fill=\"#000000\"/>";
            
            case 'B': return "<!-- left-eye  -->\n<ellipse ry=\"5\" rx=\"5\" cy=\"54.31257\" cx=\"85.23482\" stroke-width=\"2\" stroke=\"#000\" fill=\"#000000\"/> \n" +
                "<rect transform=\"rotate(-22.1134 84.4208 49.4284)\" height=\"3.95384\" width=\"12.55927\" y=\"47.4515\" x=\"78.14116\" stroke-width=\"2\" stroke=\"#ffff00\" fill=\"#ffff00\"/>";
            
            case 'C': return "<!-- left-eye  -->\n<ellipse ry=\"5\" rx=\"5\" cy=\"55.09212\" cx=\"81.22369\" stroke-width=\"2\" stroke=\"#000\" fill=\"#000000\"/> \n"+
                "<path stroke=\"#00ffff\" fill=\"none\" stroke-linecap=\"round\" stroke-linejoin=\"round\" stroke-miterlimit=\"10\" stroke-width=\"2\" d=\"m75.29462,57.35762c0.54767,0.63491 2.97642,3.30649 6.50673,3.02023c2.86402,-0.23237 4.78485,-2.27624 5.42226,-3.02023\"/>";

            default: return null;
        }
        
    }
}