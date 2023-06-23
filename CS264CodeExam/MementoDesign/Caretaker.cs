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
            Console.WriteLine("The last feature has been removed from the emoji.");
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
            Console.WriteLine("The last feature undone has been added back to the emoji.");
        }
        else
        {
            Console.WriteLine("Mementos is empty.");
        }
    }

    //going to need a clear all function that adds everything from canvas to mementos
    public void clearCanvas()
    {
        StringBuilder allfeatures = new StringBuilder();
        for(int i = 0;i<getSizeCanvas();i++)//appends all elements in canvas to a string
        {
            allfeatures.Append(canvas[i]+"\n");
        }

        string shapesStr = allfeatures.ToString();//makes the string builder a string
        Memento shapesMem = new Memento(shapesStr);//makes all the shapes into a memento
        mementos.Add(shapesMem);//adds the canvas to the mementos list

        canvas.Clear();//removes everyhting from canvas
    }

//\\\\\\\\\\\\\\\\ remove feature\\\\\\\\\\\\\\\\\\
    public void removeFeature(string removeThis)
    {
        for(int i=0;i<getSizeCanvas(); i++)
        {
            string features = canvas[i].ToString();//make the first element in canvas a string
            string[] featArr = features.Split(" ");//splits up the string by spaces
            if(featArr[1]==removeThis)
            {
                mementos.Add(canvas[i]);//add the last element of canvas to mementos
                canvas.RemoveAt(i);//remove from the canvas
            }
        }
        Console.WriteLine(removeThis + " has been removed from emoji.");
    }

    

public void PrintSVG()
{
    //writes the svg into the console
    Console.WriteLine("<svg width=\"120\" height=\"120\"xmlns=\"http://www.w3.org/2000/svg>");
    Console.WriteLine("\t<g>");
    Console.WriteLine("\t\t<!-- body  -->");
    Console.WriteLine("\t\t<circle cx=\"60\" cy=\"60\" r=\"55\" stroke=\"black\" stroke-width=\"3\" fill=\"yellow\"/>");
    for(int i=0;i<getSizeCanvas();i++)
    {
        string temp = canvas[i].ToString();
        Console.WriteLine("\t\t"+temp);
    }
    Console.WriteLine("\t<g>");
    Console.WriteLine("</svg>");
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
            sw.WriteLine("<svg width=\"120\" height=\"120\"xmlns=\"http://www.w3.org/2000/svg>");
            sw.WriteLine("\t<g>");
            sw.WriteLine("\t\t<!-- body  -->");
            sw.WriteLine("\t\t<circle cx=\"60\" cy=\"60\" r=\"55\" stroke=\"black\" stroke-width=\"3\" fill=\"yellow\"/>");
            for(int i=0;i<getSizeCanvas();i++)
            {
                string temp = canvas[i].ToString();
                sw.WriteLine("\t\t"+temp);
            }
            sw.WriteLine("\t<g>");
            sw.WriteLine("</svg>");
        }
    }
    else
    {
        using (StreamWriter sw = File.CreateText(path))
        {
            //writes the svg into the file
            sw.WriteLine("<svg width=\"120\" height=\"120\"xmlns=\"http://www.w3.org/2000/svg>");
            sw.WriteLine("\t<g>");
            sw.WriteLine("\t\t<!-- body  -->");
            sw.WriteLine("\t\t<circle cx=\"60\" cy=\"60\" r=\"55\" stroke=\"black\" stroke-width=\"3\" fill=\"yellow\"/>");
            for(int i=0;i<getSizeCanvas();i++)
            {
                string temp = canvas[i].ToString();
                sw.WriteLine("\t\t"+temp);
            }
            sw.WriteLine("\t<g>");
            sw.WriteLine("</svg>");
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