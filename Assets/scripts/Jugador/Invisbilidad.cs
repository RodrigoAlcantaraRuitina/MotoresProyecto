using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Invisbilidad : MonoBehaviour
{
    public int energia = 10;
    public bool indetectable = false; // Nueva variable

    private bool reduciendoEnergia = false;
    private bool energiaVacio = false;

    private SpriteRenderer spriteRenderer;
    private float originalAlpha;
    private Color originalColor;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalAlpha = spriteRenderer.color.a;
        originalColor = spriteRenderer.color;

        StartCoroutine(RegenerarEnergia());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && !reduciendoEnergia && energia > 0 && !energiaVacio)
        {
            StartCoroutine(RestarEnergia());
            StartCoroutine(ChangeOpacityTemporarily());
        }

        if (Input.GetKeyUp(KeyCode.C))
        {
            StopCoroutine(RestarEnergia());
            StopCoroutine(ChangeOpacityTemporarily());
            reduciendoEnergia = false;
            indetectable = false; // Desactiva indetectable cuando se suelta "C"
            StartCoroutine(ActivarEnergiaVacio());
            RestoreOpacity(); // Restaurar opacidad
        }
    }

    IEnumerator RestarEnergia()
    {
        reduciendoEnergia = true;
        indetectable = true; // Activa indetectable mientras se reduce energía

        while (Input.GetKey(KeyCode.C) && energia > 0)
        {
            energia = Mathf.Max(energia - 1, 0);
            Debug.Log("Energía restante: " + energia);
            yield return new WaitForSeconds(1f);
        }

        reduciendoEnergia = false;
        indetectable = false; // Desactiva indetectable si se acaba la energía
    }

    IEnumerator ActivarEnergiaVacio()
    {
        energiaVacio = true;
        yield return new WaitForSeconds(1f);
        energiaVacio = false;
    }

    IEnumerator RegenerarEnergia()
    {
        while (energia < 10) // Solo regenera cuando no está en su máximo
        {
            yield return new WaitForSeconds(1f);
            if (!reduciendoEnergia && !energiaVacio)
            {
                energia = Mathf.Min(energia + 1, 10);
                Debug.Log("Energía regenerada: " + energia);
            }
        }
    }

    IEnumerator ChangeOpacityTemporarily()
    {
        while (reduciendoEnergia)
        {
            SetSpriteOpacity(originalAlpha * 0.5f);
            SetSpriteColor(Color.green);
            yield return null;
        }
    }

    void RestoreOpacity()
    {
        SetSpriteOpacity(originalAlpha);
        SetSpriteColor(originalColor);
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

