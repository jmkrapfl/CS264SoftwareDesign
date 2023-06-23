public class ClearCanvasCommand : Command
{

    Canvas canvas;
    shape shape;

    public ClearCanvasCommand(Canvas c)
    {
        canvas = c;
    }

    // Removes a shape from the canvas as "Do" action
    public override void Do()
    {
        canvas.clearCanvas();
    }

    // Restores a shape to the canvas as an "Undo" action
    public override void Undo()
    {
        canvas.backToCanvas();
    }
}