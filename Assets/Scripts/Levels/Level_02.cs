using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_02 : MonoBehaviour
{
    [SerializeField] private GameObject winGame;
    [SerializeField] private GameObject GameplayPanel;
    [SerializeField] private GameObject PausePanel;

    private void Start()
    {
        winGame.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Time.timeScale = 0f;
            winGame.SetActive(true);
            PausePanel.SetActive(false);
            GameplayPanel.SetActive(false);
        }
    }
}
