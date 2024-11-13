using System.Net.Mime;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance = null;
    public TMP_Text score;
    public TMP_Text bonus;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void UpdateScore(float _score)
    {
        _score++;
        score.text = $"Score: {_score}";
    }
}
