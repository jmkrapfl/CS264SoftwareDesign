using System.Collections;
//!!!!!!! to undo a clear canvas operation you have to do the R command !!!!!!!!!!!
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
//create the canvas that will hold the list of shapes
Canvas canvas = new Canvas();
// Create user and allow user actions (add and delete) shapes to the canvas
User user = new User();
//create a new shape factory
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
                user.Action(new AddShapeCommand(factory.generateCustomShape(commandArr[1]),canvas));
            }
            else
            {
                Console.WriteLine("creating a defalt shape");
                user.Action(new AddShapeCommand(factory.generateDefault(commandArr[1]),canvas));

            }
            break;
        case "U": 
            user.Action(new DeleteShapeCommand(canvas));
            break;
        case "R":
            user.Undo();
            break;
        case "C":  
            user.Action(new ClearCanvasCommand(canvas));
            break;//clears canvas
        case "P":
            canvas.printCanvasToScreen();//prints the canvas to the screen
            break;
        case "Q": 
            Console.WriteLine("Quitting program... BYE!"); 
            canvas.WriteToFile(); //write to an svg file
            run = false; //quit the program
            break;
        default: Console.WriteLine("Command not reconized. Type Q to quit and H for help."); break;
    }
}

//############################# METHODS ###############################
//*********** add shape method *************
/*
i was able to just copy and paste this method into my factory pattern
static shape addShape(string type)
{
    switch(type)
    {
        case "rect"://handles rectangle
            int height, width,x,y;
            Console.WriteLine("Enter a height for your rectangle:");
            height= Convert.ToInt32(Console.ReadLine());//gets the height
            Console.WriteLine("Enter a width:");
            width= Convert.ToInt32(Console.ReadLine());//gets the width
            Console.WriteLine("enter an x value:");
            x= Convert.ToInt32(Console.ReadLine());//gets x val
            Console.WriteLine("Enter a y value:");
            y= Convert.ToInt32(Console.ReadLine());//gets y val
            return  new rectangle(width,height,x,y);//makes a new shape
        case "circ"://handles circle
            int r;
            Console.WriteLine("Enter a radius for your circle:");
            r= Convert.ToInt32(Console.ReadLine());//gets the radius
            Console.WriteLine("Enter an x value:");
            x= Convert.ToInt32(Console.ReadLine());//gets x val
            Console.WriteLine("Enter a y value:");
            y= Convert.ToInt32(Console.ReadLine());//gets y val
            return new circle(r,x,y);//makes a new shape
        case "ellipse"://handles ellipse
            int rx,ry;
            Console.WriteLine("Enter an x axis radius for your ellipse:");
            rx= Convert.ToInt32(Console.ReadLine());//get x axis radius
            Console.WriteLine("Enter a y axis radius:");
            ry= Convert.ToInt32(Console.ReadLine());//get y axis radius
            Console.WriteLine("Enter an x value:");
            x= Convert.ToInt32(Console.ReadLine());//gets x val
            Console.WriteLine("Enter a y value:");
            y= Convert.ToInt32(Console.ReadLine());//gets y val
            return new ellipse(rx,ry,x,y);//makes a new shape
        case "line"://handles line
            int sx,sy,ex,ey;
            Console.WriteLine("Enter a start x value for your line:");
            sx= Convert.ToInt32(Console.ReadLine());//gets the start x val
            Console.WriteLine("Enter a start y value:");
            sy= Convert.ToInt32(Console.ReadLine());//gets the start y val
            Console.WriteLine("Enter an end x value:");
            ex= Convert.ToInt32(Console.ReadLine());//gets the end x val
            Console.WriteLine("Enter an end y value:");
            ey= Convert.ToInt32(Console.ReadLine());//gets the end y val
            return new line(sx,sy,ex,ey);//makes a new shape
        case "pl"://handles polyline
            string points;
            Console.WriteLine("Enter points for your polyline on one line:");
            points=Console.ReadLine();//gets the points
            return new polyline(points);
        case "pg"://handles polygon
            Console.WriteLine("Enter points for your polygon on one line:");
            points= Console.ReadLine();//gets the points
            return new polygon(points);//makes a new shape
        case "path"://handles path
            Console.WriteLine("Enter points for your path on one line:");
            points= Console.ReadLine();//gets the points
            return new path(points);//makes a new shape
        default: Console.WriteLine("Shape not recognized"); return null;
    }
}
*/
