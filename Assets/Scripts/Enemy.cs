using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public float StunDuration = 2.0f;

    private bool _isStunned = false;
    private PlayerHealthManager _playerHealth;
    private LifeGridController _lifeGrid;
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && _playerHealth.NumOfLives > 0 && Time.time > _playerHealth.LastTimeHit)
        {
            _playerHealth.NumOfLives--;
            _lifeGrid.RefreshLifeImages(_playerHealth.NumOfLives);
            Debug.Log(_playerHealth.NumOfLives.ToString());
            _playerHealth.LastTimeHit = Time.time + 1;
        }
        
        if (_playerHealth.NumOfLives < 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void Awake()
    {
        _playerHealth = GameObject.FindWithTag("Player").GetComponent<PlayerHealthManager>();
        _lifeGrid = GameObject.FindWithTag("LifeGrid").GetComponent<LifeGridController>();
    }

    private void ChangeLayer(int newLayer)
    {
        gameObject.layer = newLayer;

        //prolazimo kroz svu djecu ovog objekta
        foreach (Transform child in transform)
        {
            child.gameObject.layer = newLayer;
        }
    }

    public void ToggleStun(bool newIsStunned)
    {
        if (newIsStunned == _isStunned)
            return;

        _isStunned = newIsStunned;
        GetComponentInParent<EnemyMover> ().IsStunned = _isStunned;

        if (_isStunned)
        {
           ChangeLayer(LayerMask.NameToLayer("Stunned"));
            Invoke("DisableStun", StunDuration);
        }
    }
    private void DisableStun()
    {
        ChangeLayer(LayerMask.NameToLayer("Enemy"));
        ToggleStun(false);
    }
}
