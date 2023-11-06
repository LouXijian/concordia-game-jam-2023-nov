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

        foreach (var heart in HeartImageList)
        {
            heart.transform.localScale *= Screen.width/1534f;
        }
    }

    private void UpdateHPDisplay()
    {
        HeartImageList[4].transform.position = new Vector3(300f, 800f, 0f)*Screen.width/1534f;
        HeartImageList[3].transform.position = new Vector3(240f, 800f, 0f)*Screen.width/1534f;
        HeartImageList[2].transform.position = new Vector3(180f, 800f, 0f)*Screen.width/1534f;
        HeartImageList[1].transform.position = new Vector3(120f, 800f, 0f)*Screen.width/1534f;
        HeartImageList[0].transform.position = new Vector3(60f, 800f, 0f)*Screen.width/1534f;

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