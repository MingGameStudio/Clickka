using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] public bool playerCanFollow;
    Camera componentCamera;

    void Awake()
    {
        componentCamera = GetComponent<Camera>();
    }
    void Start()
    {
        playerCanFollow = false;
        // FOR NOW HAHAHAHAHAHHAHAHAHAHA
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        if (playerCanFollow)
        {
            transform.position = new Vector3(playerTransform.position.x, this.transform.position.y, this.transform.position.z);
        }
    }
}
