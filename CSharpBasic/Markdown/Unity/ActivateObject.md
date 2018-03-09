# ActivateObjects

> 부모 오브젝트가 비활성화되면 자식 오브젝트도 비활성화, 그러나 계층 내에서는 활성화 상태를 유지하고 있음

- SetActive(boolean) : 액티비티의 상태를 만듬
- activateSelf : 자체적인 활성 상태를 표시
- activateInHiearachy : 하이어라키 상의 활성상태를 표시(부모가 꺼지면 꺼짐)

```c#
using UnityEngine;
using System.Collections;

public class ActiveObjects : MonoBehaviour
{
    public GameObject myObject;
    void Start ()
    {
        gameObject.SetActive(false);
        Debug.Log("Active Self: " + myObject.activeSelf);
        Debug.Log("Active in Hierarchy" + myObject.activeInHierarchy);
    }
}
```