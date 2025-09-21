using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform CameraPosition;

    private void Update()
    {
        transform.position = CameraPosition.position;
    }
}
