using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;

public class ConfirmToNextScene : MonoBehaviour
{
    public Slider slider;
    public float speed;
    public bool check;

    public void Update()
    {
        if(check == false)
        {
            slider.value -= Time.deltaTime * speed;
        }

        if(slider)
        {
            print("Nextscene");
        }
    }

    public void OnTriggerStay(Collider other)
    {
        slider.value += Time.deltaTime * speed;
        check = true;
    }

    public void OnTriggerExit(Collider other)
    {
        check = false;
    }
}
