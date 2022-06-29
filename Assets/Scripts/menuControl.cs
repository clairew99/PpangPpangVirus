using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuControl : MonoBehaviour
{
   public void Startbn1()
   {
       SceneManager.LoadScene("Stage1");
   }

   public void Startbn2()
   {
       SceneManager.LoadScene("Stage2");
   }

   public void Startbn3()
   {
       SceneManager.LoadScene("Stage3");
   }
   public void GotoStart()
   {
       SceneManager.LoadScene("main");
   }
}
