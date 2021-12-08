using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    // Start is called before the first frame update
    // private GUIStyle font = new GUIStyle(); 
    // public GameObject Score;
    public bool gameEnded = false;
    void Start()
    {
        // Score update = Score.GetComponent<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        gameEnded = GameObject.Find("Basic_Bandit").GetComponent<PlayerController>().gameOver;
        if(gameEnded == true) {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet")) {
            GameObject.Find("Score").GetComponent<Score>().updateScore();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
    // void OnGUI() {
    //     // font.fontSize = 50;
    //     GUI.Label(new Rect(10, Screen.height - 45, 100, 20), "Score: " + score.ToString("0"));
    // }
}
