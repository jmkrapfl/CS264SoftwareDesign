using System.Collections;
//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ MAIN ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
Console.WriteLine("Welcome to svg shapes maker!");
String  help =@"-r,    new Rectangle
-c,    new circle 
-e,    new ellipse
-l,    new line
-pl,   new polyline
-pg,   new polygon
-p,    new path
-u,    update a shape already made
-d,    delete a shape already made
-h,    print this message again
-end,  end the program";
Console.WriteLine(help);//print the help info
bool run =true;
ArrayList allShapes = new ArrayList();
int count = 0;//keeps track of how many shapes are in the arraylist
while(run)
{
    string command = Console.ReadLine();//get the next command
    string[] commandArr = command.Split(' ');// split it up to find the - flag

    switch(commandArr[0])
    {
        case "-r"://handles rectangle
            int height, width,x,y;
            Console.WriteLine("Enter a height for your rectangle:");
            height= Convert.ToInt32(Console.ReadLine());//gets the height
            Console.WriteLine("Enter a width:");
            width= Convert.ToInt32(Console.ReadLine());//gets the width
            Console.WriteLine("enter an x value:");
            x= Convert.ToInt32(Console.ReadLine());//gets x val
            Console.WriteLine("Enter a y value:");
            y= Convert.ToInt32(Console.ReadLine());//gets y val
            rectangle rectangle = new rectangle(count, width,height,x,y);//makes a new shape
            allShapes.Add(rectangle.printshape());//adds the shape into the arraylist
            Console.WriteLine("Next shape or -end to end.");
            count++;
            break;
        case "-c"://handles circle
            int r;
            Console.WriteLine("Enter a radius for your circle:");
            r= Convert.ToInt32(Console.ReadLine());//gets the radius
            Console.WriteLine("Enter an x value:");
            x= Convert.ToInt32(Console.ReadLine());//gets x val
            Console.WriteLine("Enter a y value:");
            y= Convert.ToInt32(Console.ReadLine());//gets y val
            circle circle = new circle(count,r,x,y);//makes a new shape
            allShapes.Add(circle.printshape());//adds the shape into the arraylist
            Console.WriteLine("Next shape or -end to end.");
            count++;
            break;
        case "-e"://handles ellipse
            int rx,ry;
            Console.WriteLine("Enter an x axis radius for your ellipse:");
            rx= Convert.ToInt32(Console.ReadLine());//get x axis radius
            Console.WriteLine("Enter a y axis radius:");
            ry= Convert.ToInt32(Console.ReadLine());//get y axis radius
            Console.WriteLine("Enter an x value:");
            x= Convert.ToInt32(Console.ReadLine());//gets x val
            Console.WriteLine("Enter a y value:");
            y= Convert.ToInt32(Console.ReadLine());//gets y val
            ellipse ellipse = new ellipse(count,rx,ry,x,y);//makes a new shape
            allShapes.Add(ellipse.printshape());//adds the shape into the arraylist
            Console.WriteLine("Next shape or -end to end.");
            count++;
            break;
        case "-l"://handles line
            int sx,sy,ex,ey;
            Console.WriteLine("Enter a start x value for your line:");
            sx= Convert.ToInt32(Console.ReadLine());//gets the start x val
            Console.WriteLine("Enter a start y value:");
            sy= Convert.ToInt32(Console.ReadLine());//gets the start y val
            Console.WriteLine("Enter an end x value:");
            ex= Convert.ToInt32(Console.ReadLine());//gets the end x val
            Console.WriteLine("Enter an end y value:");
            ey= Convert.ToInt32(Console.ReadLine());//gets the end y val
            line line = new line(count,sx,sy,ex,ey);//makes a new shape
            allShapes.Add(line.printshape());//adds the shape into the arraylist
            Console.WriteLine("Next shape or -end to end.");
            count++;
            break;
        case "-pl"://handles polyline
            string points;
            Console.WriteLine("Enter points for your polyline on one line:");
            points=Console.ReadLine();//gets the points
            polyline polyl = new polyline(count,points);
            allShapes.Add(polyl.printshape());//adds the shape into the arraylist
            Console.WriteLine("Next shape or -end to end.");
            count++;
            break;
        case "-pg"://handles polygon
            Console.WriteLine("Enter points for your polygon on one line:");
            points= Console.ReadLine();//gets the points
            polygon polygon = new polygon(count,points);//makes a new shape
            allShapes.Add(polygon.printshape());//adds the shape into the arraylist
            Console.WriteLine("Next shape or -end to end.");
            count++;
            break;
        case "-p"://handles path
            Console.WriteLine("Enter points for your path on one line:");
            points= Console.ReadLine();//gets the points
            path path = new path(count,points);//makes a new shape
            allShapes.Add(path.printshape());//adds the shape into the arraylist
            Console.WriteLine("Next shape or -end to end.");
            count++;
            break;
        case "-u"://handles update
            int id;
            Console.WriteLine("Enter the number of the shape you want to update (first shape entered would be 0. Dont count deleted shapes.):");
            id=Convert.ToInt32(Console.ReadLine());
            allShapes = update(id,allShapes);//updates the shapes array list to include the updates made
            Console.WriteLine("The shape has been updated.");
            Console.WriteLine("Next shape or -end to end.");
            break;
        case "-d"://handles delete
            Console.WriteLine("Enter the number of the shape you want to delete (first shape entered would be 0):");
            id=Convert.ToInt32(Console.ReadLine());//gets the id of the shape to be deleted
            delete(id,allShapes);//calls the delete method and deletes the shape
            Console.WriteLine("Shape number "+id+" is deleted.");
            Console.WriteLine("Next shape or -end to end.");
            count--;
            break;
        case "-h"://prints the help message again if needed
            Console.WriteLine(help); Console.WriteLine("Next shape or -end to end."); break;
        case "-end"://ends the program
            run =false; break;
        default: Console.WriteLine("Not a reconized command."); Console.WriteLine("Next shape or -end to end."); break;
    }
}
object[] shapeObj = allShapes.ToArray();//covert allshapes into an oject array to be written into the file
WriteToFile(shapeObj);//write to the file

//############# update ###############
static ArrayList update(int id, ArrayList arrList)
{
    object toUpdate = arrList[id];
    string str = toUpdate.ToString();
    string[] Arr = str.Split(" ");

    switch(Arr[0])
    {
        case "<rect": 
            int height, width,x,y;
            Console.WriteLine("Looks like that shape was a rectangle. Please enter a new height");
            height= Convert.ToInt32(Console.ReadLine());//gets new height
            Console.WriteLine("Enter a new width:");
            width= Convert.ToInt32(Console.ReadLine());//gets neww width
            Console.WriteLine("Enter a new x value:");
            x= Convert.ToInt32(Console.ReadLine());//gets new x
            Console.WriteLine("Enter a new y value:");
            y= Convert.ToInt32(Console.ReadLine());//gets new y
            rectangle rectangle = new rectangle(id, width,height,x,y);//makes a new object
            arrList[id]= rectangle.printshape();//puts the new string into the arraylist
            return arrList;
        case "<circle": 
            int r;
            Console.WriteLine("Looks like that shape was a circle. Please enter a new radius:");
            r= Convert.ToInt32(Console.ReadLine());//gets new radius
            Console.WriteLine("Enter a new x value:");
            x= Convert.ToInt32(Console.ReadLine());//gets new x
            Console.WriteLine("Enter a new y value:");
            y= Convert.ToInt32(Console.ReadLine());//gets new y
            circle circle = new circle(id,r,x,y);//makes a new object
            arrList[id]= circle.printshape();//puts the new string into the arraylist
            return arrList;
        case "<ellipse": 
            int rx,ry;
            Console.WriteLine("Looks like that shape was an ellipse. Please enter a new x axis radius:");
            rx= Convert.ToInt32(Console.ReadLine());//new x axiss radius
            Console.WriteLine("Enter a new y axis radius:");
            ry= Convert.ToInt32(Console.ReadLine());//new y axiss radius
            Console.WriteLine("Enter a new x value:");
            x= Convert.ToInt32(Console.ReadLine());//new x 
            Console.WriteLine("Enter a new y value:");
            y= Convert.ToInt32(Console.ReadLine());//new y
            ellipse ellipse = new ellipse(id,rx,ry,x,y);//makes a new object
            arrList[id]= ellipse.printshape();//puts the new string into the arraylist
            return arrList;
        case "<line": 
            int sx,sy,ex,ey;
            Console.WriteLine("Looks like that shape was a line. Please enter a new start x value:");
            sx= Convert.ToInt32(Console.ReadLine());//new start x
            Console.WriteLine("Enter a new start y value:");
            sy= Convert.ToInt32(Console.ReadLine());//new start y
            Console.WriteLine("Enter a new end x value:");
            ex= Convert.ToInt32(Console.ReadLine());//new end x
            Console.WriteLine("Enter a new end y value:");
            ey= Convert.ToInt32(Console.ReadLine());//new end y
            line line = new line(id,sx,sy,ex,ey);//makes a new object
            arrList[id]= line.printshape();//puts the new string into the arraylist
            return arrList;
        case "<polyline": 
            string points;
            Console.WriteLine("Looks like that shape was a polyline. Please enter new points on one line:");
            points=Console.ReadLine();//new points
            polyline polyl = new polyline(id,points);//makes a new object
            arrList[id]= polyl.printshape();//puts the new string into the arraylist
            return arrList;
        case "<polygon": 
            Console.WriteLine("Looks like that shape was a polygon. Please enter new points on one line:");
            points=Console.ReadLine();//new points
            polygon polygon = new polygon(id,points);//makes a new object
            arrList[id]= polygon.printshape();//puts the new string into the arraylist
            return arrList;
        case "<path": 
            Console.WriteLine("Looks like that shape was a path. Please enter new points on one line:");
            points=Console.ReadLine();//new points
            path path = new path(id,points);//makes a new object
            arrList[id]= path.printshape();//puts the new string into the arraylist
            return arrList;
        default: return arrList;
    }
}

//############# Delete ###############
static void delete(int id, ArrayList arrList)
{
    arrList.RemoveAt(id);//removes the shape to be deleted
}

//############### write to .svg file #################
static void WriteToFile(object[] arrShapes)
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
            for(int i=0;i<arrShapes.Length;i++)
            {
                sw.WriteLine("\t\t\t"+arrShapes[i]);
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
            for(int i=0;i<arrShapes.Length;i++)
            {
                sw.WriteLine("\t\t\t"+arrShapes[i]);
            }
            sw.WriteLine("\t\t</svg>");
            sw.WriteLine("\t</body>");
            sw.WriteLine("</html>");
        }
    }
}
//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ SHAPES CLASSES ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
public abstract class shape
{
    public abstract string printshape();
}

//###### RECTANGLE #######
public class rectangle:shape
{
    public int width { get; }
    public int height { get; }
    public int xCoord { get; }
    public int yCoord { get; }
    public int id { get; }
    public rectangle(int id,int width,int height,int xCoord,int yCoord)
    {
        this.xCoord=xCoord;
        this.yCoord=yCoord;
        this.width=width;
        this.height=height;
        this.id=id;
    }
    public override string printshape()
    {
        string data = "<rect width=\""+this.width+"\" height=\""+this.height+"\" x=\""+this.xCoord+"\""+" y=\""+this.yCoord+"\"/>";
        return data;
    }
}


//###### CIRCLE #######
public class circle:shape
{
    public int radius { get; }
    public int xCoord { get; }
    public int yCoord { get; }
    public int id {get;}
    
    public circle(int id,int radius,int xCoord,int yCoord)
    {
        this.xCoord=xCoord;
        this.yCoord=yCoord;
        this.radius=radius;
        this.id=id;
    }

    public override string printshape()
    {
        string data = "<circle cx=\""+this.xCoord+"\" cy=\""+this.yCoord+"\" r=\""+this.radius+"\"/>";
        return data;
    }
}

//###### ELLIPSE #######
public class ellipse:shape
{
    public int rx { get; }//radis on the x axis
    public int ry { get; }//radis on the y axis
    public int xCoord { get; }
    public int yCoord { get; }
    public int id {get;}

    public ellipse(int id,int xCoord,int yCoord, int rx, int ry)
    {
        this.xCoord=xCoord;
        this.yCoord=yCoord;
        this.rx=rx;
        this.ry=ry;
        this.id=id;
    }

    public override string printshape()
    {
        string data = "<ellipse cx=\""+this.xCoord+"\" cy=\""+this.yCoord+"\" rx=\""+this.rx+"\" ry=\""+this.ry+"\"/>";
        return data;
    }
}

//###### LINE #######
public class line:shape
{
    public int xStart { get; }
    public int yStart { get; }
    public int xEnd { get; }
    public int yEnd { get; }
    public int id {get;}

    public line(int id,int xStart,int yStart,int xEnd,int yEnd)
    {
        this.xStart=xStart;
        this.yStart=yStart;
        this.xEnd=xEnd;
        this.yEnd=yEnd;
        this.id=id;
    }

    public override string printshape()
    {
        string data = "<line x1=\""+xStart+"\" y1=\""+yStart+"\" x2=\""+xEnd+"\" y2=\""+yEnd+"\" stroke=\"black\"/>";
        return data;
    }
}

//###### POLYLINE #######
public class polyline:shape
{
    public string points { get; }
    public int id {get;}

    public polyline(int id,string points)
    {
        this.points=points;
        this.id=id;
    }
    public override string printshape()
    {
        string data = "<polyline points=\""+this.points+"\" style=\"fill:none;stroke:black;stroke-width:3\"/>";
        return data;
    }
}

//###### POLYGON #######
public class polygon:shape
{
    public string points {get;}
    public int id {get;}

    public polygon(int id,string points)
    {
        this.points=points;
        this.id=id;
    }

    public override string printshape()
    {
        string data = "<polygon points=\""+this.points+"\" style=\"fill:black;stroke:black;stroke-width:1\"/>";
        return data;
    }
}

//###### PATH #######
public class path:shape
{
    public string p { get; }
    public int id {get;}

    public path(int id,string p)
    {
        this.p=p;
        this.id=id;
    }

   public override string printshape()
    {
        string data = "<path p=\""+this.p+"\" stroke=\"black\"/>";
        return data;
    }
}