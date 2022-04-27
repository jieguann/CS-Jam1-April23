using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    private Button playButton;
    private GameManagerTest gameManagerTest;

    public int level;

    // Start is called before the first frame update
    void Start()
    {
        playButton = GetComponent<Button>();
        gameManagerTest = GameObject.Find("GameMangagerTest").GetComponent<GameManagerTest>();
        playButton.onClick.AddListener(SetLevel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetLevel()
    {
        Debug.Log(playButton.gameObject.name + "Play was clicked");
        gameManagerTest.StartGame(level);
    }

}
