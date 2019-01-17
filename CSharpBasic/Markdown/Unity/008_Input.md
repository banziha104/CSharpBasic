# KeyInput

> Key는 일반적인 키보드 입력을 받음

```c#
using System.Collections;

public class KeyInput : MonoBehaviour
{
    public GUITexture graphic;
    public Texture2D standard;
    public Texture2D downgfx;
    public Texture2D upgfx;
    public Texture2D heldgfx;
    
    void Start()
    {
        graphic.texture = standard;
    }
    
    void Update ()
    {
        bool down = Input.GetKeyDown(KeyCode.Space);
        bool held = Input.GetKey(KeyCode.Space);
        bool up = Input.GetKeyUp(KeyCode.Space);
        
        if(down)
        {
            graphic.texture = downgfx;
        }
        else if(held)
        {
            graphic.texture = heldgfx;
        }
        else if(up)
        {
            graphic.texture = upgfx;
        }
        else
        {
            graphic.texture = standard; 
        }
        
        guiText.text = " " + down + "\n " + held + "\n " + up;
    }
}
```

# ButtonInput

> 버튼은 ButtonName으로 작동함, Edit -> ProjectSettings -> Input에서 Button Name 설정가능

- GetButtonDown: 누르게 되면 True
- GetButton: 누를때 True, 눌려있는 동안 True
- GetButtonUp : 버튼에서 때면 True

```c#
using UnityEngine;
using System.Collections;

public class ButtonInput : MonoBehaviour
{
    public GUITexture graphic;
    public Texture2D standard;
    public Texture2D downgfx;
    public Texture2D upgfx;
    public Texture2D heldgfx;
    
    void Start()
    {
        graphic.texture = standard;
    }
    
    void Update ()
    {
        bool down = Input.GetButtonDown("Jump");
        bool held = Input.GetButton("Jump");
        bool up = Input.GetButtonUp("Jump");
        
        if(down)
        {
            graphic.texture = downgfx;
        }
        else if(held)
        {
            graphic.texture = heldgfx;
        }
        else if(up)
        {
            graphic.texture = upgfx;
        }
        else
        {
            graphic.texture = standard;
        }
    
        guiText.text = " " + down + "\n " + held + "\n " + up;
    }
}
```