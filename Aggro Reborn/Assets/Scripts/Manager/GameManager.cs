using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region singleton
    public static GameManager main { get; private set; }
    private void Awake()
    {
        if (main != null && main != this)
            Destroy(this);
        else
            main = this;
    }
    #endregion
    
    public StatsManager PlayerStats
    {
        get
        {
            if(_playerStats == null)
            {
                _playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<StatsManager>();
            }

            return _playerStats;
        }
    }
    private StatsManager _playerStats;

    public Transform Canvas
    {
        get
        {
            if (_canvas == null)
                _canvas = GameObject.FindGameObjectWithTag("Canvas").transform;

            return _canvas;
        }
    }
    private Transform _canvas;
}
