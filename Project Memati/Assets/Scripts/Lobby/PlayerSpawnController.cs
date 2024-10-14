using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    public GameObject[] playerControls; // Boru alt�ndaki buton gruplar�
    public Button addButton; // ADD PLAYER butonu
    public Button removeButton; // REMOVE PLAYER butonu

    private int currentPlayerIndex = 0;

    void Start()
    {
        // Ba�lang��ta sadece ilk oyuncunun butonlar�n� aktif yap
        for (int i = 0; i < playerControls.Length; i++)
        {
            playerControls[i].SetActive(i == 0);
        }

        // ADD PLAYER butonuna t�klama olay�n� ba�la
        addButton.onClick.AddListener(AddPlayer);
        // REMOVE PLAYER butonuna t�klama olay�n� ba�la
        removeButton.onClick.AddListener(RemovePlayer);
    }

    void AddPlayer()
    {
        // Sonraki oyuncunun butonlar�n� aktif yap
        if (currentPlayerIndex < playerControls.Length - 1)
        {
            currentPlayerIndex++;
            playerControls[currentPlayerIndex].SetActive(true);
        }
    }

    void RemovePlayer()
    {
        // Mevcut oyuncunun butonlar�n� gizle
        if (currentPlayerIndex > 0)
        {
            playerControls[currentPlayerIndex].SetActive(false);
            currentPlayerIndex--;
        }
    }
}