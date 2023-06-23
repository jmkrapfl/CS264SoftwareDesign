public class StyleFeatureCommand: Command
{
    Feature feature;
    Emoji canvas;
    char style;
    public StyleFeatureCommand(Feature feature, char style, Emoji canvas)
    {
        this.feature=feature;
        this.style= style;
        this.canvas=canvas;
    }

    public override void Do()
    {
        canvas.style(feature, style);
    }

    public override void Undo()
    {
        canvas.style(feature, 'A');
    }
}