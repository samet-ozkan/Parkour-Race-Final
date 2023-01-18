using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoresSc : MonoBehaviour
{

    public static ScoresSc instance;

    [SerializeField]
    private int p1Score = 0;

    [SerializeField]
    private int p2Score = 0;

    [SerializeField]
    TextMeshProUGUI p1ScoreText;

    [SerializeField]
    TextMeshProUGUI p2ScoreText;

    void Start(){
        GetCurrentScores();
    }

    public void GetCurrentScores(){
        if(PlayerPrefs.HasKey("P1Score") && PlayerPrefs.HasKey("P2Score")){
            p1Score = PlayerPrefs.GetInt("P1Score");
            p2Score = PlayerPrefs.GetInt("P2Score");
        }
        else{
            PlayerPrefs.SetInt("P1Score", 0);
            PlayerPrefs.SetInt("P2Score", 0);
            p1Score = 0;
            p2Score = 0;
        }
        UpdateText();
    }

    private void UpdateText(){
        p1ScoreText.text = p1Score.ToString();
        p2ScoreText.text = p2Score.ToString();
    }

    void Awake(){
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(this);
        }
        else{
            Destroy(this.gameObject);
        }
    }

    public void increaseP1Score(){
        p1Score++;
        PlayerPrefs.SetInt("P1Score", p1Score);
        UpdateText();
    }

    public void increaseP2Score(){
        p2Score++;
        PlayerPrefs.SetInt("P2Score", p2Score);
        UpdateText();
    }

    public int getP1Score(){
        return p1Score;
    }

    public int getP2Score(){
        return p2Score;
    }
}
