using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MultiBarScript : MonoBehaviour
{

    //===============================================================
    // Variables
    //===============================================================
    [SerializeField] TMP_Text multibarLevelIndicator;
    public static int multiplierField;
    int max;
    int min;
    int current;
    [SerializeField] Image foreground;
    int threshholdLevel;

    public static MultiBarScript multiBarInstance;

    private void Awake()
    {
        multiBarInstance = this;
    }

    // Start is called before the first frame update
    void Start() 
    {
        threshholdLevel = 1;
        current = 0;
        multiplierField = 1;
    }

    // Update is called once per frame
    void Update()
    {
        GetCurrentFill();
        ThreshholdState();
    }

    public void UpdateCurrent(int newPoints)
    {
        current += newPoints;
        Debug.Log(current);
    }

    void ThreshholdState()
    {
        switch (threshholdLevel)
        {
            case 0: // Player has died, reset multibar to 0;
                {
                    break;
                }
            case 1: // from 0 to 1500 pts
                {
                    multibarLevelIndicator.SetText("x1");
                    multiplierField = 1;
                    if(current > 1500) 
                    { 
                        threshholdLevel = 2;  
                    }
                    min = 0;
                    max = 1500;
                    break;
                }
            case 2: // from 1500 to 4500 pts
                {
                    multibarLevelIndicator.SetText("x2");
                    multiplierField = 2;
                    if (current > 4500)
                    {
                        threshholdLevel = 3;
                    }
                    min = 1500;
                    max = 4500;
                    break;
                }
            case 3: // from 4500 to 9000 pts
                {
                    multibarLevelIndicator.SetText("x3");
                    multiplierField = 3;
                    if (current > 9000)
                    {
                        threshholdLevel = 4;
                    }
                    min = 4500;
                    max = 9000;
                    break;
                }
            case 4: // from 9000 to 15000 pts
                {
                    multibarLevelIndicator.SetText("x4");
                    multiplierField = 4;
                    min = 9000;
                    max = 15000;
                    if(current > 15000)
                    {
                        current = 15000;
                    }
                    break;
                }
            default:
                {
                    Debug.Log("An error has occurred, pls check ur switch statement in MULTIBARSCRIPT");
                    break;
                }
        }
    }

    //===============================================================
    // Updates the fill amount bar of the multibar.
    //===============================================================
    void GetCurrentFill()
    {
        float currentOffset = current - min;
        float maxOffset = max - min;
        float currentFillAmt = currentOffset / maxOffset;
        foreground.fillAmount = currentFillAmt;
    }
}
