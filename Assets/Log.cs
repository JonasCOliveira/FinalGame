using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Log : MonoBehaviour
{

    public GameHandler gh = new GameHandler();

    public  string registerUserMessage;
    public  string registerLogMessage;

    private void Awake() {

        gh = FindObjectOfType<GameHandler>();
    }


    // Start is called before the first frame update
    void Start()
    {
       
    }

    public IEnumerator RegisterUser(string player){
        
        WWWForm nameForm = new WWWForm();
        nameForm.AddField("nickname", player);

        using (UnityWebRequest request = UnityWebRequest.Post("https://roozadventure.000webhostapp.com/registerUser.php",nameForm)){
            yield return request.SendWebRequest();
        
        if (request.isNetworkError || request.isHttpError){

                registerUserMessage = request.error;
                Debug.Log( "Error: " + request.error );
            } else {
                registerUserMessage = request.downloadHandler.text;
                Debug.Log(request.downloadHandler.text);
            }
        
        }
    }

    public IEnumerator RegisterLog(string playerName, int level)
    {
   
       
        // Create a form object 
        WWWForm form = new WWWForm();
        form.AddField("Jogador", playerName );
        form.AddField("Fase", level);
        form.AddField("Fitness", gh.getFitness().ToString());
        form.AddField("Score", gh.getScoreFunction().ToString());
        form.AddField("DiamantesColetados", GameHandler.numberOfColectedCoins);
        form.AddField("DiamantesVistos", GameHandler.numberOfTotalCoins);
        form.AddField("VidasColetadas",GameHandler.numberOfBonusLife);
        form.AddField("VidasRestantes",GameHandler.numberOfRemainingLife);
        form.AddField("qtdAguia", 1);
        form.AddField("qtdEspinho",11);
        form.AddField("qtdGamba",21);
        form.AddField("qtdSapo",31);


        using (UnityWebRequest request = UnityWebRequest.Post("https://roozadventure.000webhostapp.com/registerUser.php",form)){
            yield return request.SendWebRequest();
        
        if (request.isNetworkError || request.isHttpError){
                registerLogMessage = request.error;
                Debug.Log( "Error: " + request.error );
            } else {
                registerLogMessage = request.downloadHandler.text;
                Debug.Log(request.downloadHandler.text);
            }
        
        }
    }

    }

