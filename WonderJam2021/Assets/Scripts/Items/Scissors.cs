using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;


public class Scissors : MonoBehaviour
{
    public PlayableDirector director;       // cutscene timeline

    private bool endCinematicRun = false;




    public void OnTriggerEnter2D(Collider2D other)
    {
        if (!endCinematicRun)
        {
            endCinematicRun = true;

            StopPlayerMovement(other);
            PlayEndCinematic();
            
        }
    }

    private void StopPlayerMovement(Collider2D other)
    {
        PlayerMovement playerMovement = other.gameObject.GetComponent<PlayerMovement>();
        if (playerMovement)
        {
            playerMovement.CanPlay = false;
        }
        else
        {
            Debug.Log("No Player Detected");
        }

        Destroy(other.gameObject.GetComponent<Player>().Ghost);
        Destroy(other.gameObject.GetComponent<Player>().Rope);

        Destroy(other.gameObject);
    }

    private void PlayEndCinematic()
    {
        director.Play();
    }
}
