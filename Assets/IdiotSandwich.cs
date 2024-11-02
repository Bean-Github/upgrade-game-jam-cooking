using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class IdiotSandwich : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;
    public Animator anim;
    public float fallSpeed; 
    public float attackStartTime;
    public bool attacking;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        this.transform.position = new Vector3 (player.transform.position.x, 20f, 0f);
        attacking = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!attacking && this.transform.position.y > player.transform.position.y) {
            this.transform.Translate(new Vector3(0,-1,0) * Time.deltaTime * fallSpeed);
        } else if (!attacking) {
            anim.SetBool("attack", true);
            attackStartTime = Time.time;
            attacking = true;
        }
        if (attacking && Time.time > attackStartTime + 0.75f) {
            //print("end");
            Destroy(this.gameObject);
        }
    }

    
}
