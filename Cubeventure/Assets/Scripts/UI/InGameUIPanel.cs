using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUIPanel : MonoBehaviour
{
    public static InGameUIPanel instance;

    public Image redGemImg;
    public Image greenGemImg;
    public Image blueGemImg;
    public Image cyanGemImg;
    public Image magentaGemImg;
    public Image yellowGemImg;
    [Space]
    public Text starsCountText;
    [Space]
    public Text coinsCountText;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        UpdateCoinsCountText();
        UpdateStarsCountText();
    }

    public void EnableGemImg(Collectable.collectableType gemType)
    {
        if (gemType == Collectable.collectableType.redGem)
        {
            redGemImg.color = new Color32(255,0,0,255);
        }
        else if (gemType == Collectable.collectableType.greenGem)
        {
            greenGemImg.color = new Color32(0, 154, 23, 255);
        }
        else if (gemType == Collectable.collectableType.blueGem)
        {
            blueGemImg.color = new Color32(30, 47, 255, 255);
        }
        else if (gemType == Collectable.collectableType.cyanGem)
        {
            cyanGemImg.color = new Color32(32, 255, 244, 255);
        }
        else if (gemType == Collectable.collectableType.purpleGem)
        {
            magentaGemImg.color = new Color32(255, 32, 187, 255);
        }
        else if (gemType == Collectable.collectableType.yellowGem)
        {
            yellowGemImg.color = new Color32(245, 236, 13, 255);
        }
    }

    public void UpdateStarsCountText()
    {
        starsCountText.text = GameManager.instance.collectedStarsCount + "/" + GameManager.instance.starsCount;
    }
    public void UpdateCoinsCountText()
    {
        coinsCountText.text = GameManager.instance.collectedCoinsCount + "/" + GameManager.instance.coinsCount;
    }


}
