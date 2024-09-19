using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController instance;


    [SerializeField] private AudioSource bgAudio;// Fonte de audio das musicas
    [SerializeField] private AudioSource sfxAudio;// Fonte de audio dos sfx

    [SerializeField] private AudioClip[] bgMusicas;// Array com todas as musicas
    [SerializeField] private AudioClip[] sfxClips;// Array com todos os clips sfx

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }


    public void TocarBgMusic(int idBgMusic) //Toca a musica e para outras musicas tocando antes
    {
        AudioClip clip = bgMusicas[idBgMusic];
        bgAudio.Stop();
        bgAudio.clip = clip;
        bgAudio.loop = true;
        bgAudio.Play();
    }


    public void TocarSFX(int idSFX) //Toca os sfx
    {
        AudioClip clip = sfxClips[idSFX];

        switch (idSFX) // Possibilita alterar o volume de acordo com o clip
        {
            case 0:
                sfxAudio.volume = 1f;
                break;
            case 1:
                sfxAudio.volume = 1f;
                break;
            case 2:
                sfxAudio.volume = 1f;
                break;
            case 3:
                sfxAudio.volume = 1f;
                break;
        }
        sfxAudio.PlayOneShot(clip);
    }
}
