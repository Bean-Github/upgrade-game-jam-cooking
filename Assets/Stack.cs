using System.Collections.Generic;
using UnityEngine;

public class Stack : MonoBehaviour
{
    private List<GameObject> stack;
    void Start()
    {
        stack = new List<GameObject>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<PlayerHolding>().DropIngredient(handleStack);
    }

    public void handleStack(GameObject obj)
    {
        if (obj == null) return;

        stack.Add(obj);
        obj.transform.parent = this.gameObject.transform;
        obj.transform.position = this.gameObject.transform.position;
        obj.transform.localScale = Vector3.one;
    }
}
