using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using UnityEngine;
using UnityEngine.InputSystem;


public class OffsetCustomizer : MonoBehaviour
{

    public InputActionProperty grabRight;
    public InputActionProperty grabLeft;
    public GameObject lineOfSight;
    public GameObject ui;   
    
    private TriggerInputDetector XRInput;
    // Start is called before the first frame update
    void Start()
    {
        XRInput = FindObjectOfType<TriggerInputDetector>();
        lineOfSight.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        var Vinput = XRInput.GetLeftJoyStick().y;
        if ( Vinput != 0 && transform.position.y >= -10.000f && transform.position.y <= 10.000f)
        {
            transform.Translate(new Vector3(0,Vinput/90f,0));
        }
        else if (transform.position.y > 10f)
        {
            var vector3 = transform.position;
            vector3.y = 9.999f;
            transform.position = vector3;
        }
        else if( transform.position.y < -10f )
        {
            var vector3 = transform.position;
            vector3.y = -9.999f;
            transform.position = vector3;
        }

        if (grabRight.action.ReadValue<float>() >  0f || grabLeft.action.ReadValue<float>() > 0f)
        {
            this.enabled = false;
            Debug.Log("pressed teri maa bkl");
            lineOfSight.SetActive(false);
            Instantiate(ui);
        }
    }
}
