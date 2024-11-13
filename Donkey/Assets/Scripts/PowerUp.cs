using UnityEngine;
using System.Runtime.InteropServices;

public class PowerUp : MonoBehaviour
{
    [DllImport("PowerUp")]
    private static extern void StartColorChange();

    [DllImport("PowerUp")]
    private static extern void StopColorChange();

    [DllImport("PowerUp")]
    private static extern bool GetNextColor(out float r, out float g, out float b, out float a);

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartColorChange();
    }

    void Update()
    {
        if (GetNextColor(out float r, out float g, out float b, out float a))
        {
            spriteRenderer.color = new Color(r, g, b, a);
        }
    }

    void OnDestroy()
    {
        StopColorChange();
    }
}
