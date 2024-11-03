using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllGoodScreen : MonoBehaviour
{
    // Start is called before the first frame update
    public float state;
    public float lastState;
    public float stateDur;
    public Image image;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > lastState + stateDur) {
            if (state == 0) {
                state = 1;
                image.color = new Color32(255, 50, 50, 130);
            } else {
                state = 0;
                image.color = new Color32(255, 95, 95, 200);
            }
            lastState = Time.time;
        }
    }
}
