using UnityEngine;

public class FallRespawn : MonoBehaviour
{

    public float threshold;

    void FixedUpdate()
    {
        if(transform.position.y < threshold)
        {
            transform.position = new Vector3(0f, -1f, 0f);
        }
    }
}
