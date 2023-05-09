using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreen1 : MonoBehaviour
{
    #region variables

    public GameObject background;

    #endregion

    #region main code

    public void Update()
    {
        if(!Input.anyKey)
            return;

        background.SetActive(false);

        //loading screen
    }

    #endregion
}
