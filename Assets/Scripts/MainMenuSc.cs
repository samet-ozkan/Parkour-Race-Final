using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenuSc : MonoBehaviour
{
    public Button continueGameButton;
    public int loadedSceneNumber;
    
    // Start is called before the first frame update
    void Start()
    {
        bool isLoadedScene = PlayerPrefs.HasKey("LoadedScene");
        if(isLoadedScene) {
            loadedSceneNumber = PlayerPrefs.GetInt("LoadedScene");
            continueGameButton.interactable = true;
        } else {
            continueGameButton.interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NewGame() {
        StartCoroutine(INewGame());
    }

    IEnumerator INewGame() {
        PlayerPrefs.DeleteAll();
        AsyncOperation scene = SceneManager.LoadSceneAsync("GameScene");
        while(!scene.isDone) {
            yield return null;
        }
    }
    
    public void ContinueGame() {
        StartCoroutine(IContinueGame());
    }

    IEnumerator IContinueGame() {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(loadedSceneNumber);

        while(!asyncLoad.isDone) {
            yield return null;
        }
    } 
    
 }