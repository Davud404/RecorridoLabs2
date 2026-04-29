using UnityEngine;
using System.Collections;

public class ElevatorDoors : MonoBehaviour
{
    [Header("Asignar Puertas")]
    public Transform leftOutsideDoor;
    public Transform rightOutsideDoor;
    public Transform leftInteriorDoor;
    public Transform rightInteriorDoor;

    [Header("Configuración de Apertura")]
    public float openDistance = 0.8f; // Cuántos metros se deslizan
    public float duration = 1.5f;     // Cuánto tarda en abrirse
    public float innerDelay = 0.3f;   // El retraso para las puertas interiores

    // Variables de estado
    private bool isOpen = false;
    private bool isMoving = false;
    private Vector3 leftOutStart, rightOutStart, leftInStart, rightInStart;

    void Start()
    {
        // Guardamos las posiciones originales (cerradas) de las 4 puertas al iniciar
        if(leftOutsideDoor) leftOutStart = leftOutsideDoor.localPosition;
        if(rightOutsideDoor) rightOutStart = rightOutsideDoor.localPosition;
        if(leftInteriorDoor) leftInStart = leftInteriorDoor.localPosition;
        if(rightInteriorDoor) rightInStart = rightInteriorDoor.localPosition;
    }

    public void ToggleDoors()
    {
        // Si ya se están moviendo, ignorar el clic para no romper la animación
        if (isMoving) return; 
        StartCoroutine(AnimateDoors(!isOpen));
    }

    IEnumerator AnimateDoors(bool opening)
    {
        isMoving = true;
        float elapsedTime = 0f;

        // Calculamos hacia dónde deben ir. 
        // IMPORTANTE: Mueve el eje Z
        Vector3 leftOffset = new Vector3(0, 0, openDistance);
        Vector3 rightOffset = new Vector3(0, 0, -openDistance);

        Vector3 targetLeftOut = opening ? leftOutStart + leftOffset : leftOutStart;
        Vector3 targetRightOut = opening ? rightOutStart + rightOffset : rightOutStart;
        Vector3 targetLeftIn = opening ? leftInStart + leftOffset : leftInStart;
        Vector3 targetRightIn = opening ? rightInStart + rightOffset : rightInStart;

        // Tomamos las posiciones desde donde están justo ahora
        Vector3 currentLeftOut = leftOutsideDoor.localPosition;
        Vector3 currentRightOut = rightOutsideDoor.localPosition;
        Vector3 currentLeftIn = leftInteriorDoor.localPosition;
        Vector3 currentRightIn = rightInteriorDoor.localPosition;

        while (elapsedTime < duration + innerDelay)
        {
            elapsedTime += Time.deltaTime;

            // 1. Mover las puertas exteriores (Arrancan de inmediato)
            float outProgress = Mathf.Clamp01(elapsedTime / duration);
            if (leftOutsideDoor) leftOutsideDoor.localPosition = Vector3.Lerp(currentLeftOut, targetLeftOut, outProgress);
            if (rightOutsideDoor) rightOutsideDoor.localPosition = Vector3.Lerp(currentRightOut, targetRightOut, outProgress);

            // 2. Mover las puertas interiores (Arrancan después del "innerDelay")
            float inProgress = Mathf.Clamp01((elapsedTime - innerDelay) / duration);
            if (elapsedTime >= innerDelay)
            {
                if (leftInteriorDoor) leftInteriorDoor.localPosition = Vector3.Lerp(currentLeftIn, targetLeftIn, inProgress);
                if (rightInteriorDoor) rightInteriorDoor.localPosition = Vector3.Lerp(currentRightIn, targetRightIn, inProgress);
            }

            yield return null;
        }

        isOpen = opening;
        isMoving = false;
    }
}