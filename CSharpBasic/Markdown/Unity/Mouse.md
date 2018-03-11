# Mouse

- OnMouseDown() : 마우스 클릭시 발행되는 이벤트

```c#
using UnityEngine;
using System.Collections;

public class MouseClick : MonoBehaviour
{
    void OnMouseDown ()
    {
        rigidbody.AddForce(-transform.forward * 500f);
        rigidbody.useGravity = true;
    }
}

```