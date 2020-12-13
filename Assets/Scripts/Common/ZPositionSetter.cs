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
        // If you want to change the transform, use this
        Vector3 newPosition = transform.position;
        newPosition.z = transform.position.y;
        transform.position = newPosition;

        //// Or if you want to change the SpriteRenderer's sorting order, use this
        //GetComponent<SpriteRenderer>().sortingOrder = (int)transform.position.y;
    }
}
