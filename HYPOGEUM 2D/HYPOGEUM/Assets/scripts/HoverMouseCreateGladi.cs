using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverMouseCreateGladi : MonoBehaviour
{
    bool isFilled;
    public int placettujenMaara;
    public GameObject indicator;
    public List<GladiatorStats> gladit;
    public GladiatorStats newIndicator;
    bool isCreated;
    GladiatorStats glad;
    // Start is called before the first frame update
    void Start()
    {
        foreach (var item in PlacementManager.instance.gladiators)
        {
            gladit.Add(item);
        }
        gladit = PlacementManager.instance.gladiators;
    }

    void OnMouseOver()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        if (PlacementManager.instance.placettujenMaara >= 4)
        {
            return;
        }
        else
        {
            if (!isFilled && (PlacementManager.instance.placettujenMaara < PlacementManager.instance.gladiators.Count))
            {
                if (!isCreated)
                {
                    var i = PlacementManager.instance.placettujenMaara;
                    //glad = Instantiate(gladit[i], gameObject.GetComponent<SpriteRenderer>().bounds.center, Quaternion.identity);
                    glad = gladit[i];
                    glad.transform.position = gameObject.GetComponent<SpriteRenderer>().bounds.center;
                    glad.gameObject.SetActive(true);
                    isCreated = true;
                }

                if (Input.GetMouseButtonUp(0))
                {
                    isFilled = true;
                    //Debug.Log(placettujenMaara);
                    Destroy(newIndicator);
                    var i = PlacementManager.instance.placettujenMaara;

                    //var placed = Instantiate(gladit[i], gameObject.GetComponent<SpriteRenderer>().bounds.center, Quaternion.identity);
                    var placed = gladit[i];
                    placed.transform.position = gameObject.GetComponent<SpriteRenderer>().bounds.center;
                    placed.gameObject.SetActive(true);
                    placed.GetComponent<CapsuleCollider>().enabled = true;
                    PlacementManager.instance.placettujenMaara += 1;
                    glad.targetPos = placed.transform.position;
                    if (PlacementManager.instance.placettujenMaara == 4)
                    {
                        GameObject.Find("placement").SetActive(false);
                    }

                    return;
                }


            }
        } 
    }
    void OnMouseExit()
    {
        isCreated = false;
        try
        {
            if (isFilled == false)
            {
                glad.gameObject.SetActive(false);
            }
        }
        catch
        {
            //catching error that does not affect performance or gameplay
        }
        
    }

}
