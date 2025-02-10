using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine.InputSystem;

public class Invisbilidad : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private float originalAlpha;
    private Color originalColor;
    public bool indetectable;
    public bool puedeInvisibilidad;

    void Start()
    {
     puedeInvisibilidad = true;
     indetectable = false;
    spriteRenderer = GetComponent<SpriteRenderer>();
        originalAlpha = spriteRenderer.color.a; // Guarda la opacidad original
        originalColor = spriteRenderer.color;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && puedeInvisibilidad)
        {
            StartCoroutine(ChangeOpacityTemporarily());
        }
    }

    IEnumerator ChangeOpacityTemporarily()
    {
        puedeInvisibilidad = false;
        indetectable = true; // Activar estado indetectable
        // Reduce la opacidad en 50%
        SetSpriteOpacity(originalAlpha * 0.5f);
        SetSpriteColor(Color.green); // Cambiar a color verde

        // Espera 3 segundos
        yield return new WaitForSeconds(3f);

        // Restaura la opacidad original
        SetSpriteOpacity(originalAlpha);
        SetSpriteColor(originalColor); // Restaurar color original
        indetectable = false; // Desactivar estado indetectable
        // Espera 2 segundos adicionales antes de permitir reutilizar la habilidad
        yield return new WaitForSeconds(2f);
        puedeInvisibilidad = true; // Habilidad disponible nuevamente
    }

    void SetSpriteOpacity(float alpha)
    {
        Color newColor = spriteRenderer.color;
        newColor.a = alpha;
        spriteRenderer.color = newColor;
    }
    void SetSpriteColor(Color color)
    {
        spriteRenderer.color = color;
    }
}

