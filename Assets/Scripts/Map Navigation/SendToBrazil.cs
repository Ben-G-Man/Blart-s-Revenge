using System;
using System.Collections;
using UnityEngine;

public class SendToBrazil : MonoBehaviour
{
  public GameObject blart;
  public GameObject blartHouse;
  public GameObject breakRoom;
  public GameObject atrium;

  private bool trySend = false;

  private MallStateDTO.Phase phase = MallStateDTO.Phase.START;

  void Update()
  {
    CheckPhase();
    CheckSend();
  }

  private void CheckPhase()
  {
    MallStateDTO.Phase newPhase = MallStateDTO.GetPhase();
    if (newPhase != phase)
    {
      phase = newPhase;
      ClosingAnimController.instance.Close();
      trySend = true;
      Debug.Log("BLARTING TO " + newPhase + "!");
    }
  }

  private void CheckSend()
  {
    if (trySend)
    {
      switch (phase)
      {
        case MallStateDTO.Phase.FIRST_SHIFT:
          TrySend(atrium);
          break;

        case MallStateDTO.Phase.SECOND_SHIFT:
          TrySend(atrium);
          break;

        case MallStateDTO.Phase.BLART_O_CLOCK:
          TrySend(blartHouse);
          break;

        case MallStateDTO.Phase.LUNCH_BREAK:
          TrySend(breakRoom);
          break;
      }
    }
  }

  private void TrySend(GameObject brazil)
  {
    if (ClosingAnimController.instance.animPlaying == false)
    {
      trySend = false;
      Teleport(brazil);
      Invoke("PlayOpenAnim", 1);
    }
  }

  private void PlayOpenAnim()
  {
    ClosingAnimController.instance.Open();
  }

  public void Teleport(GameObject brazil)
  {
    Rigidbody blartRb = blart.GetComponent<Rigidbody>();

    if (blartRb)
    {
      blartRb.velocity = Vector3.zero;
      blartRb.angularVelocity = Vector3.zero;
      blartRb.position = brazil.transform.position;
      blartRb.rotation = brazil.transform.rotation;
      blartRb.MovePosition(brazil.transform.position);
    }
    else
    {
      Debug.LogWarning("Warning! Blart has no rigidbody!");
    }
  }
}
