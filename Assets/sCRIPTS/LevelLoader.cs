using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{

    public Slider slider;
    public Text progressText;

    public void LoadLevel(int sceneIndex)
    {
        slider.gameObject.SetActive(true);
        StartCoroutine(LoadAsynchronously(sceneIndex));
        FindObjectOfType<SoundManager>().Play("Click");

    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation oparation = SceneManager.LoadSceneAsync(sceneIndex);
        while (!oparation.isDone)
        {
            float progress = Mathf.Clamp01(oparation.progress / 0.9f);
            slider.value = progress;
            progressText.text = progress * 100f + "%";
            yield return null;
        }
    }

    public void LoadError()
    {

        FindObjectOfType<SoundManager>().Play("Error");
    }
}
