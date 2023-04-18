using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class GameMenuManager : MonoBehaviour
{
    public GameObject menu;
    public GameObject head;
    public float spawnDistance = 2;
    public InputActionProperty showButton;
    
    // Start is called before the first frame update
    void Start()
    {
        this.menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (this.showButton.action.WasPressedThisFrame())
        {
            Debug.Log("Button Pressed");
            this.menu.SetActive(!this.menu.activeSelf);
            this.menu.transform.position = this.head.transform.position +
                                           new Vector3(this.head.transform.forward.x, 0, this.head.transform.forward.z)
                                               .normalized * this.spawnDistance;
            this.menu.transform.LookAt(new Vector3(this.head.transform.position.x, this.menu.transform.position.y, this.head.transform.position.z));
            this.menu.transform.forward *= -1;
        }
    }
}
