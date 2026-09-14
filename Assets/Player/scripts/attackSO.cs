using UnityEngine;

[CreateAssetMenu(menuName ="Attacks/Normal")]
public class attackSO : ScriptableObject
{
    public AnimatorOverrideController OVcontroller;
    public float damage;
}
