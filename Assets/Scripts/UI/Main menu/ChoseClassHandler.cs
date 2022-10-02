using UnityEngine;
using UnityEngine.SceneManagement;

public class ChoseClassHandler : MonoBehaviour
{
    private const string KeySaveName = "HeroClassId";

    public void OnMageButtonClick()
    {
        PlayerPrefs.SetInt(KeySaveName, 1);
        LoadLevel();
    }

    public void OnWariorButtonClick()
    {
        PlayerPrefs.SetInt(KeySaveName, 0);
        LoadLevel();
    }

    private void LoadLevel()
    {
        SceneManager.LoadScene(1);
    }
}
