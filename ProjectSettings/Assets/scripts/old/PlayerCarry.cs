using UnityEditor.ShaderGraph;
using UnityEngine;

public class PlayerCarry : MonoBehaviour
{

public Transform carryPoint;
public float pickupRange = 5f;
public float followStrength = 15f;
public float maxCarryHeightOffset = 3f;
private Rigidbody carriedRB;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse button 0 pressed");
            TryPickup();
        }

        if (Input.GetMouseButtonDown(1) && carriedRB != null)
        {
            DropItem();
        }
    }

    void FixedUpdate()
    {
        if (carriedRB != null)
        {
            Vector3 targetPosition = transform.position + Vector3.up * 1f;
            carriedRB.position = targetPosition;
            carriedRB.angularVelocity = Vector3.zero;
            carriedRB.linearVelocity = Vector3.zero;
        }
    }

    void TryPickup()
    {
        if (carriedRB != null) return;

        Collider[] colliders = Physics.OverlapSphere(transform.position, pickupRange);
        
        float closestDistance = float.MaxValue;
        Rigidbody closestRB = null;

        foreach (Collider col in colliders)
        {
            if (col.CompareTag("Pickup"))
            {
                Rigidbody rb = col.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    float distance = Vector3.Distance(transform.position, col.transform.position);
                    if (distance < closestDistance)
                    {
                        closestDistance = distance;
                        closestRB = rb;
                    }
                }
            }
        }

        if (closestRB != null)
        {
            Renderer rend = closestRB.GetComponentInChildren<Renderer>();
            if (rend != null)
            {
                float objectHeight = rend.bounds.size.y;
                float dynamicHeight = Mathf.Min(objectHeight / 2f, maxCarryHeightOffset);
                carryPoint.localPosition = new Vector3(0, dynamicHeight, 0);
            }
            else
            {
                carryPoint.localPosition = new Vector3(0, 1f, 0);
            }

            closestRB.useGravity = false;
            carriedRB = closestRB;
            Debug.Log("Picked up: " + closestRB.gameObject.name);
        }
    }

    void DropItem()
    {
        if (carriedRB == null) return;

        carriedRB.useGravity = true;
        carriedRB = null;

        carryPoint.localPosition = new Vector3(0, 2f, 0);
    }
}
