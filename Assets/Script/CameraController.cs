using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private bool playerCanFollow;
    Camera componentCamera;

    void Awake()
    {
        componentCamera = GetComponent<Camera>();
    }
    void Start()
    {
        playerCanFollow = true;
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
