using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageControlTimeLv2 : MonoBehaviour
{
    [SerializeField]
    private GameObject plate, clock;
    private bool activeStage;
    private int control;
    private Vector3 plateOriginalPos, plateEndPos;
    // Start is called before the first frame update
    void Start()
    {   
        activeStage=false;
        control=0;
        plateOriginalPos = new Vector3(plate.transform.position.x, plate.transform.position.y, plate.transform.position.z);
        plateEndPos = new Vector3(plate.transform.position.x, plate.transform.position.y, plate.transform.position.z+22.5f);
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
                    plate.transform.position = plateOriginalPos;
                    break;
                case 1:
                    Debug.Log("Part 1");
                    if(plate.transform.position.z<plateEndPos.z)
                    {
                        plate.transform.Translate(Vector3.forward * 10.0f * Time.deltaTime);
                    }
                    else
                    {
                        plate.transform.position = plateOriginalPos;
                    }
                    break;
                case 2:
                    Debug.Log("Part 2");
                    break;
                case 3:
                    Debug.Log("Part 3");
                    if(plate.transform.position.z>plateOriginalPos.z)
                    {
                        plate.transform.Translate(Vector3.back * 5.0f * Time.deltaTime);
                    }
                    else
                    {
                        plate.transform.position = plateEndPos;
                    }
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
