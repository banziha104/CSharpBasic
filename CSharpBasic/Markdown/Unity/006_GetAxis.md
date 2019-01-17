# GetAxis

- 불리언을 반환하는 GetButton과 다르게 버튼이 눌린 버튼의 량을 
- Gravity : 중점으로 복귀하는데 걸리는 시간
- Sesitivity : 중점에서 Postive나 Negative 로 가는 속도
- Dead : 움직여야하는 양이 많아짐
- Snap : 음과 양이 홀드된 경우 0을 반환할 수 있음

```c#
using UnityEngine;
using System.Collections;

public class AxisRawExample : MonoBehaviour
{
    public float range;
    public GUIText textOutput;
    
    
    void Update () 
    {
        float h = Input.GetAxisRaw("Horizontal");
        float xPos = h * range;
        
        transform.position = new Vector3(xPos, 2f, 0);
        textOutput.text = "Value Returned: "+h.ToString("F2");  
    }
}
```