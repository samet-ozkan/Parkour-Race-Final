using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSc : MonoBehaviour
{
    public GameObject player1Win;
    public GameObject player2Win;
    public GameObject draft;
    private int buildIndex;
    private GameObject scores;
    private ScoresSc scoresSc;
    public bool finished = false;

    void Start(){
        buildIndex = SceneManager.GetActiveScene().buildIndex;
        player1Win.SetActive(false);
        player2Win.SetActive(false);
        draft.SetActive(false);
        scores = GameObject.Find("Scores");
        scoresSc = scores.GetComponent<ScoresSc>();
        scoresSc.GetCurrentScores();
    }

    public void P1Win(){
        scoresSc.increaseP1Score();
        if(buildIndex + 1 != SceneManager.sceneCountInBuildSettings){
            StartCoroutine(GoNextLevel());
        }
        else{
            WinScreen();
            //player1Win.SetActive(true);
        }
    }

    public void P2Win(){
        scoresSc.increaseP2Score();
        if(buildIndex + 1 != SceneManager.sceneCountInBuildSettings){
            StartCoroutine(GoNextLevel());
        }
        else{
            WinScreen();
            //player2Win.SetActive(true);
        }
    }

    public void WinScreen(){
        if(!finished){
            int p1Score = scoresSc.getP1Score();
            int p2Score = scoresSc.getP2Score();
            if(p1Score > p2Score){
                player1Win.SetActive(true);
            }
            else if(p2Score > p1Score){
                player2Win.SetActive(true);
            }
            else{
            draft.SetActive(true);
            }
            PlayerPrefs.DeleteAll();
            PlayerPrefs.DeleteKey("LoadedScene");
            StartCoroutine(GoMainMenu());
        }
        finished = true;
    }

    IEnumerator GoNextLevel(){
        AsyncOperation nextLevel = SceneManager.LoadSceneAsync(++buildIndex);

        while(!nextLevel.isDone){
            yield return null;
        }
    }

     IEnumerator GoMainMenu() {
        yield return new WaitForSeconds(3f);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("MainMenu");

        while(!asyncLoad.isDone) {
            yield return null;
        }
    } 
}
