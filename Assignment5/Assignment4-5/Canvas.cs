public class Canvas
{
    private Stack<shape> canvas = new Stack<shape>();
    private Stack<shape> clearedFromCanvas = new Stack<shape>();

    public void Add(shape s)
    {
        canvas.Push(s);
        Console.WriteLine("Added Shape to canvas: {0}" + Environment.NewLine, s);
    }
    public shape Remove()
    {
        int length = canvas.Count;
        shape s = canvas.Pop();
        Console.WriteLine("Removed Shape from canvas: {0}" + Environment.NewLine, s);
        return s;
    }

    //clear canvas funtionality
    public void clearCanvas()
    {
        clearedFromCanvas = new Stack<shape>(canvas);
        //clearedFromCanvas = canvas;
        canvas.Clear();//clear original
        
    }
    
    public void backToCanvas()
    {
        canvas = new Stack<shape>(clearedFromCanvas);
        //canvas=clearedFromCanvas;
        //clear storage
        clearedFromCanvas.Clear();
    }

    public Canvas()
    {
        Console.WriteLine("\nCreated a new Canvas!"); Console.WriteLine();
    }

//########### write to file ##############
    public void WriteToFile()
    {
        int length = canvas.Count();
        string path = @"./shapes.svg";
        if (!File.Exists(path))
        {
            // Create a file to write to if there isnt one.
            using (StreamWriter sw = File.CreateText(path))
            {
                //writes the svg into the file
                sw.WriteLine("<html>");
                sw.WriteLine("\t<body>");
                sw.WriteLine("\t\t<svg width=\"100\" height=\"100\">");
                for(int i=0;i<length;i++)
                {   
                    //goes through the stack and writes each shapes printShape() string into the file
                    string temp = canvas.ElementAt(i).printshape();
                    sw.WriteLine("\t\t\t"+temp);
                }
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
                sw.WriteLine("\t\t<svg width=\"100\" height=\"100\">");
                for(int i=0;i<length;i++)
                {
                    //goes through the stack and writes each shapes printShape() string into the file
                    string temp = canvas.ElementAt(i).printshape();
                    sw.WriteLine("\t\t\t"+temp);
                }
                sw.WriteLine("\t\t</svg>");
                sw.WriteLine("\t</body>");
                sw.WriteLine("</html>");
            }
        }
    }


    //######### print to screen ##############
    public void printCanvasToScreen()
    {
        int length = canvas.Count();
        Console.WriteLine("<html>");
        Console.WriteLine("\t<body>");
        Console.WriteLine("\t\t<svg width=\"100\" height=\"100\">");
        for(int i=0;i<length;i++)
        {   
            //goes through the stack and writes each shapes printShape() string into the file
            string temp = canvas.ElementAt(i).printshape();
            Console.WriteLine("\t\t\t"+temp);
        }
        Console.WriteLine("\t\t</svg>");
        Console.WriteLine("\t</body>");
        Console.WriteLine("</html>");
    }
}