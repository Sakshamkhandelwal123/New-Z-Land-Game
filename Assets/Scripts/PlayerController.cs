using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5;
    public float turnspeed = 120;
    public float horizontalInput;
    public float verticalInput;
    private Animator playerAnim;
    public float sensitivity = 10f;
    public GameObject zombie;
    public GameObject projectilePrefab;
    public TMP_Text text;
    public bool gameOver = false;
    private AudioSource playeraudio;
    public AudioClip hitSound;
    public int win;
    void Start()
    {
        playerAnim = GetComponent<Animator>();
        text.text = "";
        playeraudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        if (verticalInput == 0)
        {
            playerAnim.SetBool("Walk", false);
        } else {
            playerAnim.SetBool("Walk", true);
        }
        transform.Translate(Vector3.forward * Time.deltaTime * verticalInput * speed);
        transform.Rotate(Vector3.up * Time.deltaTime * horizontalInput * turnspeed);
        
        var c = Camera.main.transform;
        //  c.Rotate(0, Input.GetAxis("Mouse X")* sensitivity*0.08f, 0);
         c.Rotate(-Input.GetAxis("Mouse Y")* sensitivity * 0.08f, 0, 0);
        //  c.Rotate(0, 0, -Input.GetAxis("QandE")*0.08f * Time.deltaTime);
         if (Input.GetMouseButtonDown(0))
             Cursor.lockState = CursorLockMode.Locked;
        if(Input.GetKeyDown("left ctrl") || Input.GetMouseButtonDown(0)) {
            Instantiate(projectilePrefab, transform.position + new Vector3(0,2,-0.5f), transform.rotation);
        }
        win = GameObject.Find("Score").GetComponent<Score>().score;
        if(win >= 30) {
            gameOver = true;
            text.text = "Winner";
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("zombie")) {
            speed = speed - speed * 0.1f;
            if(speed < 0.1) {
                gameOver = true;
                text.text = "GAME OVER";
                playeraudio.Pause();
            }
        }
        if(collision.gameObject.CompareTag("PowerUp")) {
            playeraudio.PlayOneShot(hitSound, 1.0f);
            speed = speed + speed * 0.2f;
            Destroy(collision.gameObject);
            if(speed > 5) {
                speed = 5;
            }
        }
    }
}