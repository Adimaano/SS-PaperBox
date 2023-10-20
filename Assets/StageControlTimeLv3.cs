using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageControlTimeLv3 : MonoBehaviour
{
    [SerializeField]
    private GameObject Entrance, Exit,  code1, code2, code3, code4, rosepedals, autumnmound, Leaves, Falling;
    private bool activeStage;
    private int control;
    private Color colorSpring, colorSummer, colorAutumn, colorWinter;
    // Start is called before the first frame update
    void Start()
    {   
        colorSpring = new Color (0.96f,0.57f,0.87f,1f);
        colorSummer = new Color (0.24f,0.6f,0.44f,1f);
        colorAutumn = new Color (1.0f,0.52f,0.1f,1f);
        colorWinter = new Color (0.5f,0.86f,1f,1f);
        Leaves.GetComponent<Renderer>().material.color = colorWinter;
        Falling.GetComponent<Renderer>().material.color = colorWinter;
        Entrance.SetActive(true);
        Exit.SetActive(false);
        code1.SetActive(false);
        code2.SetActive(false);
        code3.SetActive(false);
        code4.SetActive(false);
        autumnmound.SetActive(false);
        rosepedals.SetActive(false);
        activeStage=false;
        control=0;
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
                    autumnmound.SetActive(false);
                    rosepedals.SetActive(false);
                    Leaves.SetActive(false);
                    Entrance.SetActive(false);
                    Exit.SetActive(true);
                    code1.SetActive(false);
                    code2.SetActive(false);
                    code3.SetActive(false);
                    code4.SetActive(true);
                    Leaves.GetComponent<Renderer>().material.color = colorWinter;
                    Falling.GetComponent<Renderer>().material.color = colorWinter;
                    Leaves.SetActive(false);
                    break;
                case 1:
                    Leaves.SetActive(true);
                    code1.SetActive(false);
                    code2.SetActive(false);
                    code3.SetActive(true);
                    autumnmound.SetActive(true);
                    Leaves.GetComponent<Renderer>().material.color = colorAutumn;
                    Falling.GetComponent<Renderer>().material.color = colorAutumn;
                    code4.SetActive(false);
                    break;
                case 2:
                    code1.SetActive(false);
                    code2.SetActive(true);
                    Leaves.GetComponent<Renderer>().material.color = colorSummer;
                    Falling.GetComponent<Renderer>().material.color = colorSummer;
                    code3.SetActive(false);
                    autumnmound.SetActive(false);
                    code4.SetActive(false);
                    break;
                case 3:
                    code1.SetActive(true);
                    rosepedals.SetActive(true);
                    Leaves.GetComponent<Renderer>().material.color = colorSpring;
                    Falling.GetComponent<Renderer>().material.color = colorSpring;
                    code2.SetActive(false);
                    code3.SetActive(false);
                    code4.SetActive(false);
                    break;
                case 4:
                    Entrance.SetActive(true);
                    Exit.SetActive(false);
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
