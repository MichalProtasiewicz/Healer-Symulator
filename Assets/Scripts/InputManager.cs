using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    public Player player;

    public float rayLength;
    public LayerMask layerMask;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Transform selection = hit.transform;

                if (selection != null)
                {
                    if (selection.tag == "RaidMember")
                    {
                        if (player.focus != null)
                        {
                            player.focus.borderIndicator.color = Color.black;
                        }
                        player.focus = selection.gameObject.GetComponent<RaidMember>();
                        player.focus.borderIndicator.color = Color.yellow;
                    }
                    else if (selection.tag == "Spell")
                    {
                        //GlobalCD
                        if(Time.time > player.timeNextSpell)
                        {
                            player.spellSellected = selection.gameObject.GetComponent<Spells>();
                            player.CastSpell();
                        }
                    }
                }
            }
        }
    }
}
