using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    private int hitRemaining = 5;

    private SpriteRenderer spriteRenderer;
    public TextMesh text;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateVisualState();
    }

    private void UpdateVisualState()
    {
        text.text = hitRemaining.ToString();
        spriteRenderer.color = Color.Lerp(Color.white, Color.red, hitRemaining / 10f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        hitRemaining--;

        if (hitRemaining > 0)
        {
            UpdateVisualState();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    internal void setHits(int hits)
    {
        hitRemaining = hits;
        UpdateVisualState();
    }
}
