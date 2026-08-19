using UnityEngine;

public class animatorDataTranslater : MonoBehaviour
{
    public bool canAttack;
    public bool Attacking;
    public bool canTurn;
    public AttackController controller;
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    public void SetCanAttack(bool state)
    {
        canAttack = state;
    }
    public void SetAttacking(bool state)
    {
        Attacking = state;
    }

}
