using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCloud : MonoBehaviour
{
    [SerializeField] float forceMultiplier = 350;
    [SerializeField] float maxDragDistance = .8f;

    Vector2 startPos;
    Rigidbody2D rig;
    SpriteRenderer spr;

    void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        startPos = rig.position;
        rig.isKinematic = true;
    }

    private void OnMouseDown()
    {
        startPos = rig.position;
        spr.color = new Color(0.8f, 0.87f, 0.95f);
    }

    private void OnMouseUp()
    {
        Vector2 currentPos = rig.position;
        Vector2 direction = startPos - currentPos;
        direction.Normalize();

        rig.isKinematic = false;
        rig.AddForce(direction * forceMultiplier);

        spr.color = Color.white;
    }

    private void OnMouseDrag()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 desiredPos = mousePos;

        float distance = Vector2.Distance(desiredPos, startPos);

        if (maxDragDistance < distance)
        {
            Vector2 direction = desiredPos - startPos;
            direction.Normalize();
            desiredPos = startPos + (direction * maxDragDistance);
        }

        rig.position = desiredPos;
    }
}