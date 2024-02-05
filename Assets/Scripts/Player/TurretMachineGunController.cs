using UnityEngine;
using UnityEngine.InputSystem;

public class TurretMachineGunController : MonoBehaviour
{
    [SerializeField]
    private GameObject _aim;
    [SerializeField]
    private GameObject _target;
    [SerializeField]

    public void OnSight(InputAction.CallbackContext context)
    {

    }

    public void OnShoot(InputAction.CallbackContext context) 
    {
        if(context.performed)
        {
            RaycastHit hit;
            Vector3 direction = _aim.transform.position - transform.position;
            if (Physics.Raycast(transform.position, direction, out hit, Mathf.Infinity))
            {
                Debug.Log("Did hit " + hit.transform.gameObject.name);
            }
        }
       
    }
}
