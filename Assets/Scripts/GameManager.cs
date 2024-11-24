using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public Toggle easy;
    public Toggle normal;
    public Toggle hard;
    
    [Header("Settings")]
    public Button settings;
    public GameObject settingsTab;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);            
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    

    void Start()
    {
        settings.onClick.AddListener(OpenSettings);
        
        string savedDifficulty = PlayerPrefs.GetString("Difficulty", "Normal");
        SetInitialToggle(savedDifficulty);
        easy.onValueChanged.AddListener(delegate { OnToggleChanged(easy, "Easy"); });
        normal.onValueChanged.AddListener(delegate { OnToggleChanged(normal, "Normal"); });
        hard.onValueChanged.AddListener(delegate { OnToggleChanged(hard, "Hard"); });
    }

    void OpenSettings()
    {
        if (!settingsTab.activeSelf)
        {
            settingsTab.SetActive(true);
        }
        else
        {
            settingsTab.SetActive(false);
        }
    }
    
    void SetInitialToggle(string difficulty)
    {
        if (difficulty == "Easy")
            easy.isOn = true;
        else if (difficulty == "Normal")
            normal.isOn = true;
        else if (difficulty == "Hard")
            hard.isOn = true;
    }

    void OnToggleChanged(Toggle toggle, string difficulty)
    {
        if (toggle.isOn)
        {
            PlayerPrefs.SetString("Difficulty", difficulty);
            PlayerPrefs.Save();
        }
    }

    public void StartGame()
    {
        Debug.Log("Loading.....");
        SceneManager.LoadScene(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}