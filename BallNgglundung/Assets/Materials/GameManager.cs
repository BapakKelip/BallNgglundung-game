using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Text m_scoreText;
   public int Score { get; set; }

    private void Update()
    {
        if (m_scoreText)
            m_scoreText.text = Score.ToString();
    }
}
