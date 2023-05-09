using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreen1 : MonoBehaviour
{
    public GameObject background;

    public void Update()
    {
        if(!Input.anyKey)
            return;

        background.SetActive(false);

        //loading screen
    }
}
