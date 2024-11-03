using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdiotSandwichBread : MonoBehaviour
{
    // Start is called before the first frame update
    public float stunDur;
    public float kb;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            collision.gameObject.GetComponent<PlayerMovement>().addStun(stunDur, new Vector3(0f, kb,0));
        }
    }
}
