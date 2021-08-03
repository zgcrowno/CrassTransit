using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script allows the portals to be linked, causing the player to transport from one to the other
/// </summary>
public class Portal : MonoBehaviour
{
    [Tooltip("What portal should this one link to?")]
    public Portal linkedPortal;
    [Tooltip("What color should this portal be? At runtime linked portals will match their colors...")]
    public PortalColor color;

    private bool exiting = false;

    private void Awake()
    {
        if (linkedPortal == null)
        {
            Debug.LogError("This portal: " + name + " is unlinked to another portal!");
            return;
        }
        linkedPortal.color = this.color;
    }

    private void Start()
    {
        transform.Find("Background").GetComponent<SpriteRenderer>().color = colorDict[color];
        var colorOverLifetime = transform.Find("Background").Find("PortalFX").GetComponent<ParticleSystem>().colorOverLifetime;

        Gradient gradient = new Gradient();
        gradient.SetKeys(new GradientColorKey[] { new GradientColorKey(colorDict[color], 0.0f) }, new GradientAlphaKey[] { new GradientAlphaKey(1f, 0f), new GradientAlphaKey(0f, 1f) });
        colorOverLifetime.color = gradient;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!exiting && collision.CompareTag("Player"))
        {
            TriggerWarp(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            exiting = false;
        }
    }

    /// <summary>
    /// Called on the portal the player touches first, tells the other portal what to do
    /// </summary>
    private void TriggerWarp(GameObject player)
    {
        linkedPortal.WarpToMe(player);
    }

    /// <summary>
    /// This is the function that brings the player to this portal. Called on the linked portal that wasn't first activated
    /// </summary>
    private void WarpToMe(GameObject player)
    {
        exiting = true;
        //Rigidbody2D playerRB = player.GetComponent<Rigidbody2D>();
        //Vector2 rbVelocity = playerRB.velocity;

        player.transform.position = this.transform.position;
        //playerRB.velocity = Vector2.zero;

        //playerRB.AddForce(playerRB.mass * rbVelocity, ForceMode2D.Impulse);
    }

    public enum PortalColor
    {
        red,
        green,
        blue,
        yellow,
        cyan,
        magenta
    }

    public Dictionary<PortalColor, Color> colorDict = new Dictionary<PortalColor, Color>()
    {
        { PortalColor.red, new Color(1, 0, 0, 0.5f) },
        { PortalColor.green, new Color(0, 1, 0, 0.5f) },
        { PortalColor.blue, new Color(0, 0, 1, 0.5f) },
        { PortalColor.yellow, new Color(1, 1, 0, 0.5f) },
        { PortalColor.cyan, new Color(0, 1, 1, 0.5f) },
        { PortalColor.magenta, new Color(1, 0, 1, 0.5f) }
    };

    public Dictionary<PortalColor, Color> transparentDict = new Dictionary<PortalColor, Color>()
    {
        { PortalColor.red, new Color(1, 0, 0, 0f) },
        { PortalColor.green, new Color(0, 1, 0, 0f) },
        { PortalColor.blue, new Color(0, 0, 1, 0f) },
        { PortalColor.yellow, new Color(1, 1, 0, 0f) },
        { PortalColor.cyan, new Color(0, 1, 1, 0f) },
        { PortalColor.magenta, new Color(1, 0, 1, 0f) }
    };

}
