using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    public int score = 0;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void updateScore() {
        score = score + 1;
    }
    void OnGUI() {
        // font.fontSize = 50;
        GUI.Label(new Rect(10, Screen.height - 60, 150, 40), "Score: " + score);
    }
}
