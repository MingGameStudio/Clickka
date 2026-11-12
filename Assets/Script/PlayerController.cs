using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;

    [Header("Variables")]
    public bool _unlockedJump;
    public bool _unlockedLeftMovement;
    public bool _unlockedRightMovement;

    [Header("Modifier")]
    [SerializeField] float JumpStrength = 1;
    [SerializeField] float LeftMovementAmount = 1;
    [SerializeField] float RightMovementAmount = 1;

    //[Header("Jump")]
    //[SerializeField] private LayerMask jumpableGround;
    //[SerializeField] private Transform GroundDetector;
    //[SerializeField] private float GroundDetectorRadius = 0.2f;
    //[SerializeField] private bool _canJump;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _unlockedJump = false;
        _unlockedLeftMovement = true;
        _unlockedRightMovement = true;
        // FOR NOW ZEHAAHAHAHHA, ignore my blackbeard ahh laugh
    }
    void Update()
    {
        
    } 
    void FixedUpdate()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        float previousYVelocity = rb.linearVelocity.y;
        rb.linearVelocity = new Vector2(0,previousYVelocity);
        // this basically resets the velocity to 0, so the player doesn't keep moving when no input is given.
        // it keeps shit snappy (:
        if (_unlockedLeftMovement == true)
        {
            if (moveInput < 0)
            {
                rb.linearVelocity = new Vector2(-1 * LeftMovementAmount, rb.linearVelocity.y);
            }
            
        }
        if (_unlockedRightMovement == true)
        {
            if (moveInput > 0)
            {
                rb.linearVelocity = new Vector2(1 * RightMovementAmount, rb.linearVelocity.y);
            }
        }
    }



}
