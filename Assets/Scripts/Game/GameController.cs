using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private PlayerController playerObject;
    [SerializeField] private Transform startPosition;
    [SerializeField] private GameObject gameOverWindow;
    [SerializeField] private GameObject startWindow;
    [SerializeField] private PlaceGeneration mapGenerator;

    private int moneyPlayer;
    private int distancePlayer;
    private E_GameStatus gameStatus;
    private E_GameStatus temp;

    public static bool isRun;

    public int MoneyPlayer => moneyPlayer;

    public int DistanePlayer => distancePlayer;

    private void Start()
    {
  
        gameStatus = E_GameStatus.Start;
        playerObject.onMoneyCollect += TrigerMoney;
    }

    private void Update()
    {
        RunPlayer();
        StartCoroutine(EndGame());
        Distance();

    }

    private void RunPlayer()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            startWindow.SetActive(false);
            gameStatus = E_GameStatus.Play;
            isRun = true;
        }
    }

    private IEnumerator EndGame()
    {
        if(!isRun && gameStatus == E_GameStatus.Play)
        {
            gameStatus = E_GameStatus.End;
            yield return new WaitForSeconds(1);
            gameOverWindow.SetActive(true);
            DataManager.EndGame(moneyPlayer, distancePlayer);
        }
    }

    public void PauseGame()
    {
        if (gameStatus == E_GameStatus.Pause)
        {
            Time.timeScale = 1f;
            gameStatus = temp;
            return;
        }

        Time.timeScale = 0;
        temp = gameStatus;
        gameStatus = E_GameStatus.Pause;

    }

    public void RestartGame()
    {
        gameStatus = E_GameStatus.Start;
        gameOverWindow.SetActive(false);
        isRun = false;
        moneyPlayer = 0;
        distancePlayer = 0;
        playerObject.SelfTransform.position = startPosition.position;
        mapGenerator.Restart();
    }

    private void Distance()
    {
        distancePlayer = (int)playerObject.SelfTransform.position.z;
    }

    private void TrigerMoney(int count)
    {
        moneyPlayer += count;
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
