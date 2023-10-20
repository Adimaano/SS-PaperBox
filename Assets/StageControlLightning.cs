using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageControlLightning : MonoBehaviour
{
    [SerializeField]
    private GameObject orb;
    private bool activeStage;
    private int control;
    private Vector3 orbOriginalPos, hoverPos;
    // Start is called before the first frame update
    void Start()
    {
        activeStage=false;
        control=0;
        orbOriginalPos = new Vector3(orb.transform.position.x, orb.transform.position.y, orb.transform.position.z);
        hoverPos = new Vector3(orb.transform.position.x, orb.transform.position.y+5f, orb.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Return"))
        {
            control++;
            Debug.Log("Continue BlockOut");
        }

        if(Input.GetButtonDown("Cancel"))
        {
            control=0;
            Debug.Log("Reset BlockOut");
        }

        if(activeStage)
        {
            switch (control)
            {
                case 0:
                    orb.GetComponent<Rigidbody>().useGravity=true;
                    orb.transform.position = orbOriginalPos;
                    break;
                case 1:
                    orb.GetComponent<Rigidbody>().useGravity=false;
                    orb.transform.position = hoverPos;
                    break;
                case 2:
                    orb.transform.Translate(Vector3.right * 1.5f * Time.deltaTime);
                    break;
                case 3:
                    orb.transform.Translate(Vector3.forward * 1.5f * Time.deltaTime);
                    break;
                case 4:
                    orb.transform.Translate(Vector3.up * 1.5f * Time.deltaTime);
                    break;
                case 5:
                    orb.transform.Translate(Vector3.back * 1.5f * Time.deltaTime);
                    if(orb.transform.position.z<=-24f)
                    {
                        control=6;
                    }
                    break;  
                case 6:
                    break;
                default:
                    break;
            }
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            activeStage=true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            activeStage=false;
        }
    }
}
