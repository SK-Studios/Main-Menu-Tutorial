using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    [SerializeField] GameObject mainPanel;
    [SerializeField] GameObject instructionsPanel;
    [SerializeField] GameObject optionsPanel;

    public void GoToMain ()
    {
        mainPanel.SetActive(true);
        instructionsPanel.SetActive(false);
        optionsPanel.SetActive(false);
    }

    public void GoToInstruciotns ()
    {
        mainPanel.SetActive(false);
        instructionsPanel.SetActive(true);
        optionsPanel.SetActive(false);
    }

    public void GoToOptions ()
    {
        mainPanel.SetActive(false);
        instructionsPanel.SetActive(false);
        optionsPanel.SetActive(true);
    }

    public void OnPlayClicked ()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void QuitGame ()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    List<int> widths = new List<int>() {568, 960, 1280, 1920};
    List<int> heights = new List<int>() {329, 540, 800, 1080};

    public void SetScreenSize (int index)
    {
        bool fullscreen = Screen.fullScreen;
        int width = widths[index];
        int height = heights[index];
        Screen.SetResolution(width, height, fullscreen);
    }

    public void SetFullscreen (bool _fullscreen)
    {
        Screen.fullScreen = _fullscreen;
    }

    [SerializeField] Slider volumeSlider;

    private void Awake ()
    {
        if (PlayerPrefs.HasKey("Volume")) {
            SetVolume(PlayerPrefs.GetFloat("Volume"));
            volumeSlider.value = PlayerPrefs.GetFloat("Volume");
        }
    }

    public void SetVolume (float volume)
    {
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat("Volume", volume);
    }
}