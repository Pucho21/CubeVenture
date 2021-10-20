using UnityEngine;
using UnityEngine.UI;

public class EndPanel : MonoBehaviour
{    
    public Text levelText;

    [Space]
    public int scorePerStar =1000;
    public Image star1;
    public Image star2;
    public Image star3;


    [Header("ExtraPointTexts")]
    public int pointsPerEnemy = 50;
    public Text enemyScoreText;
    [Space]
    public int pointsPerCoin = 10;
    public Text coinsScoreText;
    [Space]
    [Header("1s = -1point")]
    public int maxTimePoints = 500; 
    public Text timeText;


    [Header("Score")]
    public Text totalScoreText;
    public Image newHSImage;
    public Text highScoreText;



    public void SetEndPanelValues(int stars,int enemiesKilled,int coinsCollected, int time, int highScore)
    {
        EnableStars(stars);
        enemyScoreText.text = "" + enemiesKilled * pointsPerEnemy;
        coinsScoreText.text = "" + coinsCollected * pointsPerCoin;
        timeText.text = "" + (maxTimePoints - time);
        int totalScore = enemiesKilled * pointsPerEnemy + coinsCollected * pointsPerCoin + (maxTimePoints - time) + scorePerStar * stars;
        if (totalScore > highScore)
            newHSImage.enabled = true;
        totalScoreText.text = "" + totalScore;
        highScoreText.text = "" + highScore;
        gameObject.SetActive(true);
    }


    void EnableStars(int starsCount)
    {
        switch(starsCount)
        {
            case 0:
                star1.color = new Color32(0,0,0,120);
                star2.color = new Color32(0,0,0,120);
                star3.color = new Color32(0,0,0,120);
                star1.transform.GetChild(0).gameObject.SetActive(false);
                star2.transform.GetChild(0).gameObject.SetActive(false);
                star3.transform.GetChild(0).gameObject.SetActive(false);
                break;
            case 1:
                star1.color = Color.white;
                star2.color = new Color32(0, 0, 0, 120);
                star3.color = new Color32(0, 0, 0, 120);
                star1.transform.GetChild(0).gameObject.SetActive(true);
                star2.transform.GetChild(0).gameObject.SetActive(false);
                star3.transform.GetChild(0).gameObject.SetActive(false);
                break;
            case 2:
                star1.color = Color.white;
                star2.color = Color.white;
                star3.color = new Color32(0, 0, 0, 120);
                star1.transform.GetChild(0).gameObject.SetActive(true);
                star2.transform.GetChild(0).gameObject.SetActive(true);
                star3.transform.GetChild(0).gameObject.SetActive(false);
                break;
            case 3:
                star1.color = Color.white;
                star2.color = Color.white;
                star3.color = Color.white;
                star1.transform.GetChild(0).gameObject.SetActive(true);
                star2.transform.GetChild(0).gameObject.SetActive(true);
                star3.transform.GetChild(0).gameObject.SetActive(true);
                break;

        }
    }
}
