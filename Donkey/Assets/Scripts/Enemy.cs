using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private bool hazard;

    public float value;

    void OnEnable()
    {
        Fruit.Falling += CanDie;
    }
    
    void OnDisable()
    {
        Fruit.Falling -= CanDie;
    }

    private void CanDie(GameObject obj)
    {
        hazard = true;
        UIManager.Instance.UpdateScore(value);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Fruit" && hazard)
        {
            Debug.Log("Hit");
            this.gameObject.SetActive(false);
        }
    }
}
