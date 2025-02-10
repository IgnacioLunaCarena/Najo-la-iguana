using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class LandingController : MonoBehaviour
{
    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private GameObject confirmQuitMenu;
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Texture2D cursorArrow;

    private void Start()
    {
        Cursor.SetCursor(cursorArrow, Vector2.zero, CursorMode.ForceSoftware);
    }

    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Options()
    {
        optionsMenu.SetActive(true);
    }

    public void Quit()
    {
        confirmQuitMenu.SetActive(true);
    }

    public void ConfirmQuit()
    {
        Application.Quit();
    }

    public void CancelConfirm()
    {
        confirmQuitMenu.SetActive(false);
    }

    public void QuitOptionMenu()
    {
        optionsMenu.SetActive(false);
    }

    public void Volume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    public void LowQualityToggle(bool toggle)
    {
         QualitySettings.SetQualityLevel(0);
    }

    public void MediumQualityToggle(bool toggle)
    {
         QualitySettings.SetQualityLevel(1);
    }

    public void HighQualityToggle(bool toggle)
    {
         QualitySettings.SetQualityLevel(2);
    }
}
