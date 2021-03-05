using System;
using System.Security.AccessControl;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class NextLevel : MonoBehaviour
{

    public float transitionTime = .1f;

    public GameHandler gh;
    public GameObject canvasForms;

    private string player;
	private int level; 

    private void Awake()
    {
        gh = FindObjectOfType<GameHandler>();
    }
    void OnTriggerEnter2D(Collider2D trig){

         if(trig.CompareTag("Player")){
            //  Debug.Log("Bateu na casa");
             LoadNextLevel();
             canvasForms.SetActive(true);
        }
    }

    public void LoadNextLevel(){

        gh.CalculatePlayerFitnessByScore();
        
        player  =  PlayerPrefs.GetString("playersName");
		level = PlayerPrefs.GetInt("level");
        level++;

        StartCoroutine(GameMaster.instance.log.RegisterLog(player, level));
        PlayerPrefs.SetInt("level", level);
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
        
        GameMaster.instance.AttHud();
    }

     IEnumerator  LoadLevel(int levelIndex){

       //Calcular o score

        yield return new WaitForSeconds(transitionTime);
        GameMaster.instance.ResetNumOfHearts();
        GameMaster.instance.ResetNumOfPoints();
        GameMaster.instance.ResetNumOfBullets();

        GameMaster.instance.SetNumOfHearts(5);
        GameMaster.instance.SetNumOfPoints(0);
        GameMaster.instance.SetNumOfBullets(10);

        SceneManager.LoadScene(levelIndex);
        

    }


}
