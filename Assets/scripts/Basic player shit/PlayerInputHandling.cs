using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInputHandling : MonoBehaviour
{
   public float direction { get; private set; }
    public bool jump {  get; private set; }
    public bool releaseJump { get; private set; }

    public Vector2 moveinput { get; private set; }

    public void move(InputAction.CallbackContext context)
    {
      
       direction = context.ReadValue<Vector2>().x;
       moveinput = context.ReadValue<Vector2>(); 
    }
    public void jumpaction(InputAction.CallbackContext context)
    {
        if (context.canceled)
        {
            releaseJump = true;
            jump= false;

        } else if (context.started)
        {
            releaseJump= false;
            jump = true;
        }
    }

  
}
