using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private int life = 1;
    AudioSource audioData;
    public Text lifeText;
    void Start()
    {
        audioData = GetComponent<AudioSource>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "enemy")
        {
            Debug.Log("hey i'm here");
            audioData.Play();
             Destroy(other.gameObject);
             if(life>0)life -= 1;
             lifeText.text = "" + life;
             
        }
    }
    void FixedUpdate()
    {
        if (life <= 0 && audioData.isPlaying==false)
        {
            SceneManager.LoadScene("Start");
        }
    }
    IEnumerator playSound()
    {
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(6f);
    }
}
