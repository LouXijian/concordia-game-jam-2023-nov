using System.Collections.Generic;
using UnityEngine;

public class SpriteManager : MonoBehaviour
{
    public List<SpriteInfo> SpriteList = new ();
    public Dictionary<string, Sprite> spriteDictionary = new ();

    void Start()
    {
        foreach (var spriteInfo in SpriteList)
        {
            spriteDictionary[spriteInfo.Name] = spriteInfo.Sprite;
        }
    }

    public Sprite GetSprite(string spriteName)
    {
        if (spriteDictionary.Count == 0)
        {
            Start();
        }
        if (spriteDictionary.TryGetValue(spriteName, out var sprite))
        {
            return sprite;
        }
        return null; 
    }
}

[System.Serializable]
public class SpriteInfo
{
    public string Name;
    public Sprite Sprite;
}