using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource[] audioSource;
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void PlayHeroHit()
    {
        //1
        audioSource[1].Play();
    }
    public void PlayThunder()
    {
        //5
        audioSource[5].Play();
    }
    public void PlayEnnemyHit()
    {
        //3
        audioSource[3].Play();
    }
    public void PlayVoice1()
    {
        //0
        audioSource[0].Play();
    }
    public void PlayVoice2()
    {
        //8
        audioSource[8].Play();
    }
    public void PlayVoice3()
    {
        //9
        audioSource[9].Play();
    }
    public void PlayPotionSound()
    {
        //6
        audioSource[6].Play();
    }
    public void PlayPhantomSound()
    {
        //2
        audioSource[2].PlayDelayed(-3f);
    }
    public void PlayFireballSound()
    {
        //7
        audioSource[7].Play();
    }
    public void PlayDeathSound()
    {
        //4
        audioSource[4].Play();
    }
    public void PlayOpenChestSound()
    {
        audioSource[10].Play();
    }
    public void PlayBagSound()
    {
        audioSource[11].Play();
    }
    public void PlayDenieSound()
    {
        audioSource[12].Play();
    }
}
