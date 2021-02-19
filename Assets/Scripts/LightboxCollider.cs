using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightboxCollider : MonoBehaviour
{
    public float lightDirection = 5000f;
    public Light2D lightspot;

    private void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        print("We hit something");
        print(collisionInfo.collider.name);
        // print(lightspot.fall);
    }

    private void Update()
    {
        Vector2 currentFalloffOffset = lightspot.shapeLightFalloffOffset;
        currentFalloffOffset.x = lightDirection;
        print(lightspot.shapeLightFalloffOffset);
    }
}
