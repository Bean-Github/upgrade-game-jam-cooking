using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class RamseyAttack : MonoBehaviour
{
    // Start is called before the first frame update
    public float nextAttack;
    public float attackCD;
    public GameObject projectile;
    private RamseyMovement movem;
    private GameObject player;
    void Start()
    {
        movem = this.gameObject.GetComponent<RamseyMovement>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (!movem.jumping && Time.time > nextAttack) {
            UnityEngine.Vector3 diff = player.transform.position - this.transform.position;
            diff.Normalize();
            float rot = Mathf.Asin(diff.y) * Mathf.Rad2Deg;
            GameObject proj = Instantiate(projectile, new UnityEngine.Vector3(this.transform.position.x + diff.x, this.transform.position.y + diff.y, 0), 
                UnityEngine.Quaternion.Euler(0,0,rot));
            proj.transform.GetChild(0).GetComponent<SwearProjectile>().dir = diff;
            nextAttack += attackCD;
        }
    }
}
