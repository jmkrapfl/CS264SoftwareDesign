public class RemoveFeatureCommand : Command
{

    Feature shape;
    Emoji canvas;

    public RemoveFeatureCommand(Emoji c, Feature f)
    {
        canvas = c;
        shape = f;
    }

    // Removes a shape from the canvas as "Do" action
    public override void Do()
    {
        
        shape= canvas.removeFeature(shape);
        //canvas.removeFeature(shape);
    }

    // Restores a shape to the canvas as an "Undo" action
    public override void Undo()
    { 
        canvas.Add(shape);
    }
}