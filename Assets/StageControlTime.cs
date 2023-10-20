using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageControlTime : MonoBehaviour
{
    [SerializeField]
    private GameObject chandelier, chandelierChain;
    private bool activeStage;
    private int control;
    private Vector3 chandelierOriginalPos;
    // Start is called before the first frame update
    void Start()
    {
        activeStage=false;
        control=0;
        chandelierOriginalPos = new Vector3(chandelier.transform.position.x, chandelier.transform.position.y, chandelier.transform.position.z);
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
                    chandelier.GetComponent<Rigidbody>().useGravity=false;
                    chandelierChain.SetActive(true);
                    chandelier.GetComponent<Rigidbody>().isKinematic=true;
                    chandelier.transform.position = chandelierOriginalPos;
                    break;
                case 1:
                    Debug.Log("Part 1");
                    chandelier.GetComponent<Rigidbody>().useGravity=true;
                    chandelierChain.SetActive(false);
                    chandelier.GetComponent<Rigidbody>().isKinematic=false;
                    break;
                case 2:
                    Debug.Log("Part 2");
                    chandelier.GetComponent<Rigidbody>().useGravity=false;
                    chandelier.GetComponent<Rigidbody>().isKinematic=true;
                    chandelier.transform.Translate(Vector3.up * Time.deltaTime * 2f);
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
