using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public bool countDownDone = false;
    public float timer;
    public GameObject LogFire;
    public GameObject Countdown;
    public GameObject Fail;
    public GameObject Win;
    public GameObject MatchFlame;
    public GameObject MatchLit;
    public GameObject MatchUnlit;
    public float maxTime = 10;
    public float minTime = 7;
    public float speed;


    public AudioClip LitV;
    public AudioClip LitM;
    public AudioClip LitL;
    public AudioClip CountSound;
    public AudioClip MainMusic;
    public AudioClip WinSound;
    public AudioClip FailSound;
    public AudioSource audioSource;
    public AudioSource audioSource2;
    public AudioSource audioSource3;
    public AudioSource audioSource4;
    public AudioSource audioSource5;
    public AudioSource audioSource6;
    public AudioSource audioSource7;
    public Rigidbody2D rb;

    private float spawnTime;
    private float delay = 1;
    private float win = 1;
    private float fail = 1;

    public int CountWait = 1;
    bool keepPlaying = true;

    void Awake()
    {
        StartCoroutine(delayStart());
    }

        IEnumerator delayStart()
        {
            yield return new WaitForSeconds(delay);
            MatchFlame.SetActive(true);
            MatchLit.SetActive(true);
            MatchUnlit.SetActive(false);
            audioSource.PlayOneShot(LitM);
            audioSource5.PlayOneShot(MainMusic);
    }
    void Start()
    {
        spawnTime = Random.Range(minTime, maxTime); ;
        timer = 0;
        StartCoroutine(SoundOut());
        audioSource2 = GetComponent<AudioSource>();
    }
    IEnumerator SoundOut()
    {
        while (keepPlaying)
        {
            audioSource2.PlayOneShot(CountSound, 1);
            Debug.Log("Count Horn");
            yield return new WaitForSeconds(CountWait);
        }
    }
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        rb.AddForce(movement * speed);
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (timer >= spawnTime)
        {
            if (collision.gameObject.tag == "Log")
            {
                audioSource4.PlayOneShot(LitV);
                timer = 0;
                Instantiate(LogFire);
                Countdown.SetActive(false);
                Win.SetActive(true);
                audioSource3.Stop();
                keepPlaying = false;
                audioSource5.Stop();
                audioSource6.PlayOneShot(WinSound);
                //GameLoader.AddScore(10);
                //StartCoroutine(ByeAfterDelay(2));

            }
            //IEnumerator ByeAfterDelay(float time)
            {
                //yield return new WaitForSeconds(time);
                //GameLoader.gameOn = false;
            }
        }
        if (timer >= spawnTime)
        {
            if (collision.gameObject.tag == "Fail")
            {
                audioSource7.PlayOneShot(FailSound);
                timer = 0;
                Countdown.SetActive(false);
                Fail.SetActive(true);
                audioSource2.Stop();
                keepPlaying = false;
                audioSource5.Stop();
                //StartCoroutine(ByeAfterDelay(2));

            }
            //IEnumerator ByeAfterDelay(float time)
            {
                //yield return new WaitForSeconds(time);
                //GameLoader.gameOn = false;
            }
        }
        
    }
}
       
        
    


 
