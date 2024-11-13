using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    void OnEnable()
    {
        Fruit.Falling += IncreaseScore;
    }

    void OnDisable()
    {
        Fruit.Falling -= IncreaseScore;
    }
    // Update is called once per frame
    void IncreaseScore(GameObject obj)
    {
        UIManager.Instance.UpdateScore(obj.GetComponent<Fruit>().value);
    }
}
