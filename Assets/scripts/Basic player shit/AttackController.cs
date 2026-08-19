using UnityEngine;
using UnityEngine.InputSystem;
public class AttackController : MonoBehaviour
{

public Animator anims;
public animatorDataTranslater animTranslater;
    public void attack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (animTranslater.canAttack && !animTranslater.Attacking)
            {
                Debug.Log("Attacking");
                anims.SetTrigger("Attack");
            }
            
        }
        
    }

}
