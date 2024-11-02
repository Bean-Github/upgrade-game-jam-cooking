using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RamseyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float nextJump;
    public float minCD;
    public float maxCD;
    public bool jumping;
    public float movementSpeed;
    private float a;
    private float b;
    private float c; 
    public float targetX;
    public float targetY;

    void Start()
    {
        nextJump = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (jumping) {
            float newx = 0; 
            if (targetX > 0) {
                newx = this.transform.position.x + movementSpeed * Time.deltaTime;
            } else if (targetX <= 0) {
                newx = this.transform.position.x - movementSpeed * Time.deltaTime;
            }
            float newy = a * newx * newx + b * newx + c;  
            float delty = newy - this.transform.position.y;
            float deltx = newx - this.transform.position.x;
            this.transform.Translate(new Vector3 (deltx, delty, 0)); 
        }
        if (targetX > 0) {
            if (this.transform.position.x > targetX) {
                jumping = false; 
            }
        } else if (targetX < 0) {
            if (this.transform.position.x < targetX) {
                jumping = false; 
            }
        }
        
        if (!jumping && Time.time > nextJump) { 
            //a = Random.Range(0.05f, 1.05f);
            if (this.transform.position.x < 0) {
                targetX = Random.Range(this.transform.position.x + 0.1f, 8.5f);
            } else {
                targetX = Random.Range(-8.5f, this.transform.position.x - 0.1f);
            }
            targetY = Random.Range(-1f, 4.2f);
            nextJump = Time.time + Random.Range(minCD, maxCD);
            jumping = true;

            Matrix4x4 matrix = Matrix4x4.identity;
            float midx = (this.transform.position.x + targetX)/2f;
            float midy = (this.transform.position.y + targetY)/2f;
            matrix[0, 0] = this.transform.position.x * this.transform.position.x; 
            matrix[0, 1] = this.transform.position.x; 
            matrix[0, 2] = 1;
            matrix[1, 0] = targetX * targetX; 
            matrix[1, 1] = targetX; 
            matrix[1, 2] = 1;
            matrix[2, 0] = midx * midx; 
            matrix[2, 1] = midx; 
            matrix[2, 2] = 1;
            Matrix4x4 matrixB = Matrix4x4.zero;

            matrixB[0, 3] = this.transform.position.y;
            matrixB[1, 3] = targetY;
            matrixB[2, 3] = 4.2f;

            Matrix4x4 solution = matrix.inverse * matrixB;
            a = solution[0, 3];
            b = solution[1, 3];
            c = solution[2, 3];
        }
        
        
    }
}
