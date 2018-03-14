# Instantiate

> 프리팹과 같은 객체를 복제하는 것

- 매개변수한개 : 그냥 생성함
- 매개변수 세개 : Instantiate 될 객체, 생성 위치, 생성 회전방향



```c#
using UnityEngine;
using System.Collections;

public class UsingInstantiate : MonoBehaviour
{
    public Rigidbody rocketPrefab;
    public Transform barrelEnd;
    
    
    void Update ()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Rigidbody rocketInstance;
            rocketInstance = Instantiate(rocketPrefab, barrelEnd.position, barrelEnd.rotation) as Rigidbody;
            rocketInstance.AddForce(barrelEnd.forward * 5000);
        }
    }
}
```

```c#
using UnityEngine;
using System.Collections;

public class RocketDestruction : MonoBehaviour
{
    void Start()
    {
        Destroy (gameObject, 1.5f);
    }
}
```