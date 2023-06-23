
public class ShapeFactory
{ 
    StylesFactory styles = new StylesFactory();
    public shape generateDefault(string type,int count)
    {
        
        Console.WriteLine("Do you want custom styles (y/n) ?");
        string YNCustomStyles = Console.ReadLine();
        switch(type)
        {
            case "rect"://handles rectangle
                shape newShape;
                if(YNCustomStyles == "y")
                {
                    newShape  = new rectangle(count,5,8,5,5,styles.customStyles());
                }
                else
                {
                    newShape = new rectangle(count,5,8,5,5,styles.defaultStyles());//makes a new shape
                }
                return newShape;
            case "circ"://handles circle
                if(YNCustomStyles == "y")
                {
                    newShape  = new circle(count,3,9,9,styles.customStyles());
                }
                else
                {
                    newShape = new circle(count,3,9,9,styles.defaultStyles());//makes a new shape
                }
                return newShape;
            case "ellipse"://handles ellipse
                if(YNCustomStyles == "y")
                {
                    newShape  = new ellipse(count,5,10,20,30,styles.customStyles());
                }
                else
                {
                    newShape = new ellipse(count,5,10,20,30,styles.defaultStyles());//makes a new shape
                }
                return newShape;
            case "line"://handles line
                if(YNCustomStyles == "y")
                {
                    newShape  = new line(count,5,5,20,20,styles.customStyles());
                }
                else
                {
                    newShape = new line(count,5,5,20,20,styles.defaultStyles());//makes a new shape
                }
                return newShape;
            case "pl"://handles polyline
                string points="20,20 40,25 60,40 80,120 120,140 200,180";
                if(YNCustomStyles == "y")
                {
                    newShape  = new polyline(count,points,styles.customStyles());
                }
                else
                {
                    newShape = new polyline(count,points,styles.defaultStyles());//makes a new shape
                }
                return newShape;
            case "pg"://handles polygon
                points= "220,10 300,210 170,250 123,234";//gets the points
                if(YNCustomStyles == "y")
                {
                    newShape  = new polygon(count,points,styles.customStyles());
                }
                else
                {
                    newShape = new polygon(count,points,styles.defaultStyles());//makes a new shape
                }
                return newShape;
            case "path"://handles path
                points= "M 10 80 C 40 10, 65 10, 95 80 S 150 150, 180 80";//gets the points
                if(YNCustomStyles == "y")
                {
                    newShape  = new path(count,points,styles.customStyles());
                }
                else
                {
                    newShape = new path(count,points,styles.defaultStyles());//makes a new shape
                }
                return newShape;
            default: Console.WriteLine("Shape not recognized"); return null;
        }
    }
    
    public shape generateCustomShape(string type,int count)
    {
        Console.WriteLine("Do you also want custom styles (y/n) ?");
        string YNCustomStyles = Console.ReadLine();
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
                
                shape newShape;
                if(YNCustomStyles == "y")
                {
                    newShape  = new rectangle(count,5,8,5,5,styles.customStyles());
                }
                else
                {
                    newShape = new rectangle(count,5,8,5,5,styles.defaultStyles());//makes a new shape
                }
                return newShape;
            case "circ"://handles circle
                int r;
                Console.WriteLine("Enter a radius for your circle:");
                r= Convert.ToInt32(Console.ReadLine());//gets the radius
                Console.WriteLine("Enter an x value:");
                x= Convert.ToInt32(Console.ReadLine());//gets x val
                Console.WriteLine("Enter a y value:");
                y= Convert.ToInt32(Console.ReadLine());//gets y val

                if(YNCustomStyles == "y")
                {
                    newShape  = new circle(count,3,9,9,styles.customStyles());
                }
                else
                {
                    newShape = new circle(count,3,9,9,styles.defaultStyles());//makes a new shape
                }
                return newShape;
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

                if(YNCustomStyles == "y")
                {
                    newShape  = new ellipse(count,5,10,20,30,styles.customStyles());
                }
                else
                {
                    newShape = new ellipse(count,5,10,20,30,styles.defaultStyles());//makes a new shape
                }
                return newShape;
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

                if(YNCustomStyles == "y")
                {
                    newShape  = new line(count,5,5,20,20,styles.customStyles());
                }
                else
                {
                    newShape = new line(count,5,5,20,20,styles.defaultStyles());//makes a new shape
                }
                return newShape;
            case "pl"://handles polyline
                string points;
                Console.WriteLine("Enter points for your polyline on one line:");
                points=Console.ReadLine();//gets the points

                if(YNCustomStyles == "y")
                {
                    newShape  = new polyline(count,points,styles.customStyles());
                }
                else
                {
                    newShape = new polyline(count,points,styles.defaultStyles());//makes a new shape
                }
                return newShape;
            case "pg"://handles polygon
                Console.WriteLine("Enter points for your polygon on one line:");
                points= Console.ReadLine();//gets the points

                if(YNCustomStyles == "y")
                {
                    newShape  = new polygon(count,points,styles.customStyles());
                }
                else
                {
                    newShape = new polygon(count,points,styles.defaultStyles());//makes a new shape
                }
                return newShape;
            case "path"://handles path
                Console.WriteLine("Enter points for your path on one line:");
                points= Console.ReadLine();//gets the points

                if(YNCustomStyles == "y")
                {
                    newShape  = new path(count,points,styles.customStyles());
                }
                else
                {
                    newShape = new path(count,points,styles.defaultStyles());//makes a new shape
                }
                return newShape;                                
            default: Console.WriteLine("Shape not recognized"); return null;
        }
    }
}
/*
ShapeFactory factory = new ShapeFactory();
shape shape1 = factory.generateShape("circle");
*/