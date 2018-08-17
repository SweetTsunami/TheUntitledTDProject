/*  File:       #SCRIPTNAME#
 *  Creator:    Sweet
 *  Date:       
 *  Location:   Brno, Czech Republic
 *  Project:    
 *  Desc:       
 *  Usage:                  
 */
 
using UnityEngine;

/// <summary>
/// Handles the ingame music
/// </summary>
public class MusicManager : MonoBehaviour
{
    /// <summary>
    /// array of music tracks
    /// </summary>
	public AudioClip[] levelMusicChangeArray;

    private AudioSource audioSource;

    /// <summary>
    /// don't destroy music player after loading new scenes
    /// </summary>
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Debug.Log("Don't destroy on load " + name);
    }

    /// <summary>
    /// gets the audiosource
    /// </summary>
	void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// load clip on level
    /// </summary>
    /// <param name="Level"></param>
	void OnLevelWasLoaded(int Level)
    {
        AudioClip thisLevelMusic = levelMusicChangeArray[Level];
        Debug.Log("playing clip: " + thisLevelMusic);

        if (thisLevelMusic) //if there is a music attached
        {
            audioSource.clip = thisLevelMusic;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    /// <summary>
    /// change the volume (for options)
    /// </summary>
    /// <param name="volume"></param>
	public void ChangeVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
