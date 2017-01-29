using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MushiBody : MusiControl
{
    [SerializeField]
    private MusiControl follow;

    float offset;

    private void Awake()
    {
        follow.OnChange += o =>
        {
            if (destination == null && o != null)
            {
                destination = o;
                if (OnChange != null)
                {
                    OnChange(destination);
                }
            }
        };
    }

    void Start()
    {
        offset = Vector3.Distance(follow.transform.position, transform.position);
        destination = follow.Destination;
        if (OnChange != null && destination != null)
        {
            OnChange(destination);
        }
    }

    void FixedUpdate()
    {
        if (!destination)
        {
            return;
        }

        if (destination == follow.Destination)
        {
            float dis = Vector3.Distance(follow.transform.position, transform.position);
            transform.position += (destination.transform.position - transform.position).normalized * (dis - offset);
        }
        else
        {
            float tmp = Vector3.Distance(destination.transform.position, follow.transform.position);
            if (tmp < offset)
            {
                transform.position = destination.transform.position + (transform.position - destination.transform.position).normalized * (offset - tmp);
            }
            else
            {
                transform.position = follow.transform.position + (destination.transform.position - follow.transform.position).normalized * offset;
                destination = follow.Destination;
            }
        }

        Vector3 direction = follow.transform.position - transform.position;
        float angle = Vector3.Angle(Vector3.left, direction);
        transform.localRotation = Quaternion.Euler((direction.y < 0) ? angle : -angle, 0, 0);
    }

    override public bool IsHitted(WireControl wire, RaycastHit2D hit)
    {
        Action(wire, hit);
        follow.IsHitted(wire, hit);

        return true;
    }
}
