using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlScript : MonoBehaviour
{
    public float speed;
    void Update()
    {
       UpdatePlayerPosition();
    }

    void UpdatePlayerPosition()
    {
         Vector3 motion = transform.right * MoveInputX() + transform.forward * MoveInputY();

        if (motion.sqrMagnitude > 1) motion.Normalize();
        
        transform.position += motion * speed * Time.deltaTime;

    }

    float MoveInputX()
    {
        return Input.GetAxis("Horizontal");
    }

    float MoveInputY()
    { 
        return Input.GetAxis("Vertical");
    }
}
