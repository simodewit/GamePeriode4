using System.Collections;
using System.Collections.Generic;
using Photon.Pun.Demo.Cockpit.Forms;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;
using Photon.Pun;
using UnityEngine.SceneManagement;

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

        if(slider.value >= 1)
        {
            SceneManager.LoadScene("TestPickUp");
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
