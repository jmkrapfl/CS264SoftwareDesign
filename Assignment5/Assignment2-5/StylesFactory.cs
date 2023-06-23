public class StylesFactory
{

    public string customStyles()
    {
        Console.WriteLine("enter a Stroke Color: ");
        string strokeColor = Console.ReadLine();
        Console.WriteLine("enter a Stroke Width: ");
        string strokeWidth = Console.ReadLine();
        Console.WriteLine("enter a Fill Color: ");
        string fillColor = Console.ReadLine();

        string styles = "stroke=\""+ strokeColor +"\" stroke-width=\""+ strokeWidth +"\" fill=\""+ fillColor +"\"";
        return styles;
    }

    public string defaultStyles()
    {
        string styles = "stroke=\"black\" stroke-width=\"5\" fill=\"pink\"";
        return styles;
    }
}