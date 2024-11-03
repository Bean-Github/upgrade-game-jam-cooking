using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class RamseyAttack : MonoBehaviour
{
    // Start is called before the first frame update
    private RamseyMovement movem;

    public bool aggro;
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
    
    //public float algCD;
    //public float lastAlg;
    //public GameObject algscreen;
    public UnityEngine.Vector3 lastDir;
    public Rigidbody2D rb;
    void Start()
    {
        movem = this.gameObject.GetComponent<RamseyMovement>();
        player = GameObject.FindGameObjectWithTag("Player");
        rb = player.GetComponent<Rigidbody2D>();
        currMove = Attack.SwearVolley;
        aggro = true;
        moveCD = 4f;
        //algCD = Random.Range(25,30);
        //lastAlg = 0;
        //algscreen = GameObject.FindGameObjectWithTag("AllGoodScreen");
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (!algscreen.activeSelf && Time.time > lastAlg + algCD) {
            aggro = false;
            algscreen.SetActive(true);
            lastDir = rb.velocity;
            rb.velocity = new UnityEngine.Vector3(0,0,0);
            player.GetComponent<PlayerMovement>().enabled = false;
            rb.bodyType = RigidbodyType2D.Static;

        }
        */

        if (aggro && !movem.jumping && Time.time > nextMove) {
            currMove = (Attack)Random.Range(0,2);
            if (currMove == Attack.SwearVolley) {
                volleyStart = Time.time;
            } else if (currMove == Attack.IdiotSandwich) {
                Instantiate(idiotSandwhich);
            }
            nextMove = Time.time + Random.Range(moveCD-2, moveCD+2);
        }
        if (aggro && Time.time < volleyStart + volleyDur && Time.time > nextVolleyAttack) {
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
    /*
    public void checkAllGood(string s) {
        if (s.ToLower().Equals("all good!")) {
            aggro = true;
            nextMove += 7f;
            algscreen.SetActive(false);
            algscreen.transform.GetChild(1).GetComponent<TMP_InputField>().text = "";
            player.GetComponent<PlayerMovement>().enabled =true;
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.velocity = lastDir;
            //Time.timeScale = 1f;
            lastAlg = Time.time;
        }
    }
    */
}
