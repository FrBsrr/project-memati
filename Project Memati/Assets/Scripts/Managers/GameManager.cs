using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //GameManager t�m managerlar� s�rayla �a��ran en �stteki y�neticidir. ��erisinde t�m managerlar bulunur.
    public static GameManager instance;

    [SerializeField] MinigameManager minigameManager;
    [SerializeField] PlayerManager playerManager;
    [SerializeField] SahneManager sahneManager;

    //Oyundaki tek start fonksiyonu buradad�r. Di�er managerlarda Init fonksiyonu bulunur ve burada istenilen s�raya g�re �a��r�l�r.
    private void Start()
    {
        instance = this;

        minigameManager.Init();
        playerManager.Init();
        sahneManager.Init();
    }


}
