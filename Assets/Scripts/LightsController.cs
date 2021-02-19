using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightsController : MonoBehaviour
{
    public Light2D lights;
    public Transform playerTransform;
    public float maxRadius = 5f;
    public float levelCompleteRadius = 100f;
    private bool levelComplete = false;

    private void Start()
    {
        levelComplete = false;
    }
    private void Update()
    {

        lights.pointLightOuterRadius = GetRadius();

    }

    private float GetRadius()
    {
        if (!levelComplete)
        {
            float playerLightsDistance = Vector2.Distance(transform.position, playerTransform.position);
            return Mathf.Clamp((Mathf.Exp(playerLightsDistance) - 1) / 2, 0, maxRadius);
        }
        else
        {
            return levelCompleteRadius;
        }
    }

    public void onLevelComplete()
    {
        print("hello");
        levelComplete = true;
    }
}
