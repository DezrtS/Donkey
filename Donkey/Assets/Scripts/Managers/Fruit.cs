using System;
using Unity.VisualScripting;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public static event Action<GameObject> Falling;

    public float value;
    private bool falling;

    void Start()
    {
        value = 100f;
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.name == "Player")
        {
            this.GetComponent<Rigidbody2D>().gravityScale = 1;
            falling = true;
            if (Falling != null)
            {
                Falling(this.gameObject);
            }
        }

        if (other.gameObject.name == "Enemy" && falling == true)
        {
            Debug.Log("Hit Enemy");
            other.gameObject.SetActive(false);
        }
    }
}
