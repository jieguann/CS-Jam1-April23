using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayHighScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI m_highScoreText;

    private string m_highScoreKey = "HighScore";

    void Awake()
    {
        if (PlayerPrefs.HasKey(m_highScoreKey))
        {
            m_highScoreText.text = PlayerPrefs.GetString(m_highScoreKey);
        }
        else
        {
            m_highScoreText.text = "0";
        }
    }


}
