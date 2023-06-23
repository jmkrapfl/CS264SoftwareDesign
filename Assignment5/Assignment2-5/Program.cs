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
ShapeFactory factory =  new ShapeFactory();
int count = 0;//keeps track of how many shapes are in the arraylist
while(run)
{
    string command = Console.ReadLine();//get the next command
    string[] commandArr = command.Split(' ');// split it up to find the - flag

    switch(commandArr[0])
    {
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
        default: 
            allShapes.Add(factory.generateCustomShape(commandArr[0],count).printshape());//adds the shape into the arraylist
            Console.WriteLine("Next shape or -end to end.");
            count++;
            break;
    }
}
object[] shapeObj = allShapes.ToArray();//covert allshapes into an oject array to be written into the file
WriteToFile(shapeObj);//write to the file

//############# update ###############
static ArrayList update(int id, ArrayList arrList)
{
    StylesFactory styles = new StylesFactory();
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
            rectangle rectangle = new rectangle(id, width,height,x,y,styles.customStyles());//makes a new object
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
            circle circle = new circle(id,r,x,y,styles.customStyles());//makes a new object
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
            ellipse ellipse = new ellipse(id,rx,ry,x,y,styles.customStyles());//makes a new object
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
            line line = new line(id,sx,sy,ex,ey,styles.customStyles());//makes a new object
            arrList[id]= line.printshape();//puts the new string into the arraylist
            return arrList;
        case "<polyline": 
            string points;
            Console.WriteLine("Looks like that shape was a polyline. Please enter new points on one line:");
            points=Console.ReadLine();//new points
            polyline polyl = new polyline(id,points,styles.customStyles());//makes a new object
            arrList[id]= polyl.printshape();//puts the new string into the arraylist
            return arrList;
        case "<polygon": 
            Console.WriteLine("Looks like that shape was a polygon. Please enter new points on one line:");
            points=Console.ReadLine();//new points
            polygon polygon = new polygon(id,points,styles.customStyles());//makes a new object
            arrList[id]= polygon.printshape();//puts the new string into the arraylist
            return arrList;
        case "<path": 
            Console.WriteLine("Looks like that shape was a path. Please enter new points on one line:");
            points=Console.ReadLine();//new points
            path path = new path(id,points,styles.customStyles());//makes a new object
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