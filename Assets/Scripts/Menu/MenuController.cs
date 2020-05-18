using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private Text recordText;
    [SerializeField] private Text moneyText;

    private void Start()
    {
        //PlayerPrefs.DeleteAll();
        playButton.onClick.AddListener(PlayButton_OnClick);
        exitButton.onClick.AddListener(ExitButton_OnClick);

        recordText.text = DataManager.BestScore.ToString();
        moneyText.text = DataManager.Money.ToString();
    }

    private void PlayButton_OnClick()
    {
        SceneManager.LoadScene(1);
    }

    private void ExitButton_OnClick()
    {
        Application.Quit();
    }
}
