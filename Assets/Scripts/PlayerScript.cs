using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour, IDamageable
{
    public float health = 1000;
    public float max_health = 1000;

    public Text HP;
    public Slider HPslider;
    public GameObject FillColorArea;

    void Start()
    {
        HP.text = health.ToString()+" / "+max_health.ToString();
    }

    public void OnDamage(float damageAmount)
    {
        health -= damageAmount;

        HP.text = health.ToString()+" / "+max_health.ToString();
        HPslider.value = health/max_health;

        if(health <= 0)
        {
            gameObject.SetActive(false);
        }
        else if(health <= (max_health/4))
        {
            FillColorArea.GetComponent<Image>().color =  Color.red;
        }
        else if(health <= (max_health/2))
        {
            FillColorArea.GetComponent<Image>().color =  Color.yellow;      
        }
        
    }
}
