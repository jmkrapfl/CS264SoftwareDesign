Console.WriteLine("Welcome to Jessica's SVG Emoji Generator (Using Command design)");
string help = @"add	 { left-eye	| right-eye	| left-brow	| right-brow | mouth }
	 remove	{ left-eye | right-eye | left-brow | right-brow | mouth }
	 move	{ left-eye | right-eye | left-brow | right-brow	| mouth	} {up |	down | left	| right	} value
	 rotate	{ left-eye | right-eye | left-brow | right-brow	| mouth	} {	clockwise |	anticlockwise }	degrees
	 style	{ left-eye | right-eye | left-brow | right-brow	| mouth	} { A |	B |	C}
	 save	 { <file> }
	 draw
	 undo
	 redo
	 help	
	 quit";
Console.WriteLine(help);//print out the help message after the welcome message
bool run = true;
Emoji emoji = new Emoji();
User user = new User();
FeatureFactory factory = new FeatureFactory();

while(run)
{
    string command = Console.ReadLine();//get the next command
    string[] commandArr = command.Split(' ');// split it up to find the command

    switch(commandArr[0])
    {
        case "add":
               user.Action(new AddFeatureCommand(factory.generate(commandArr[1]),emoji));
                Console.WriteLine("Your feature has been added to the emoji.");
         break;
        case "remove": 
            switch(commandArr[1])
            {
                case "left-brow":  
                    Feature f =new LeftBrow();
                    user.Action(new RemoveFeatureCommand(emoji,f));
                    break;
                case "left-eye": 
                    f =new LeftEye();
                    user.Action(new RemoveFeatureCommand(emoji,f));
                    break;
                case "right-brow":
                    f =new RightBrow();
                    user.Action(new RemoveFeatureCommand(emoji,f));
                    break;
                case "right-eye": 
                    f =new RightEye();
                    user.Action(new RemoveFeatureCommand(emoji,f));
                    break;
                case "mouth": 
                    f =new Mouth();
                    user.Action(new RemoveFeatureCommand(emoji,f));
                    break;
                default: Console.WriteLine("feature not reconized"); break;
            }
            Console.WriteLine(commandArr[1]+" has been removed");
            break;

        case "move": break;
        case "rotate": break;
        
        case "style": 

            switch(commandArr[1])
            {
                case "left-brow":  
                    Feature f =new LeftBrow();
                    user.Action(new StyleFeatureCommand(f,char.Parse(commandArr[2]), emoji));
                    break;
                case "left-eye": 
                    f =new LeftEye();
                    user.Action(new StyleFeatureCommand(f,char.Parse(commandArr[2]),emoji));
                    break;
                case "right-brow":
                    f =new RightBrow();
                    user.Action(new StyleFeatureCommand(f,char.Parse(commandArr[2]),emoji));
                    break;
                case "right-eye": 
                    f =new RightEye();
                    user.Action(new StyleFeatureCommand(f,char.Parse(commandArr[2]),emoji));
                    break;
                case "mouth": 
                    f =new Mouth();
                    user.Action(new StyleFeatureCommand(f,char.Parse(commandArr[2]),emoji));
                    break;
                default: Console.WriteLine("feature not reconized"); break;
            }
            Console.WriteLine("Your feature has been styled and added to the emoji.");
            break;
        
        case "save": 
            emoji.WriteToFile();
            Console.WriteLine("the emoji has been saved");
            break;
        
        case "draw": 
            emoji.printEmoji();
            break;
        
        case "undo": 
            user.Action(new DeleteFeatureCommand(emoji));
            break;
        
        case "redo": 
            user.Undo();
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
