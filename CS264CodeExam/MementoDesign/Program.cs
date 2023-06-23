Console.WriteLine("Welcome to Jessica's SVG Emoji Generator (Using Memento design)");
string help = @"add	 { left-eye	| right-eye	| left-brow	| right-brow | mouth }
	 remove	{ left-eye | right-eye | left-brow | right-brow | mouth }
	 move	{ left-eye | right-eye | left-brow | right-brow	| mouth	} {up |	down | left	| right	} value
	 rotate	{ left-eye | right-eye | left-brow | right-brow	| mouth	} {	clockwise |	anticlockwise }	degrees
	 style	{ left-eye | right-eye | left-brow | right-brow	| mouth	} {	A |	B |	C}
	 save	 { <file> }
	 draw
	 undo
	 redo
	 help	
	 quit";
Console.WriteLine(help);//print out the help message after the welcome message
bool run = true;
Caretaker emoji = new Caretaker();
FeatureFactory factory = new FeatureFactory();

while(run)
{
    string command = Console.ReadLine();//get the next command
    string[] commandArr = command.Split(' ');// split it up to find the command

    switch(commandArr[0])
    {
        case "add":
               string newFeature = factory.generate(commandArr[1],'A').printElement('A');//gets the printShape() string
                Memento newFeatureMemento = new Memento(newFeature);//makes that string a memento
                emoji.addMementoToCanvas(newFeatureMemento);//adds that memento to the canvas
                Console.WriteLine("Your feature has been added to the emoji.");
         break;
        case "remove": 
            emoji.removeFeature(commandArr[1]);
            break;

        case "move": break;
        case "rotate": break;
        
        case "style": 
            //remove the current element that is there
            emoji.removeFeature(commandArr[1]);
            //add the new feature with the style
            newFeature = factory.generate(commandArr[1],char.Parse(commandArr[2])).printElement(char.Parse(commandArr[2]));
            newFeatureMemento = new Memento(newFeature);//makes that string a memento
            emoji.addMementoToCanvas(newFeatureMemento);//adds that memento to the canvas
            Console.WriteLine("Your feature has been styled and added to the emoji.");
            break;
        
        case "save": 
            emoji.WriteToFile();
            Console.WriteLine("the emoji has been saved");
            break;
        
        case "draw": 
            emoji.PrintSVG();
            break;
        
        case "undo": 
            emoji.undoFromCanvas();
            break;
        
        case "redo": 
            emoji.redoToCanvas();
            break;
        
        case "help": 
            Console.WriteLine(help);
            break;
        
        case "quit": 
            Console.WriteLine("quitting program...");
            run=false;
            break;
        default: Console.WriteLine("Command not reconized"); break;
    }
}
