using UnityEngine;

public class InputManager : MonoBehaviour
{
    public float rayLength;
    public Player player;
    public LayerMask layerMask;

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
                            player.focus.borderIndicator.color = Color.black;
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
