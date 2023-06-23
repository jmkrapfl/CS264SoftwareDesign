public class RightEye:Emoji
{
    public int xCoord { get; set;}
    public int yCoord { get; set;}
    public int rotate { get; set;}
    public char style { get; set;}
     //public RightEye(int xCoord,int yCoord,int rotate, char style)
     public RightEye(char style)
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
            case 'A': return "<!-- right-eye  -->\n<ellipse ry=\"5\" rx=\"5\" cy="+ 48 +" cx=\""+ 40 +"\" stroke-width=\"3\" stroke=\"black\" fill=\"#000000\"/>";
            
            case 'B': return "<!-- right-eye  -->\n<ellipse ry=\"5\" rx=\"5\" cy=\"54.08\" cx=\"39.41676\" stroke-width=\"2\" stroke=\"#000\" fill=\"#000000\"/> \n" +
                "<rect transform=\"rotate(31.0085 41.3937 49.4284)\" height=\"3.95384\" width=\"12.55927\" y=\"47.4515\" x=\"35.11405\" stroke-width=\"2\" stroke=\"#ffff00\" fill=\"#ffff00\"/>";
            
            case 'C': return "<!-- right-eye  -->\n<ellipse ry=\"5\" rx=\"5\" cy=\"55.09212\" cx=\"37.0736\" stroke-width=\"2\" stroke=\"#000\" fill=\"#000000\"/> \n"+
                "<path stroke=\"#00ffff\" fill=\"none\" stroke-linecap=\"round\" stroke-linejoin=\"round\" stroke-miterlimit=\"10\" stroke-width=\"2\" d=\"m31.14453,57.73497c0.54767,0.6349 2.97641,3.30649 6.50673,3.02022c2.86402,-0.23237 4.78485,-2.27624 5.42225,-3.0202\" id=\"svg_8\"/>";

            default: return null;
        }
        
    }
}