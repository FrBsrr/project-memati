using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SahneManager : MonoBehaviour
{
    public static SahneManager instance;

    public void Init()
    {
        instance = this;

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    //Sahne y�klendi�i an bu fonksiyon otomatik olarak �a��r�l�r. Sahne y�klenince bir �eyler yap�lmas�n� istiyorsan�z bunun i�ine yaz�n.
    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        
    }

    //�smi verilen sahneyi y�kler
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}
