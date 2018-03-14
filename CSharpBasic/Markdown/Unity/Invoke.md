# Invoke

> 매개변수로 받은 시간 뒤에 함수를 호출함, void를 반환하는 함수만 가능

- CancelInvoke("invoke된 함수의 이름") : invoke를 종료시킴, 매개변수가 없는 경우 전체 invoke 종료
 
```c#
using UnityEngine;
using System.Collections;

public class InvokeScript : MonoBehaviour 
{
    public GameObject target;
    
    
    void Start()
    {
        Invoke ("SpawnObject", 2); // 2초뒤에 SpawnObject를 호출
    }
    
    void SpawnObject()
    {
        Instantiate(target, new Vector3(0, 2, 0), Quaternion.identity);
    }
}
```

<br>

# InvokeRepeating

```c#
using UnityEngine;
using System.Collections;

public class InvokeRepeating : MonoBehaviour 
{
    public GameObject target;
    
    
    void Start()
    {
        InvokeRepeating("SpawnObject", 2, 1); // 함수, 호출시간, 첫 호출후 다음 호출까지의 시간
    }
    
    void SpawnObject()
    {
        float x = Random.Range(-2.0f, 2.0f);
        float z = Random.Range(-2.0f, 2.0f);
        Instantiate(target, new Vector3(x, 2, z), Quaternion.identity);
    }
}
```