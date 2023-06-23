using System.Text;
public class Caretaker
{
   public List<Memento> mementos = new List<Memento>();//where undid shapes are stored

   public List<Memento> canvas = new List<Memento>();//the canvas that will be printed out
   
   //add memento
   public void addMementoToCanvas(Memento m) 
    { 
        //mementos.Add(m); 
        canvas.Add(m);
    }

    //removes the last shape from the canvas
    public void undoFromCanvas()
    {
        if(getSizeCanvas()>=1)
        {
            mementos.Add(canvas[getSizeCanvas()-1]);//add the last element of canvas to mementos
            canvas.RemoveAt(getSizeCanvas()-1);//delete the last element from the canvas
            Console.WriteLine("The last shape has been removed from the canvas.");
        }
        else
        {
            Console.WriteLine("Canvas is empty.");
        }
    }

    //returns the last element of mementos to the canvas
    public void redoToCanvas()
    {
        if(getSizeMemento()>=1)
        {
            canvas.Add(mementos[getSizeMemento()-1]);//add the last element of mementos to canvas
            mementos.RemoveAt(getSizeMemento()-1);//delete the last element of mementos
            Console.WriteLine("The last shape undone has been added back to the canvas.");
        }
        else
        {
            Console.WriteLine("Mementos is empty.");
        }
    }

    //going to need a clear all function that adds everything from canvas to mementos
    public void clearCanvas()
    {
        StringBuilder allshapes = new StringBuilder();
        for(int i = 0;i<getSizeCanvas();i++)//appends all elements in canvas to a string
        {
            allshapes.Append(canvas[i]+"\n");
        }

        string shapesStr = allshapes.ToString();//makes the string builder a string
        Memento shapesMem = new Memento(shapesStr);//makes all the shapes into a memento
        mementos.Add(shapesMem);//adds the canvas to the mementos list

        canvas.Clear();//removes everyhting from canvas
    }

public void PrintSVG()
{
    Console.WriteLine("<html>");
    Console.WriteLine("\t<body>");
    Console.WriteLine("\t\t<svg width=\"100\" height=\"100\">");
    for(int i=0;i<getSizeCanvas();i++)
    {
        string temp = canvas[i].ToString();
        Console.WriteLine("\t\t\t"+temp);
    }
    Console.WriteLine("\t\t</svg>");
    Console.WriteLine("\t</body>");
    Console.WriteLine("</html>");
}

//############### write to .svg file #################
public void WriteToFile()
{
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
            for(int i=0;i<getSizeCanvas();i++)
            {
                string temp = canvas[i].ToString();
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
            for(int i=0;i<getSizeCanvas();i++)
            {
                string temp = canvas[i].ToString();
                sw.WriteLine("\t\t\t"+temp);
            }
            sw.WriteLine("\t\t</svg>");
            sw.WriteLine("\t</body>");
            sw.WriteLine("</html>");
        }
    }
}

    //get sizes
    public int getSizeMemento() 
    { 
        return this.mementos.Count; 
    }

    public int getSizeCanvas()
    {
        return this.canvas.Count;
    }
        
}