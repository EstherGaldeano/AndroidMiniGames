using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureRepeat : MonoBehaviour
{
    public float speed;
    private Vector2 offset;

    void Update()
    {
        // Corrected assignment operator
        offset = new Vector2(0, Time.time * speed);

        // Corrected assignment operator
        GetComponent<Renderer>().material.mainTextureOffset = offset;
    }
}
