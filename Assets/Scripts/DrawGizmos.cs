using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawGizmos : MonoBehaviour
{
    public Color sphereColor = Color.red;

    [Range(0f, 1f)]
    public float radius = 1;
    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = sphereColor;
        Gizmos.DrawSphere(transform.position, radius);
    }
}
