using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class VolumeController : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider volumeSlider;
    public TextMeshProUGUI percentageText; // Text yerine TextMeshProUGUI kullan�yorsan�z

    void Start()
    {
        // Slider'�n ba�lang�� de�erini 100 olarak ayarlay�n
        int volume = PlayerPrefs.GetInt("Volume", 100);
        volumeSlider.value = volume;
        SetVolume(volume);
        UpdatePercentageText(volume);
    }

    public void SetVolume(float sliderValue)
    {
        // Slider de�erini 0 ile 1 aras�na d�n��t�r�n
        float volume = sliderValue / 100f;
        audioMixer.SetFloat("Volume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetInt("Volume", (int)sliderValue);
        UpdatePercentageText((int)sliderValue);
    }

    private void UpdatePercentageText(int sliderValue)
    {
        percentageText.text = sliderValue.ToString() + "%";
    }
}