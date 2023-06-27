using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreenStudios : MonoBehaviour
{
    public Animator start;
    public void Start()
    {
        StartCoroutine(StartAnim());
    }

    IEnumerator StartAnim()
    {
        yield return new WaitForSeconds(4);
        start.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("SpashScreen");

    }
}
