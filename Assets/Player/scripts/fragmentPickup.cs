using UnityEngine;
using TMPro;
using System.Collections;

public class fragmentPickup : MonoBehaviour
{
    private int fragmentCounter = 0;
    public TMP_Text counterText;
    public TMP_Text buffInfoText;
    public bool canbreakwalls = false;
    [SerializeField]
    PlayerMovement controls;
    private float displayDuration = 3.0F;


    private void Start()
    {
        buffInfoText.enabled = false;
        counterText.enabled = false;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("speedFragment") && collision.gameObject.activeSelf == true)
        {
            collision.gameObject.SetActive(false);
            fragmentCounter += 1;
           
            controls.moveSpeed = 7;
            controls.maxJumps = 2;
            StartCoroutine(ShowAndHideText());

        }
        if (collision.gameObject.CompareTag("Boomfragmentr") && collision.gameObject.activeSelf == true)
        {
            collision.gameObject.SetActive(false);
            canbreakwalls = true;
            fragmentCounter += 1;

            StartCoroutine(ShowAndHideText());

        }
    }
        
    IEnumerator ShowAndHideText()
    {
        buffInfoText.enabled = true;
        counterText.enabled = true;
        yield return new WaitForSeconds(displayDuration);
        buffInfoText.enabled = false;
        counterText.enabled = false;
        
       
    }

}



