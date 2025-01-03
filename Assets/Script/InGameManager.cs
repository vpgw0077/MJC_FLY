using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class InGameManager : MonoBehaviour
{
    [SerializeField] private GameObject startPanel = null;
    [SerializeField] private GameObject resultPanel = null;
    [SerializeField] private Text resultCoin = null;
    [SerializeField] private Text currentCoinText = null;
    [SerializeField] private int currentCoin = 0;

    private CollisionEvent collisionEvent = null;
    // Start is called before the first frame update

    private void Start()
    {
        InitGame();
        collisionEvent = FindObjectOfType<CollisionEvent>();
        collisionEvent.GameOverEvent += GameOver;
    }
    private void InitGame()
    {
        Time.timeScale = 0;
        currentCoin = 0;
        currentCoinText.text = "코인 : " + currentCoin.ToString();
    }
    public void GameStart()
    {
        Time.timeScale = 1;
        startPanel.SetActive(false);
    }

    public void GameOver()
    {
        resultPanel.SetActive(true);
        resultCoin.text = " X " + currentCoin.ToString();
        DataManager_PGW.instance.playerData.totalCoin += currentCoin;
    }

    public void Pasue()
    {
        Time.timeScale = 0;
    }

    public void Resume()
    {
        Time.timeScale = 1;
    }
    public void UpdateCoin(int coin)
    {
        currentCoin += coin;
        currentCoinText.text = "코인 : " + currentCoin.ToString();
    }
}
