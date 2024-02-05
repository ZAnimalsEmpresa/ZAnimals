using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class ManagementUnitController : MonoBehaviour
{
    [Header("Configuration")]
    [SerializeField]
    private GameObject _unitFirstSlot;
    [SerializeField]
    private GameObject _unitSecondSlot;
    [SerializeField]
    private GameObject _unitThirdSlot;

    private GameObject _currentSpawnPoint;

    public void OnUnitDeplymentFirstSlot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Spawn Unit 1");
            DeployUnit(_unitFirstSlot);
        }
    }

    public void OnUnitDeplymentSecondSlot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Spawn Unit 2");
            DeployUnit(_unitSecondSlot);
        }
    }

    public void OnUnitDeplymentThirdSlot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Spawn Unit 3");
            DeployUnit(_unitThirdSlot);
        }
    }
    public void SetSpawnPoint(GameObject spawnObject)
    {
        _currentSpawnPoint = spawnObject;
    }
    private void DeployUnit(GameObject unit)
    {
        Vector3 sPoint = GetRandomPointInSquareCollider();
        Instantiate(unit, _currentSpawnPoint.transform.position, Quaternion.identity);
        //Instantiate(unit, _currentSpawnPoint.transform.position,Quaternion.identity);
    }
    // Method to get a random point within the collider's bounds
    private Vector3 GetRandomPointInSquareCollider()
    {
        // Get the collider component from the specified GameObject
        BoxCollider squareCollider = _currentSpawnPoint.GetComponent<BoxCollider>();

        // Check if the object has a BoxCollider attached
        if (squareCollider == null)
        {
            Debug.LogError("The specified GameObject does not have a BoxCollider attached.");
            return Vector3.zero;
        }

        // Get the collider's position and size
        Vector3 colliderCenter = _currentSpawnPoint.transform.position;
        Vector3 colliderSize = squareCollider.size;

        // Calculate the square's bounds
        float minX = colliderCenter.x - colliderSize.x / 2;
        float maxX = colliderCenter.x + colliderSize.x / 2;
        float minY = colliderCenter.y - colliderSize.y / 2;
        float maxY = colliderCenter.y + colliderSize.y / 2;

        // Generate a random point within those bounds
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        Vector3 randomPoint = new Vector3(randomX, 0, randomY); // If the Collider is in the XY plane (2D)

        return randomPoint;
    }
}
