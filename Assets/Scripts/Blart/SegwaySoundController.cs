using UnityEngine;

public class SegwaySoundController : MonoBehaviour
{
  public AudioSource source;
  private float power = 0;
  private readonly float powerPerSecond = 1f;

  void Start()
  {
    source.volume = 0f;
    source.Play();
  }

  void Update()
  {
    UpdatePower(Input.GetAxis("Vertical"));
    source.volume = power;
    source.pitch = power * 3f;
  }

  private void UpdatePower(float input)
  {
    if (input == 0f || MallStateDTO.isPaused)
    {
      power -= powerPerSecond * Time.deltaTime;
    }
    else
    {
      power += powerPerSecond * Time.deltaTime;
    }
    power = Mathf.Clamp01(power);
  }
}
