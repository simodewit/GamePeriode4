using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
    public TMP_Text text;
    public AudioSource buttonClickSound;

    public void Start()
    {
        AudioListener.volume = 0.1f;
    }

    public void Update()
    {
        if (!Input.anyKey)
            return;

        buttonClickSound.Play();
        StartCoroutine("Loading");
    }

    public IEnumerator Loading()
    {
        yield return new WaitForSeconds(0.5f);
        text.text = "Loading.";
        yield return new WaitForSeconds(0.5f);
        text.text = "Loading..";
        yield return new WaitForSeconds(0.5f);
        text.text = "Loading...";
        yield return new WaitForSeconds(0.5f);
        text.text = "Loading.";
        yield return new WaitForSeconds(0.5f);
        text.text = "Loading..";
        yield return new WaitForSeconds(0.5f);
        text.text = "Loading...";
        yield return new WaitForSeconds(0.1f);

        SceneManager.LoadScene("MainMenu");
        //connects to server
    }
}
