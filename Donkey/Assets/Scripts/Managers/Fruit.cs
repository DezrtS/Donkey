using System;
using Unity.VisualScripting;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public static event Action<GameObject> Falling;

    public float value;

    void Start()
    {
        value = 100f;
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.name == "Player")
        {
            this.GetComponent<Rigidbody2D>().gravityScale = 1;

            if (Falling != null)
            {
                Falling(this.gameObject);
            }
        }

        if (other.gameObject.name == "Enemy" && Falling != null)
        {
            other.gameObject.SetActive(false);
        }
    }
}
