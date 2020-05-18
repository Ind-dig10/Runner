using UnityEngine;
using UnityEngine.UI;

public class GameInterface : MonoBehaviour
{
    [SerializeField] private Text countMeters;
    [SerializeField] private Text moneyText;
    [SerializeField] private Text scoreRoundText;
    [SerializeField] private Text moneyRoundText;
    [SerializeField] private Text bestScoreTest;

    [SerializeField] private Button pauseButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private GameController gameController;


    private void Start()
    {
        pauseButton.onClick.AddListener(gameController.PauseGame);
    }

    private void Update()
    {
        DistanceCount();
        MoneyCount();
    }

    public void DistanceCount()
    {
        DistanceCount(gameController.DistanePlayer.ToString());
    }

    private void DistanceCount(string valueMeters)
    {
        countMeters.text = valueMeters;
        scoreRoundText.text = valueMeters;
    }

    public void MoneyCount()
    {
        MoneyCount(gameController.MoneyPlayer.ToString());
    }

    private void MoneyCount(string valueMoney)
    {
        moneyText.text = valueMoney;
        moneyRoundText.text = valueMoney;
        bestScoreTest.text = DataManager.BestScore.ToString();
    }
}
