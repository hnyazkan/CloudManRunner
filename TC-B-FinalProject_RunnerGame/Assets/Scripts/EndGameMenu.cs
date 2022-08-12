using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameMenu : MonoBehaviour
{
    public GameObject WinMenu;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {

            

            
            WinMenu.SetActive(true);
            


        }
    }

    
}

    
