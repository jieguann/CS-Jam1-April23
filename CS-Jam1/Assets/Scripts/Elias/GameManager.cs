using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;//allows to save data
using UnityEngine.SceneManagement; // allows sceneSwitch

public class GameManager : MonoBehaviour
{
    public static GameManager s_instance;

    [SerializeField] private TextMeshProUGUI m_highScoreText;
    [SerializeField] private TextMeshProUGUI m_currentScoreText;

    private int m_currentScore;
    private int m_highScore;
    //private string m_scoreKey = "HighScore";//used in player prefs approach?

    // added for play and screenSwitch
    public GameObject entranceCanvas;
    bool isGameActive;
    private float spawnRate;

    // added for CountDownTimer
    public int NextSceneToLoad;
    

    public float timer = 3f;
    public TMP_Text timerSeconds;


    public void AddScore(int points)
    {
        m_currentScore += points;
        m_currentScoreText.text =  m_currentScore.ToString();

        if (m_currentScore > m_highScore)
        {
            m_highScore = m_currentScore;
            m_highScoreText.text = m_highScore.ToString();
        }
    }

    void Awake()
    {
        isGameActive = true; // added for playButton

        if (s_instance == null)
        {
            s_instance = this;
        }
        else
        {
            Debug.LogError("mltiple singleton instances!");
        }

        if (File.Exists(Application.dataPath + "/SaveData.json"))
        //if(PlayerPrefs.HasKey("HighScore"))if  using Playerprefs use this line. player prefs  when thhiings get more complicated
        {
            string json = File.ReadAllText(Application.dataPath + "/SaveData.json");//reads text file
            SaveData data = JsonUtility.FromJson<SaveData>(json);//convert back from jason to data variablee

            m_highScore = int.Parse(data.highScore);
            m_highScoreText.text =  m_highScore.ToString();

        }
    }

    // added for CountDownTimer
    void Update()
    {
        timer -= Time.deltaTime;
        timerSeconds.text = timer.ToString("f2");
        if (timer <= 0)
        {
            SceneManager.LoadScene(NextSceneToLoad);

        }
    }

    // added for playButton -> wait one second until GlimmWimms show up
    IEnumerator SpawnTarget()
    {
        while(isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
        }
    }

    // added to start Game
    public void StartGame(int level)
    {
        isGameActive = true;
        spawnRate /= level;

        StartCoroutine(SpawnTarget());

        entranceCanvas.gameObject.SetActive(false);

        SceneManager.LoadScene(level);
    }

    private void OnApplicationQuit()
    {
        if (m_currentScore >= m_highScore)
        {
            SaveData data = new SaveData();//gets refeerence to the class
            data.highScore = m_highScore.ToString();//assigns value
            string json = JsonUtility.ToJson(data);//converts data into jason format..ovnverts to string
            File.WriteAllText(Application.dataPath + "/SaveData.json", json);//strng gets written to file
        }
    }
}
