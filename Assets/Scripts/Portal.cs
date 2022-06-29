using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
  public string transferMapName;
  
  // Start is called before the first frame update
  void Start()
  {
  
  }
  private void OnTriggerEnter(Collider collision)
  {
    if(collision.CompareTag("Gun"))
    {
      //thePlayer.currentMapName = transferMapName;
      SceneManager.LoadScene(transferMapName);
    }
  }
}