public class Emoji
{
    
    private List<Feature> emoji = new List<Feature>();
    private List<Feature> clearedFromEmoji = new List<Feature>();

    //add
    public void Add(Feature s)
    {
        emoji.Add(s);
        Console.WriteLine("Added Shape to canvas: {0}" + Environment.NewLine, s);
    }
    //delete
    public Feature Remove()
    {

        int length = emoji.Count-1;
        Console.WriteLine(length);
        Feature s = emoji[length];
        emoji.Remove(s);
        Console.WriteLine("Removed Shape from canvas: {0}" + Environment.NewLine, s);
        return s;
    }
    
    public Emoji()
    {
        Console.WriteLine("\nCreated a new Canvas!"); Console.WriteLine();
    }

//\\\\\\\\\\\\\\\\ remove feature\\\\\\\\\\\\\\\\\\
    public Feature removeFeature(Feature removeThis)
    {
        Feature f = null;
        /*
        for(int i=0; i<emoji.Count; i++)
        {
            if(emoji[i].name == removeThis.name)
            {
                f = emoji[i];
                emoji.RemoveAt(i);
            }
        }
        */
        emoji.Remove(removeThis);
        return removeThis;
    }
    //################ Style ######
    public void style(Feature feat, char type)
    {
        foreach(Feature obj in emoji)
        {
            if(feat.name == obj.name)
            {
                obj.style = type;
            }
        }
    }

//########### write to file ##############
    public void WriteToFile()
    {
        int length = emoji.Count();
        string path = @"./shapes.svg";
        if (!File.Exists(path))
        {
            // Create a file to write to if there isnt one.
            using (StreamWriter sw = File.CreateText(path))
            {
                //writes the svg into the file
                sw.WriteLine("<html>");
                sw.WriteLine("\t<body>");
                sw.WriteLine("\t\t<svg width=\"120\" height=\"120\"xmlns=\"http://www.w3.org/2000/svg>");
                sw.WriteLine("\t\t\t<g>");
                sw.WriteLine("\t\t\t\t<!-- body  -->");
                sw.WriteLine("\t\t\t\t<circle cx=\"60\" cy=\"60\" r=\"55\" stroke=\"black\" stroke-width=\"3\" fill=\"yellow\"/>");
                for(int i=0;i<length;i++)
                {   
                    //goes through the stack and writes each shapes printShape() string into the file
                    string temp = emoji.ElementAt(i).printElement();
                    sw.WriteLine("\t\t\t\t"+temp);
                }
                sw.WriteLine("\t\t\t<g>");
                sw.WriteLine("\t\t</svg>");
                sw.WriteLine("\t</body>");
                sw.WriteLine("</html>");
            }
        }
        else
        {
            using (StreamWriter sw = File.CreateText(path))
            {
                //writes the svg into the file
                sw.WriteLine("<html>");
                sw.WriteLine("\t<body>");
                sw.WriteLine("\t\t<svg width=\"120\" height=\"120\"xmlns=\"http://www.w3.org/2000/svg>");
                sw.WriteLine("\t\t\t<g>");
                sw.WriteLine("\t\t\t\t<!-- body  -->");
                sw.WriteLine("\t\t\t\t<circle cx=\"60\" cy=\"60\" r=\"55\" stroke=\"black\" stroke-width=\"3\" fill=\"yellow\"/>");
                for(int i=0;i<length;i++)
                {   
                    //goes through the stack and writes each shapes printShape() string into the file
                    string temp = emoji.ElementAt(i).printElement();
                    sw.WriteLine("\t\t\t\t"+temp);
                }
                sw.WriteLine("\t\t\t<g>");
                sw.WriteLine("\t\t</svg>");
                sw.WriteLine("\t</body>");
                sw.WriteLine("</html>");
            }
        }
    }


    //######### print to screen ##############
    public void printEmoji()
    {
        int length = emoji.Count();
        Console.WriteLine("<html>");
        Console.WriteLine("\t<body>");
        Console.WriteLine("\t\t<svg width=\"120\" height=\"120\"xmlns=\"http://www.w3.org/2000/svg>");
        Console.WriteLine("\t\t\t<g>");
        Console.WriteLine("\t\t\t\t<!-- body  -->");
        Console.WriteLine("\t\t\t\t<circle cx=\"60\" cy=\"60\" r=\"55\" stroke=\"black\" stroke-width=\"3\" fill=\"yellow\"/>");
        for(int i=0;i<length;i++)
        {   
            //goes through the stack and writes each shapes printShape() string into the file
            string temp = emoji.ElementAt(i).printElement();
            Console.WriteLine("\t\t\t\t"+temp);
        }
        Console.WriteLine("\t\t\t<g>");
        Console.WriteLine("\t\t</svg>");
        Console.WriteLine("\t</body>");
        Console.WriteLine("</html>");
    }
}