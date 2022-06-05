using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    [SerializeField]
    Slider slider = null;
    [SerializeField]
    private int maxWater;
    int currentHp;
    [SerializeField]
    int water = 1;


    // Start is called before the first frame update
    void Start()
    {
        slider.value = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Rain")
        {
            
            currentHp += water;

            slider.value = (float)currentHp / (float)maxWater;
        }
    }
}
