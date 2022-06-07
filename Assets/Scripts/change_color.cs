using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class change_color : MonoBehaviour
{
    [SerializeField]
    private GameObject Robot;
    private Renderer robotRenderer;
    private Color newColor;

    private float randomChannel1, randomChannel2, randomChannel3;
    void Start()
    {
        robotRenderer=Robot.GetComponent<Renderer>();
        gameObject.GetComponent<Button>().onClick.AddListener(ChangeColor);
    }

    // Update is called once per frame
    private void ChangeColor()
    {
        randomChannel1=Random.Range(0,1f);
        randomChannel2=Random.Range(0,1f);
        randomChannel3=Random.Range(0,1f);
        newColor=new Color(randomChannel1,randomChannel2,randomChannel3,1f);
        robotRenderer.material.SetColor("_Color",newColor);
    }
}
