using UnityEngine;

public class ZPositionSetter : MonoBehaviour
{
    void Awake()
    {
        SetZ();
    }

    void Update()
    {
        SetZ();
    }

    void SetZ()
    {
        Vector3 newPosition = transform.position;
        newPosition.z = transform.position.y;
        transform.position = newPosition;
    }
}
