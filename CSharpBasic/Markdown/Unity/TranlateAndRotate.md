# Translate 와 Rotate

> 물체를 이동시키고 회전시킴, 단 물리엔진에 영향을 받는 경우, 물리함수로 translate와 rotate 대신 물리함수로 움직여야

- transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime) : 앞으로 이동
- transfrom.Rotate(Vector3.up, -trunSpeed * Time.deltaTime)  : 첫번째 파라미터는 방향, 두 번째 파라미터는 회전

```c#
using UnityEngine;
using System.Collections;

public class TransformFunctions : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float turnSpeed = 50f;
    
    
    void Update ()
    {
        if(Input.GetKey(KeyCode.UpArrow))
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        
        if(Input.GetKey(KeyCode.DownArrow))
            transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);
        
        if(Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
        
        if(Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
    }
}
```

- LookAt(target) : target을 바라보게 함

```c#
using UnityEngine;
using System.Collections;

public class CameraLookAt : MonoBehaviour
{
    public Transform target;
    
    void Update ()
    {
        transform.LookAt(target);
    }
}
```