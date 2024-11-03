using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SwearProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public Transform trans;
    public RectTransform rec;
    public TextMeshPro swear; 
    public CapsuleCollider2D col;
    public float startTime;
    public float dur;
    public Vector3 dir;
    public Rigidbody2D rb;
    public float stunDur;
    public float kbForceX;
    public float kbForceY;
    void Start()
    {
        swear.text = "";
        int charCount = Random.Range(3, 10);
        rec.sizeDelta = new Vector2 (0.7f * charCount, rec.sizeDelta.y);
        int swearID = Random.Range(0, 11);
        if (swearID <= 4)
        {
            for(int i = 0; i < charCount; i++) {
                int charNum = Random.Range(1, 8);
                if (charNum == 1) {swear.text += "!";}
                else if (charNum == 2) {swear.text += "@";}
                else if (charNum == 3) {swear.text += "#";}
                else if (charNum == 4) {swear.text += "$";}
                else if (charNum == 5) {swear.text += "%";}
                else if (charNum == 6) {swear.text += "^";}
                else if (charNum == 7) {swear.text += "&";}
                else if (charNum == 8) {swear.text += "*";}
            }
        }
        else if (swearID == 5)
            swear.text = "FAILURE";
        else if (swearID == 6)
            swear.text = "DONKEY";
        else if (swearID == 7)
            swear.text = "IDIOT";
        else if (swearID == 8)
            swear.text = "DONUT";
        else if (swearID == 9)
            swear.text = "IT'S RAW";
        else if (swearID == 10)
            swear.text = "POOR SOUL";
        //col.size = new Vector2(0.5f, charCount * 0.5f);
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        // trans.Translate(trans.forward * Time.deltaTime * speed);
        rb.velocity = new Vector3(dir.x, dir.y, 0).normalized * speed;
        if (Time.time > startTime + dur) {
            Destroy(this.transform.parent.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            if (collision.gameObject.transform.position.x - this.transform.position.x > 0) {
                collision.gameObject.GetComponent<PlayerMovement>().addStun(stunDur, new Vector3(kbForceX,kbForceY,0));
            } else {
                collision.gameObject.GetComponent<PlayerMovement>().addStun(stunDur, new Vector3(-1 * kbForceX, kbForceY,0));
            }            
            Destroy(this.transform.parent.gameObject);
        }
        
    }
}
