using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Camera camera;

    private Vector3 startDistance;
    private Vector3 move;

    void Start()
    {
        startDistance = camera.transform.position - target.position;
    }

    void Update()
    {
        move = target.position + startDistance;

        move.x = 0;
        move.y = startDistance.y;

        camera.transform.position = move;
    }
}
