public class FeatureFactory
{
    public Emoji generate(string typeOfFeature, char style)
    {
        Emoji newFeature;
        switch(typeOfFeature)
        {
            case "left-eye": newFeature = new LeftEye(style); return newFeature; 
            case "right-eye": newFeature = new RightEye(style); return newFeature; 
            case "left-brow": newFeature = new LeftBrow(style); return newFeature;
            case "right-brow": newFeature = new RightBrow(style); return newFeature;
            case "mouth": newFeature = new Mouth(style); return newFeature;
            default: Console.WriteLine("emoji feature not reconized");return null;
        }
    }
}