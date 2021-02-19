using UnityEngine;

public class DestinationCollider : MonoBehaviour
{
    public GameManager gameManager;
    private void OnTriggerEnter2D(Collider2D colliderInfo)
    {
        if (colliderInfo.name == "LightBox")
        {
            gameManager.CompleteLevel();
        }
    }
}
