using UnityEngine;

public class GroundObject : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private GameObject _healthBar;
    private GroundObjectsCounter _groundObjectsCounter;
    private int _currHealth;

    private void Start()
    {
        _currHealth = _maxHealth;
        _groundObjectsCounter = gameObject.GetComponentInParent<GroundObjectsCounter>();
    }

    public void Damage()
    {      
        _currHealth -= 1;
        float hpRatio = (float) _currHealth / (float) _maxHealth;
        Debug.Log(hpRatio);
        if (_currHealth > 0)
        {
            _healthBar.transform.localScale = new Vector3(hpRatio, 1f);
        }
        if(_currHealth <= 0)
        {          
            if(gameObject.activeInHierarchy)
                _groundObjectsCounter.RemainingGroundObjectsNr -= 1;
            gameObject.SetActive(false);
        }
    }

    public bool IsActive()
    {
        if(gameObject.activeInHierarchy)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
