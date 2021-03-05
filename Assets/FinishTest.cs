using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTest : MonoBehaviour
{
    public GameObject canvasForms;

    public void QuitGame(){

        Debug.Log("Quit");
        Application.Quit();
    }

    public void OpenURL(){

        Application.OpenURL("https://forms.gle/ULX93VG3GvamB3ZZA");

    }

    public void OpenCanvasFinishTest(){

        canvasForms.SetActive(true);


    }

}
