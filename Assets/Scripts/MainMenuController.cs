using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{ 
    public GameObject menu;
    public GameObject loading;
    public Image loadingBar;

    AsyncOperation scenesToLoad = new AsyncOperation();

    private void Awake() {
        DontDestroyOnLoad(this);
    }

    public void PlayGame()
    {
        menu.SetActive(false);
        loading.SetActive(true);
        scenesToLoad = SceneManager.LoadSceneAsync("GameScene");
        StartCoroutine(LoadingScreen());
    }

    IEnumerator LoadingScreen(){

        float progress = 0;

        while(!scenesToLoad.isDone){
            progress += scenesToLoad.progress;
            loadingBar.fillAmount = progress;
            yield return null;
        }
        if(scenesToLoad.isDone){
            Destroy(this.gameObject);
        }
    }
}
