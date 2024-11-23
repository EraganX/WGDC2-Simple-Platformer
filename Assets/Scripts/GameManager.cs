using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; 
    private int collectedGifts = 0; 

    private UiManager uiManager;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CollectGift()
    {
        collectedGifts++;
        if (uiManager != null)
        {
            uiManager.UpdateGiftCount(collectedGifts);
        }
    }

    public int GetCollectedGifts()
    {
        return collectedGifts;
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }


    public void GoToLevel1()
    {
        SceneManager.LoadScene("Level_01");
    }


    public void GoToLevel2()
    {
        SceneManager.LoadScene("Level_02");
    }

    public void RegisterUiManager(UiManager ui)
    {
        uiManager = ui;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
