using UnityEngine;

public class ResourceLoader 
{
   public static GameObject LoadPrefab(ResourcePath path)
    {
        return Resources.Load<GameObject>(path.PathResource);
    }
    public static Sprite LoadSprite(ResourcePath path)
    {
        return Resources.Load<Sprite>(path.PathResource);
    }
}
