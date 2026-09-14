using UnityEngine;

public class billboard : MonoBehaviour
{
    public GameObject hitbox;
    void Update()
    {
        transform.rotation = Quaternion.Euler(Camera.main.transform.rotation.eulerAngles.x, Camera.main.transform.rotation.eulerAngles.y, Camera.main.transform.rotation.eulerAngles.z);
    }

    public void hitboxEnable(){
        hitbox.SetActive(true);
    }

    public void hitboxDisable()
    {
        hitbox.SetActive(false);
    }
}
