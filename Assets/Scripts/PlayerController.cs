using UnityEngine;
using UnityEngine.Tilemaps;
public class PlayerController : MonoBehaviour
{
    public PlayerControls playerControls;
    public Transform movePoint;
    public float speed = 3f;
    public Tilemap groundTilemap;
    public Tilemap visibleCollisionTilemap;
    public Tilemap unvisibleCollisionTilemap;
    public Transform lightbox;

    private bool isCarryingLight = false;

    private void Awake()
    {
        playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }
    private void OnDisable()
    {
        playerControls.Disable();
    }

    private void Start()
    {
        playerControls.Main.Movement.performed += context => MovePoint(context.ReadValue<Vector2>() / 2);
        playerControls.Main.Carry.performed += _ => OnChangeCarryLight();

    }

    private void MovePoint(Vector2 direction)
    {
        if (CanMove(direction))
        {
            movePoint.position += (Vector3)direction;
            // MovePlayer();
        }
    }

    private bool CanMove(Vector2 direction)
    {
        Vector3Int playerMovement = groundTilemap.WorldToCell(transform.position + (Vector3)direction);
        Vector3Int lightMovement = groundTilemap.WorldToCell(lightbox.position + (Vector3)direction);
        Vector3 lightPosition = groundTilemap.WorldToCell(lightbox.position);
        if (!isCarryingLight)
        {
            return (CheckCollision(playerMovement) && playerMovement != lightPosition);
        }
        else
        {
            return (CheckCollision(playerMovement) && CheckCollision(lightMovement));
        }

    }

    private bool CheckCollision(Vector3Int gridPosition)
    {
        return groundTilemap.HasTile(gridPosition) && !visibleCollisionTilemap.HasTile(gridPosition) && !unvisibleCollisionTilemap.HasTile(gridPosition);
    }

    // private void MovePlayer()
    // {
    //     transform.position = Vector3.MoveTowards(transform.position, movePoint.position, speed * Time.deltaTime);
    // }

    void OnChangeCarryLight()
    {
        if (Vector3.Distance(lightbox.position, transform.position) < 0.6)
        {
            if (isCarryingLight)
            {
                lightbox.parent = null;
                isCarryingLight = false;
            }
            else
            {
                lightbox.parent = transform;
                isCarryingLight = true;
            }
        }

    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, speed * Time.deltaTime);
        // Vector2 inputControls = playerControls.Main.Movement.ReadValue<Vector2>();
        // transform.position += (Vector3)inputControls * speed * Time.deltaTime;
    }
}
