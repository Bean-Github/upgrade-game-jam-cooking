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
    void Start()
    {
        swear.text = "";
        int charCount = Random.Range(3, 10);
        rec.sizeDelta = new Vector2 (0.7f * charCount, rec.sizeDelta.y);
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
        col.size = new Vector2(0.5f, charCount * 0.7f);
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        trans.Translate(dir * Time.deltaTime * speed);
        print(Vector3.forward);
        if (Time.time > startTime + dur) {
            Destroy(this.transform.parent.gameObject);
        }
    }

    private void OnTriggerEnter() {
        Destroy(this.gameObject);
    }
}
