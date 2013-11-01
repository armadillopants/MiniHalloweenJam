using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class EventTrigger : MonoBehaviour
{
  public GameEvent Event;

  void OnTriggerEnter(Collider other)
  {
    if (other.transform.root.tag == "Player")
    {
      Event.Activate();
    }
  }
}