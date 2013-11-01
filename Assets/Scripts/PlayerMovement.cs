using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
  [System.Serializable]
  public class PlayerSpeed
  {
    public float BaseSpeed;
    public float RunMultiplier;
  }

  [System.Serializable]
  public class PlayerRun
  {
    public float MaxRunTime;
    public float CurrentRunStamina;
    public float RunRegenSpeed;
    public float RunRegenDelay;
    public bool IsRunning;
    private float LastRunTime = 0f;

    public void TryRunning()
    {
      if (CurrentRunStamina > 0f && Input.GetKey(KeyCode.LeftShift))
      {
        IsRunning = true;
        CurrentRunStamina -= Time.fixedDeltaTime;
      }
      else
      {
        if (IsRunning)
        {
          LastRunTime = Time.time;
        }
        IsRunning = false;
        if (RunRegenDelay < Time.time - LastRunTime)
        {
          CurrentRunStamina += RunRegenSpeed * Time.fixedDeltaTime;
          CurrentRunStamina = Mathf.Min(CurrentRunStamina, MaxRunTime);
        }
      }
    }
  }

  public PlayerSpeed speed;
  public PlayerRun run;
  private CharacterController controller;

  void Start()
  {
    controller = gameObject.GetComponent<CharacterController>();
  }

  void FixedUpdate()
  {
    if (Time.timeScale == 0)
    {
      return;
    }

    run.TryRunning();

    Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    move = transform.TransformDirection(move);
    

    if (run.IsRunning)
    {
      move *= (speed.BaseSpeed * speed.RunMultiplier * Time.fixedDeltaTime);
    }
    else
    {
      move *= (speed.BaseSpeed * Time.fixedDeltaTime);
    }

    move.y = -9.81f * Time.fixedDeltaTime;
    controller.Move(move);
  }
}