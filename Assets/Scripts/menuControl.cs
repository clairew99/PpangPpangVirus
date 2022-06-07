using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuControl : MonoBehaviour
{

   public void Startbn1()
   {
       if(Input.GetButton("Fire1"))
       {
           SceneManager.LoadScene("character");
       }
       
       //SceneManager.LoadScene("character");
   }

   public void Startbn2()
   {
       SceneManager.LoadScene("Stage2");
   }

   public void Startbn3()
   {
       SceneManager.LoadScene("Stage3");
   }
}
