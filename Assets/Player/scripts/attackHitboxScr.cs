using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class attackHitboxScr : MonoBehaviour
{
    private ThirdPersonActionAsset actions;
    private InputAction move;

    public int damage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("hit enemy");
            other.gameObject.GetComponent<enemyHP>().losehp(damage);
        }
    }
}
