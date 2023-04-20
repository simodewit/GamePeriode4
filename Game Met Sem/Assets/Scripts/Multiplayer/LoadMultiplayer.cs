using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using TMPro;

public class LoadMultiplayer : MonoBehaviourPunCallbacks
{
    public TMP_Text loading;
    public bool check;
    public MusicManager manager;

    private void Update()
    {
     
       if(check == false)
        {
            
            if (Input.anyKey)
            {
                StartCoroutine(LoadingThis());
                check = true;
                manager.SoundEffect();
            }
        }
        
            
    }

    public override void OnConnectedToMaster()
    {
        SceneManager.LoadScene("MainMenu"); 
    }

    public IEnumerator LoadingThis()
    {
        yield return new WaitForSeconds(0.5f);
        loading.text = "Loading.";
        yield return new WaitForSeconds(0.5f);
        loading.text = "Loading..";
        yield return new WaitForSeconds(0.5f);
        loading.text = "Loading...";
        yield return new WaitForSeconds(0.5f);
        loading.text = "Loading.";
        yield return new WaitForSeconds(0.5f);
        loading.text = "Loading..";
        yield return new WaitForSeconds(0.5f);
        loading.text = "Loading...";
        yield return new WaitForSeconds(0.1f);
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.JoinLobby();
       
    }
    

 
}
