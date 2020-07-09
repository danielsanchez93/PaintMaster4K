using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPicker : MonoBehaviour
{
    public Color color1,color2;
    public Texture2D textureRainbow;
    public Vector3 size = new Vector3(100, 10, 100);
    private void OnMouseDown()
    {
        int x = Mathf.FloorToInt(transform.position.x / size.x * textureRainbow.width);
        int z = Mathf.FloorToInt(transform.position.z / size.z * textureRainbow.height);
        color1 = textureRainbow.GetPixel(x,z);
    }
}
