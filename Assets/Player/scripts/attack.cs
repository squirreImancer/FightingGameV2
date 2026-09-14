using NUnit.Framework;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class attack : MonoBehaviour
{
    public List<attackSO> combo;
    [SerializeField]
    Animator animator;
    float lastClickedTime;
    float lastComboEnd;
    int comboCounter;
    [SerializeField]
    GameObject hitbox;
    [SerializeField]
    PlayerMovement Movement;


    private void Start()
    {
        comboCounter = 0;
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Movement.isOnGround()) {
            Attack();
        }
        exitAttack();
    }


    void Attack()
    {
        //animator.SetBool("attacking", true);
        //if the last time is less than 0.2f 9Can be varible
        if (Time.time - lastComboEnd > 0.03f && comboCounter < combo.Count-1)
        {

            

            if (animator.GetCurrentAnimatorClipInfo(0).Length != 0 && Time.time - lastClickedTime > animator.GetCurrentAnimatorClipInfo(0)[animator.GetCurrentAnimatorClipInfoCount(0) - 1].clip.length - 0.4f)
            {
                CancelInvoke("endCombo");
                animator.runtimeAnimatorController = combo[comboCounter].OVcontroller;
                hitbox.GetComponent<attackHitboxScr>().damage = (int)combo[comboCounter].damage;
                animator.Play("Attack", 0, 0);
                animator.SetBool("attacking", true);
                comboCounter++;
                Debug.Log(comboCounter);
                lastClickedTime = Time.time;
                

                
            }
            if (comboCounter >= combo.Count)
            {
                comboCounter = 0;
                Invoke("exitAttack", 0);
            }

        }
    }
    void exitAttack()
    {
        if(animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.8f && animator.GetCurrentAnimatorStateInfo(0).IsTag("e")){
            //animator.SetBool("attacking", true);
            Invoke("endCombo",0);
            comboCounter = 0;

        }
    }
    void endCombo()
    {
        lastComboEnd = Time.time;
        comboCounter = 0;
        animator.SetBool("attacking", false);

    }
}
