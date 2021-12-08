using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator zombieAnim;
    public GameObject player;
    public float speed = 5.0f;
    public Transform target;
    Rigidbody m_Rigidbody;
    void Start()
    {
        zombieAnim = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = transform.position;
        if(temp.y < 0) {
            transform.position = new Vector3(temp.x, -2.0f, temp.z);
        }
        // transform.position = Vector3.MoveTowards(transform.position, player.transform.position, .03f);
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        float ld = lookDirection.y;
        lookDirection.y = 0;
        
        if (Vector3.Distance(player.transform.position, transform.position) < 1 || Vector3.Distance(transform.position, player.transform.position) < 1)
        {
            // transform.Rotate(0,-ld,0);
            transform.LookAt(target.position);
            zombieAnim.SetBool("run", false);
            zombieAnim.SetBool("attack", true);
        } else {
            transform.Translate(lookDirection*Time.deltaTime*speed);
            // transform.Rotate(0,player.transform.eulerAngles.y,0);
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            transform.LookAt(target.position);
            zombieAnim.SetBool("run", true);
            zombieAnim.SetBool("attack", false);
        }
    }
    
}
