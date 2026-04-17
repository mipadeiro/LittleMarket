using UnityEngine;

public class ItemRespawn : MonoBehaviour
{

    public float threshold = -5f;
    public Vector3 startPosition;
    public Vector3 startRotation;

    void Start()
    {
        startPosition = transform.position;
        startRotation = transform.eulerAngles;
    }
    void FixedUpdate()
    {
        if(transform.position.y < threshold)
        {
            transform.position = startPosition;
            transform.eulerAngles = startRotation;

            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.angularVelocity = Vector3.zero;
                rb.Sleep();
            }

            Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
            if (rb2d != null)
            {
                rb2d.angularVelocity = 0f;
                rb2d.Sleep();
            }
        }
    }
}
