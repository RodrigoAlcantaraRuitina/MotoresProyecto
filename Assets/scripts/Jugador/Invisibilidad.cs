using TMPro.Examples;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
public class Invisibilidad : MonoBehaviour
{
    public Image StaminaBar;

    public float Stamina, MaxStamina = 100;
    public float staminaConsume = 20f; // Energía consumida por segundo
    public float ChargeRate = 10f; // Velocidad de regeneración por segundo

    private Coroutine recharge;
    public bool indetectable { get; private set; }

    void Start()
    {
        Stamina = MaxStamina; // Inicializa la estamina al máximo
    }

    void Update()
    {
        if (Input.GetMouseButton(1)) // Consumo de estamina
        {
            if (recharge != null) // Si se estaba recargando, detén la corrutina
            {
                StopCoroutine(recharge);
                recharge = null;
            }
            indetectable = true; // Mientras se presiona "f", la variable es true

            Stamina -= staminaConsume * Time.deltaTime;
            Stamina = Mathf.Clamp(Stamina, 0, MaxStamina);
            StaminaBar.fillAmount = Stamina / MaxStamina;
        }
        else if (Stamina < MaxStamina && recharge == null) // Si no está presionando y falta estamina
        {

            indetectable = false;

            recharge = StartCoroutine(RechargeStamina());
        }
    }

    private IEnumerator RechargeStamina()
    {
        yield return new WaitForSeconds(1f); // Espera antes de comenzar la regeneración

        while (Stamina < MaxStamina)
        {
            Stamina += ChargeRate * Time.deltaTime; // Regeneración progresiva
            Stamina = Mathf.Clamp(Stamina, 0, MaxStamina);
            StaminaBar.fillAmount = Stamina / MaxStamina;
            yield return null; // Hace la regeneración más fluida
        }

        recharge = null; // Indica que la recarga terminó
    }
}
