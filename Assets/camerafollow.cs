
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.125f;
    public float offset =0;
    void Update()
    {
        transform.position = new Vector3(target.position.x, 0f,0f+ offset);
    }
}
