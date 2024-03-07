using UnityEngine;


public class TorretaBaseBehaviour : MonoBehaviour
{
    private UnitScript _unitScript;

    private UnitContext _unitContext;

    public Transform _modeloTorreta; 



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Vector3 directionToEnemy = other.transform.position - transform.position;
            directionToEnemy.y = 0; 

            Quaternion rotationToEnemy = Quaternion.LookRotation(directionToEnemy);

            _modeloTorreta.rotation = Quaternion.Euler(0, rotationToEnemy.eulerAngles.y, 0);

            _unitContext.SetStrategy(new TorretaAttackStrategy(_unitScript.gameObject, other.gameObject));
            _unitContext.ExecuteStrategy();
        }
    }
}
