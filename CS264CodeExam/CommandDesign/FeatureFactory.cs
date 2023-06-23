public class FeatureFactory
{
    public Feature generate(string typeOfFeature)
    {
        Feature newFeature;
        switch(typeOfFeature)
        {
            case "left-eye": newFeature = new LeftEye(); return newFeature; 
            case "right-eye": newFeature = new RightEye(); return newFeature; 
            case "left-brow": newFeature = new LeftBrow(); return newFeature;
            case "right-brow": newFeature = new RightBrow(); return newFeature;
            case "mouth": newFeature = new Mouth(); return newFeature;
            default: Console.WriteLine("emoji feature not reconized");return null;
        }
    }
}