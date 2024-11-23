using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField] private TMP_Text giftCountText;
    [SerializeField] private GameObject GameplayUI;
    [SerializeField] private GameObject PuaseMenuUI;

    private void Start()
    {
        GameManager.Instance.RegisterUiManager(this);
        GameplayUI.SetActive(true);
        PuaseMenuUI.SetActive(false);
    }

    public void UpdateGiftCount( int count)
    {
        giftCountText.text = " X " + count.ToString("00");
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        GameplayUI.SetActive(false);
        PuaseMenuUI.SetActive(true);
    }

    public void GameRestart()
    {
        GameManager.Instance.RestartLevel();
        Time.timeScale = 1f;
        GameplayUI.SetActive(true);
        PuaseMenuUI.SetActive(false);
    }

    public void GotoMainMenu()
    {
        GameManager.Instance.GoToMainMenu();
        Time.timeScale = 1f;
    }

    public void GameResume()
    {
        Time.timeScale = 1f;
        GameplayUI.SetActive(true);
        PuaseMenuUI.SetActive(false);
    }
}
