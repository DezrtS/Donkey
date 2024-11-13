using UnityEngine;
using System.Runtime.InteropServices;

public class PowerUp : MonoBehaviour
{
    [DllImport("PowerUp")]
    private static extern bool GetNextColor(ref Color color, float deltaTime);

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        try
        {
            Color color = new Color();
            if (GetNextColor(ref color, Time.deltaTime * 20))
            {
                spriteRenderer.color = color;
            }
        }
        catch
        {

        }
    }
}
