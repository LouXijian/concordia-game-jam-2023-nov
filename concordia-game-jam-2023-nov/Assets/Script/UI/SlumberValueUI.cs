using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SlumberValueUI : MonoBehaviour
{
    public List<Image> HeartImageList;
    public SpriteManager SpriteController;
    public Slumber MonsterSlumber;
    
    int m_CurrentHP;

    private void Start()
    {
        MonsterSlumber.SlumberValueChange += UpdateHPDisplay;
        UpdateHPDisplay();
    }

    private void UpdateHPDisplay()
    {
        switch (MonsterSlumber.SlumberLevel)
        {
            case(100):
            {
                foreach (var heart in HeartImageList)
                {
                    heart.sprite = SpriteController.GetSprite("EyeClose");
                }
                break;
            }
            case (90):
            {
                HeartImageList[4].sprite = SpriteController.GetSprite("EyeHalf");
                break;
            }
            case (80):
            {
                HeartImageList[4].sprite = SpriteController.GetSprite("EyeOpen");
                break;
            }
            case (70):
            {
                HeartImageList[3].sprite = SpriteController.GetSprite("EyeHalf");
                break;
            }
            case (60):
            {
                HeartImageList[3].sprite = SpriteController.GetSprite("EyeOpen");
                break;
            }
            case (50):
            {
                HeartImageList[2].sprite = SpriteController.GetSprite("EyeHalf");
                break;
            }
            case (40):
            {
                HeartImageList[2].sprite = SpriteController.GetSprite("EyeOpen");
                break;
            }
            case (30):
            {
                HeartImageList[1].sprite = SpriteController.GetSprite("EyeHalf");
                break;
            }
            case (20):
            {
                HeartImageList[1].sprite = SpriteController.GetSprite("EyeOpen");
                break;
            }
            case (10):
            {
                HeartImageList[0].sprite = SpriteController.GetSprite("EyeHalf");
                break;
            }
            case (0):
            {
                HeartImageList[0].sprite = SpriteController.GetSprite("EyeOpen");
                break;
            }
        }
    }
}