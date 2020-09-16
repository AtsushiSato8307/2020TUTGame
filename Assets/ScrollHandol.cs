using UnityEngine;
using System.Collections;
using UnityEngine.UI; // for Scrollbar

public class ScrollHandol : MonoBehaviour
{

    private void changeScrollBarValue(string scrollBarName, bool isUp)
    {
        GameObject work = GameObject.Find(scrollBarName);
        if (work)
        {
            float aRatio = work.GetComponent<Scrollbar>().value;
            if (isUp)
            {
                aRatio -= 0.05f; // for from top to bottom direction
            }
            else
            {
                aRatio += 0.05f; // for from top to bottom direction
            }
            work.GetComponent<Scrollbar>().value = aRatio;
        }
    }

    void OnGUI()
    {
        float val = Input.GetAxis("Mouse ScrollWheel");
        if (val > 0.0f)
        {
            changeScrollBarValue("Scrollbar1", /* isUp=*/false);
            //Debug.Log("up");
        }
        else if (val < 0.0f)
        {
            changeScrollBarValue("Scrollbar1", /* isUp=*/true);
            //Debug.Log("down");
        }
        else
        {
            // do nothing
        }
    }
}

