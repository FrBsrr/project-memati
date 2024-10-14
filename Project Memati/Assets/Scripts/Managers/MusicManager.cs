using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    [Range(0f,1f)]
    public float volume = 1;
    [Range(-3f, 3f)]
    public float pitch = 1;
    public bool isLoop = false;
}
public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;

    [SerializeField] private SoundEffect soundEffectPrefab;
    public bool isMuted;

    //Bunlar� �nceden unity edit�r� �zerinden veriyoruz. M�zikler ve ses efektleri olarak
    public Sound[] musics;
    public Sound[] sounds;

    public AudioSource source;
    public void Init()
    {
        instance = this;
        source.mute = isMuted;
        //StartCoroutine(PlayMainTheme());
        //PlayMusic("2");
    }

    //Bu fonksiyon musics array'indeki m�zikleri s�rayla �alar. Bitince ba�tan ba�lar.
    public IEnumerator PlayMainTheme()
    {
        foreach (var t in musics)
        {
            PlayMusic(t.name);
            yield return new WaitForSeconds(t.clip.length);
        }

        StartCoroutine(PlayMainTheme());
    }
    //Bu fonksiyon ismi verilen m�zi�i musics array'inde arar ve �alar.
    public void PlayMusic(string name)
    {
        Sound sound = null;
        foreach (var item in musics)
        {
            if(name == item.name)
                sound = item;
        }

        if(sound == null)
        {
            Debug.LogError("Sound not found --> " +  name);
            return;
        }
        source.Stop();

        source.volume = sound.volume;
        source.pitch = sound.pitch;
        source.loop = sound.isLoop;
        source.clip = sound.clip;

        source.Play();
    }

    //Bu fonksiyon ismi verilen ses efektini, sounds array'inde arar ve �alar.
    public void PlaySound(string name)
    {
        Sound sound = null;
        foreach (var item in sounds)
        {
            if (name == item.name)
                sound = item;
        }

        if (sound == null)
        {
            Debug.LogError("Sound not found --> " + name);
            return;
        }

        SoundEffect soundeffect = Instantiate(soundEffectPrefab,gameObject.transform);
        soundeffect.time = sound.clip.length;
        soundeffect.source.volume = sound.volume;
        soundeffect.source.pitch = sound.pitch;
        soundeffect.source.loop = sound.isLoop;
        soundeffect.source.clip = sound.clip;

        soundeffect.source.Play();
    }

    //�stteki fonksiyonun direkt olarak sound verilmi� override'�. Belki bir noktada kullan�labilir laz�m olursa diye var.
    public void PlaySound(Sound sound)
    {
        Debug.Log("Playing : " + sound.clip.name);
        SoundEffect soundeffect = Instantiate(soundEffectPrefab, gameObject.transform);
        soundeffect.time = sound.clip.length;
        soundeffect.source.volume = sound.volume;
        soundeffect.source.pitch = sound.pitch;
        soundeffect.source.loop = sound.isLoop;
        soundeffect.source.clip = sound.clip;

        soundeffect.source.Play();
    }
}
