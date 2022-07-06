using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(CreateStatList))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private StatsManager StatsManager => GetComponent<StatsManager>();

    private Dictionary<KeyCode, bool> ButtonsActive = new Dictionary<KeyCode, bool>(4);

    private float MovementSpeed 
    { 
        get 
        { 
            return StatsManager.GetStatValue(EStatsType.MovementSpeed); 
        } 
    }
    private bool IsStuned
    {
        get
        {
            return StatsManager.IsUnderEffect(EEffectType.Stuned);
        }
    }
    private bool IsSlowed
    {
        get
        {
            return StatsManager.IsUnderEffect(EEffectType.Slowed);
        }
    }

    private void Setup()
    {
        ButtonsActive.Add(KeyCode.W, false);
        ButtonsActive.Add(KeyCode.S, false);
        ButtonsActive.Add(KeyCode.A, false);
        ButtonsActive.Add(KeyCode.D, false);
    }

    void Start()
    {
        Setup();
    }
    void Update()
    {
        Movement();
    }
    private void Movement()
    {
        if (MovementSpeed <= 0)
            return;

        Vector2 movement = Vector2.zero;

        CheckKey(KeyCode.W, KeyCode.S);
        CheckKey(KeyCode.A, KeyCode.D);

        movement.x = ButtonsActive[KeyCode.D] ? 1 : (ButtonsActive[KeyCode.A] ? -1 : 0);
        movement.y = ButtonsActive[KeyCode.W] ? 1 : (ButtonsActive[KeyCode.S] ? -1 : 0);

        if (IsStuned)
            return;

        if (movement.x != 0 && movement.y != 0)
            movement *= MovementSpeed / Mathf.Sqrt(2) * Time.deltaTime;
        else
            movement *= MovementSpeed * Time.deltaTime;

        if (IsSlowed)
            movement /= 2;

        transform.position = new Vector2(transform.position.x + movement.x, transform.position.y + movement.y);
    }
    private void CheckKey(KeyCode main, KeyCode opposite)
    {
        if (Input.GetKeyDown(main))
        {
            ButtonsActive[main] = true;
            ButtonsActive[opposite] = false;
        }
        if (Input.GetKeyDown(opposite))
        {
            ButtonsActive[opposite] = true;
            ButtonsActive[main] = false;
        }

        if (Input.GetKeyUp(main))
        {
            if (Input.GetKey(opposite))
            {
                ButtonsActive[opposite] = true;
            }
            ButtonsActive[main] = false;
        }

        if (Input.GetKeyUp(opposite))
        {
            if (Input.GetKey(main))
            {
                ButtonsActive[main] = true;
            }
            ButtonsActive[opposite] = false;
        }
    }
}