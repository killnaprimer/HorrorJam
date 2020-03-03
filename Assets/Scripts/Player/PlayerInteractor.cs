using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    public Camera fpsCam;
    public PlayerUi _ui;
    public float range = 100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            _ui.ShowInteractor(hit.transform.CompareTag("Interactive"));
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
            {
                hit.transform.gameObject.SendMessage("Interact", this.gameObject, SendMessageOptions.DontRequireReceiver);
            }
        }
    }
}
