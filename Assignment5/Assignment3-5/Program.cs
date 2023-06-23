/*
Hi demonstraitor below is my program.cs file. I had some issues with the uml stuff i used the right extension
but they where not showing up but it works on my friends computer so im guessing it was just my computer.
instead of getting the umls off visual studio i used this website: 
http://www.plantuml.com/plantuml/uml/SyfFKj2rKt3CoKnELR1Io4ZDoSa70000 to get them. i have also attached a folder 
with screenshots of the uml diagrams
*/

//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ MAIN ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
Console.WriteLine("Welcome to svg shapes maker!");
String  help =@"Commands:
        H	 	     Help - displays this message
        A <shape>	 Add <shape> to canvas
        U	 	     Undo last operation
        R	 	     Redo last operation
        C	 	     Clear canvas
        P            Print canvas to the console
        Q	 	     Quit application
        ********** Shapes **********
        circ         creates a circle
        rect         creates a rectangle
        line         creates a line
        path         creates a path
        pg           creates a polygon
        pl           creates a polyine
        ellipse      creates an ellipse";
Console.WriteLine(help);//print the help info
bool run =true;
//new caretaker
Caretaker canvas = new Caretaker();
//new shape factory
ShapeFactory factory = new ShapeFactory();
while(run)
{
    string command = Console.ReadLine();//get the next command
    string[] commandArr = command.Split(' ');// split it up to find the command

    switch(commandArr[0])
    {
        case "H": Console.WriteLine(help); break;
        case "A": 
            Console.WriteLine("Do you want to create a custom shape (y/n) ?");
            string customShape = Console.ReadLine();
            if(customShape=="y")
            {
                string newShape = factory.generateCustomShape(commandArr[1]).printshape();//gets the printShape() string
                Memento newShapeMemento = new Memento(newShape);//makes that string a memento
                canvas.addMementoToCanvas(newShapeMemento);//adds that memento to the canvas
                Console.WriteLine("Your shape has been added to the canvas.");
            }
            else
            {
                Console.WriteLine("creating a custom shape.");
                string newShape = factory.generateDefault(commandArr[1]).printshape();//gets the printShape() string
                Memento newShapeMemento = new Memento(newShape);//makes that string a memento
                canvas.addMementoToCanvas(newShapeMemento);//adds that memento to the canvas
                Console.WriteLine("Your shape has been added to the canvas.");
            }
            break;
        case "U": 
            canvas.undoFromCanvas();
            break;
        case "R": 
            canvas.redoToCanvas();
            break;
        case "C": 
            canvas.clearCanvas();
            Console.WriteLine("The canvas has been cleared.");
            break;
        case "P": 
            canvas.PrintSVG();
            break;
        case "Q": Console.WriteLine("Quitting program... BYE!"); canvas.WriteToFile(); run = false; break;//quit the program and write to file
        default: Console.WriteLine("Command not reconized. Type Q to quit and H for help."); break;
    }
}

//############### New Shape ##########################
/*
static string ANewShape(String type)
{
    switch(type)
    {
        case "circ":
            int r,x,y;
            Console.WriteLine("Enter a radius for your circle:");
            r= Convert.ToInt32(Console.ReadLine());//gets the radius
            Console.WriteLine("Enter an x value:");
            x= Convert.ToInt32(Console.ReadLine());//gets x val
            Console.WriteLine("Enter a y value:");
            y= Convert.ToInt32(Console.ReadLine());//gets y val
            circle circle = new circle(r,x,y);//makes a new shape
            return circle.printshape();
        case "rect": 
            int height,width;
            Console.WriteLine("Enter a height for your rectangle:");
            height= Convert.ToInt32(Console.ReadLine());//gets the height
            Console.WriteLine("Enter a width:");
            width= Convert.ToInt32(Console.ReadLine());//gets the width
            Console.WriteLine("enter an x value:");
            x= Convert.ToInt32(Console.ReadLine());//gets x val
            Console.WriteLine("Enter a y value:");
            y= Convert.ToInt32(Console.ReadLine());//gets y val
            rectangle rectangle = new rectangle(width,height,x,y);//makes a new shape
            return rectangle.printshape();
        case "line": 
            int sx,sy,ex,ey;
            Console.WriteLine("Enter a start x value for your line:");
            sx= Convert.ToInt32(Console.ReadLine());//gets the start x val
            Console.WriteLine("Enter a start y value:");
            sy= Convert.ToInt32(Console.ReadLine());//gets the start y val
            Console.WriteLine("Enter an end x value:");
            ex= Convert.ToInt32(Console.ReadLine());//gets the end x val
            Console.WriteLine("Enter an end y value:");
            ey= Convert.ToInt32(Console.ReadLine());//gets the end y val
            line line = new line(sx,sy,ex,ey);//makes a new shape
            return line.printshape();
        case "path": 
            string points;
            Console.WriteLine("Enter points for your path on one line:");
            points= Console.ReadLine();//gets the points
            path path = new path(points);//makes a new shape
            return path.printshape();
        case "pg": 
            Console.WriteLine("Enter points for your polygon on one line:");
            points= Console.ReadLine();//gets the points
            polygon polygon = new polygon(points);//makes a new shape
            return polygon.printshape();
        case "pl": 
            Console.WriteLine("Enter points for your polyline on one line:");
            points=Console.ReadLine();//gets the points
            polyline polyl = new polyline(points);
            return polyl.printshape();
        case "ellipse": 
            int rx,ry;
            Console.WriteLine("Enter an x axis radius for your ellipse:");
            rx= Convert.ToInt32(Console.ReadLine());//get x axis radius
            Console.WriteLine("Enter a y axis radius:");
            ry= Convert.ToInt32(Console.ReadLine());//get y axis radius
            Console.WriteLine("Enter an x value:");
            x= Convert.ToInt32(Console.ReadLine());//gets x val
            Console.WriteLine("Enter a y value:");
            y= Convert.ToInt32(Console.ReadLine());//gets y val
            ellipse ellipse = new ellipse(rx,ry,x,y);//makes a new shape
            return ellipse.printshape();
        default: Console.WriteLine("invalid shape"); return null;
    }
}
*/
