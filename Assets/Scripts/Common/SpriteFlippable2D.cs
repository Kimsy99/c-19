using UnityEngine;

public class SpriteFlippable2D : Movable2D
{
    // Update is called once per frame
    void Update()
    {
        float xscale = Mathf.Abs(transform.localScale.x);
        if (HSpeed > 0)
            transform.localScale = new Vector2(xscale, transform.localScale.y);
        else if (HSpeed < 0)
            transform.localScale = new Vector2(-xscale, transform.localScale.y);
    }
}
