using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InGameRecorder : MonoBehaviour
{

    [SerializeField] private GameObject resultPanel = null;
    [SerializeField] private CanvasGroup canvasGroup = null;
    [SerializeField]private GameObject gameStartTrigger = null;

    [Space]
    [Header("Coin Component")]
    [SerializeField] private TextMeshProUGUI resultCoin = null;
    [SerializeField] private TextMeshProUGUI currentCoinText = null;
    [SerializeField] private int currentCoin = 0;

    [SerializeField] private AudioClip bgm = null;

    [Space]
    [Header("Distance Component")]
    [SerializeField] private float currentDistance = 0;
    [SerializeField] private TextMeshProUGUI distanceText = null;
    [SerializeField] private TextMeshProUGUI resultDistance = null;
    [SerializeField] private GameObject newRecordImg = null;

    private bool isGameStart = false;

    private CollisionEvent collisionEvent = null;

    // Start is called before the first frame update
    private void Awake()
    {
        Init();
    }
    void Start()
    {
        collisionEvent = FindObjectOfType<CollisionEvent>();
        collisionEvent.gameOverEvent += ShowResult;
        collisionEvent.gameStartEvent += CheckPlayerStart;
    }

    private void Init()
    {
        currentCoin = 0;
        currentCoinText.text = "0";
        currentDistance = 0;
        distanceText.text = "0M";

        isGameStart = false;
        SoundManager.instance.PlayBGM(bgm);
    }

    public void UpdateCoin(int amount)
    {
        currentCoin += amount;
        currentCoinText.text = string.Format("{0:#,###0}", currentCoin);
    }

    private void UpdateDistance()
    {
        if (isGameStart)
        {
            currentDistance += Time.deltaTime;
            distanceText.text = string.Format("{0:#,###0}", Mathf.Floor(currentDistance)) + "M";

        }
    }

    private void CheckPlayerStart()
    {
        isGameStart = true;
        gameStartTrigger.SetActive(false);
    }

    private void ShowResult()
    {
        resultPanel.SetActive(true);
        canvasGroup.blocksRaycasts = false;

        resultCoin.text = string.Format("{0:#,###0}", currentCoin);
        resultDistance.text = string.Format("{0:#,###0}", Mathf.Floor(currentDistance)) + "M";

        DataManager_PGW.instance.playerData.totalCoin += currentCoin;

        if(Mathf.Floor(DataManager_PGW.instance.playerData.distanceRecord) < Mathf.Floor(currentDistance))
        {
            newRecordImg.SetActive(true);
            DataManager_PGW.instance.playerData.distanceRecord = Mathf.Floor(currentDistance);
        }


    }
    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 1)
        {
            UpdateDistance();
        }
    }

}
