using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageControlEarth : MonoBehaviour
{
    [SerializeField]
    private GameObject cavePillar, earthPillar, mirrorGround, mirrorGroundSet, mirrorSet;
    private bool activeStage;
    private int control;
    // Start is called before the first frame update
    void Start()
    {
        activeStage=false;
        control=0;
        cavePillar.SetActive(false);
        earthPillar.SetActive(false);
        mirrorSet.SetActive(false);
        mirrorGroundSet.SetActive(false);
        mirrorGround.SetActive(true);
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
                    cavePillar.SetActive(false);
                    earthPillar.SetActive(false);
                    mirrorSet.SetActive(false);
                    mirrorGroundSet.SetActive(false);
                    mirrorGround.SetActive(true);
                    break;
                case 1:
                    cavePillar.SetActive(true);
                    break;
                case 2:
                    mirrorGroundSet.SetActive(true);
                    mirrorGround.SetActive(false);
                    break;
                case 3:
                    earthPillar.SetActive(true);
                    mirrorSet.SetActive(true);
                    mirrorGroundSet.SetActive(false);
                    break;
                case 4:
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
