using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class DestinationLightController : MonoBehaviour
{
    public Light2D lights;
    public float radius = 1f;
    public bool gameComplete;

    private void Start()
    {
        gameComplete = false;
        radius = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameComplete)
        {

            lights.pointLightOuterRadius = radius;
            if (radius < 200f)
                radius++;
        }
    }
}
