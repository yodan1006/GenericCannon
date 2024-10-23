using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class ShootInput : MonoBehaviour
{
    public InputActionReference m_whatToListenForShoot; // R�f�rence � l'InputAction
    public UnityEvent<bool> m_onShoot; // L'�v�nement Unity qui sera d�clench�

    private void OnEnable()
    {
        // On s'assure que l'InputAction soit activ�e
        m_whatToListenForShoot.action.Enable();
        // On s'abonne � l'�v�nement performed (quand l'input est d�clench�)
        m_whatToListenForShoot.action.performed += OnShootPerformed;
        // On s'abonne � l'�v�nement canceled (quand l'input est rel�ch�)
        m_whatToListenForShoot.action.canceled += OnShootCanceled;
    }

    private void OnDisable()
    {
        // On d�sactive les �v�nements pour �viter des erreurs
        m_whatToListenForShoot.action.performed -= OnShootPerformed;
        m_whatToListenForShoot.action.canceled -= OnShootCanceled;
        m_whatToListenForShoot.action.Disable();
    }

    // M�thode appel�e quand l'input est d�clench�
    private void OnShootPerformed(InputAction.CallbackContext context)
    {
        m_onShoot.Invoke(true); // On invoque l'�v�nement avec "true" pour signaler le tir
    }

    // M�thode appel�e quand l'input est rel�ch�
    private void OnShootCanceled(InputAction.CallbackContext context)
    {
        m_onShoot.Invoke(false); // On invoque l'�v�nement avec "false" pour signaler l'arr�t du tir
    }
}
