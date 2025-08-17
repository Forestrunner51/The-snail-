using UnityEngine;
using System.Collections;
using TMPro;
public class win : MonoBehaviour
{
        public GameObject winText;
        public GameObject Restart;
        public GameObject Quit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created // “other” refers to the collider on the GameObject inside this trigger
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("A collider has entered the DoorObject trigger");
        winText.SetActive(true);
        winText.GetComponent<TextMeshProUGUI>().text = "You Win!";
        Restart.SetActive(true);
        Quit.SetActive(true);
    }

    void OnTriggerStay (Collider other)
    {
        Debug.Log ("A collider is inside the DoorObject trigger");
    }
    
    void OnTriggerExit (Collider other)
    {
        Debug.Log ("A collider has exited the DoorObject trigger");
    }
}
