using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSc : MonoBehaviour
{

    public GameObject otherPlayer;
    private string[] skills;
    private bool hasSkill;
    private string skill;
    private bool setSkillActive;
    private Rigidbody otherPlayerRb;
    private AudioSource source;
    private GameObject skillAnimation;

    [SerializeField]
    private AudioClip soundEffect;

    void Start()
    {
        hasSkill = false;
        setSkillActive = true;
        otherPlayerRb = otherPlayer.GetComponent<Rigidbody>();
        skills = new string[2] {"RandomForce", "Jump"};
        source = GetComponent<AudioSource>();
        skillAnimation = transform.Find("Skill").gameObject;
    }

    void Update(){
        if(!hasSkill && setSkillActive){
            SetSkill();
            skillAnimation.SetActive(true);
            StartCoroutine(Duration());
        }
    }

    void FixedUpdate()
    {
        if((gameObject.name == "P1" && Input.GetAxisRaw("P1Skill") == 1 || gameObject.name == "P2" && Input.GetAxisRaw("P2Skill") == 1) && hasSkill){
            source.clip = soundEffect;
            source.loop = false;
            switch(skill){
                case "RandomForce":
                    RandomForce();
                    source.Play();
                    break;
                case "Jump": 
                    Jump();
                    source.Play();
                    break;
            }
            hasSkill = false;
            skillAnimation.SetActive(false);
        }
    }

    void RandomForce(){
        float random = Random.Range(600f, 900f);
        float randomSign = Random.Range(-1, 1);
        otherPlayerRb.AddForce(new Vector3(randomSign * random, random, random));
    }

    void Jump(){
        otherPlayerRb.AddForce(otherPlayer.transform.up * Random.Range(600f, 900f));
    }

    IEnumerator Duration(){
        setSkillActive = false;
        yield return new WaitForSeconds(10f);
        setSkillActive = true;
    }

   void SetSkill(){
        int random = Random.Range(0, 2);
        skill = skills[random];
        hasSkill = true;
    }
}
