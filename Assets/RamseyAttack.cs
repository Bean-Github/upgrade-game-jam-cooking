using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class RamseyAttack : MonoBehaviour
{
    // Start is called before the first frame update
    private RamseyMovement movem;
    private GameObject player;
    public float nextMove;
    public float moveCD;
    public enum Attack {
        SwearVolley,
        IdiotSandwich,
    }
    public Attack currMove;

    //Swear Volley
    public float volleyCD;
     public float nextVolleyAttack;
    public float volleyDur;
    public float volleyStart;
    public float inaccuracy;
    public GameObject projectile;
    
    public GameObject idiotSandwhich;
    void Start()
    {
        movem = this.gameObject.GetComponent<RamseyMovement>();
        player = GameObject.FindGameObjectWithTag("Player");
        currMove = Attack.SwearVolley;
    }

    // Update is called once per frame
    void Update()
    {
        if (!movem.jumping && Time.time > nextMove) {
            currMove = (Attack)Random.Range(0,2);
            if (currMove == Attack.SwearVolley) {
                volleyStart = Time.time;
            } else if (currMove == Attack.IdiotSandwich) {
                Instantiate(idiotSandwhich);
            }
            nextMove = Time.time + Random.Range(moveCD-2, moveCD+2);
        }
        if (Time.time < volleyStart + volleyDur && Time.time > nextVolleyAttack) {
            UnityEngine.Vector3 var = new UnityEngine.Vector3(Random.Range(-1 * inaccuracy, inaccuracy), Random.Range(-1 * inaccuracy,inaccuracy), 0f);
            UnityEngine.Vector3 diff = player.transform.position + var - this.transform.position;
            diff.Normalize();
            float rot = Mathf.Atan(diff.y/diff.x) * Mathf.Rad2Deg;
            GameObject proj = Instantiate(projectile, new UnityEngine.Vector3(this.transform.position.x + diff.x, this.transform.position.y + diff.y, 0), 
                UnityEngine.Quaternion.Euler(0,0,rot));
            proj.transform.GetChild(0).GetComponent<SwearProjectile>().dir = diff;
            nextVolleyAttack = Time.time + volleyCD;
        }
    }
}
