using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndTrigger : MonoBehaviour
{
    public GameObject player;
    bool isplayerEscape ;
    bool isplayerCaught;
    public CanvasGroup EscapeUI;
    public CanvasGroup GetCaughtUI;
    float timer;
    float fadeDuration = 1f;
    public AudioSource EscapeAudio;
    public AudioSource CaughtAudio;
    bool hasAudioPlay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isplayerEscape)
        {
            EndGame(EscapeUI , false ,EscapeAudio );
        }
        else if (isplayerCaught)
        { 
            EndGame(GetCaughtUI , true ,CaughtAudio);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            isplayerEscape = true;
        }
    }
    public void CaughtPlayer()
    {
        isplayerCaught = true;
    }

    void EndGame(CanvasGroup ui, bool restart,AudioSource audio)
    {
            if (!hasAudioPlay)
            {
                audio.Play();
                hasAudioPlay = true;
            }


            timer += Time.deltaTime;
            ui.alpha = timer / fadeDuration;

            if (timer > fadeDuration + 1f)
            {
                if (restart)
                {
                    SceneManager.LoadScene(0);
                }
                else 
                {
                    Application.Quit();
                }
                
            }
        
    }
}
