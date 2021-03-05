using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    public Button playButton;
    public InputField usernameInput;

    public Text nameAlert;

     private void Start() {
        
		Button btn = playButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
        nameAlert.GetComponent<Text>().enabled = false;
     }

    void TaskOnClick(){

        if(usernameInput.text != ""){
            // StartCoroutine(GameMaster.instance.log.RegisterUser(usernameInput.text));
            // nameAlert.GetComponent<Text>().text = GameMaster.instance.log.registerUserMessage; 

            // if(nameAlert.GetComponent<Text>().text == "Cadastro realizado com sucesso!"){ //Aqui é o echo do registerUser.php

                PlayerPrefs.SetString("playersName", usernameInput.text);
                PlayerPrefs.SetInt("level", SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            // }
            
        }
        else {
            
            nameAlert.GetComponent<Text>().enabled = true;
            
        }
	}


}
