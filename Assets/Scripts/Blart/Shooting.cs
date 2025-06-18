using UnityEngine;

public class Shooting : MonoBehaviour
{
  [Header("Shooting")]
  public Transform fireOrigin;
  public float shootingDistance = 100f;

  [Header("Effects")]
  public GameObject muzzleFlashPrefab;
  public GameObject smokeQuadPrefab;
  public AudioSource fireSoundSource;
  public AudioClip fireSound;
  public float smokeLifetime = 0.5f;
  public float smokeFadeTime = 0.4f;
  void Update()
  {
    if (Input.GetMouseButtonDown(0) && !MallStateDTO.isPaused)
    {
      Shoot();
    }
  }

  void Shoot()
  {
    if (fireSoundSource && fireSound)
    {
      fireSoundSource.PlayOneShot(fireSound);
    }
    else
    {
      Debug.LogError("NO FIRING SOUND");
    }

    if (fireOrigin == null)
    {
      Debug.LogWarning("Fire Origin not assigned!");
      return;
    }

    // Raycast forward
    Ray ray = new Ray(fireOrigin.position, fireOrigin.forward);
    Vector3 hitPoint;
    if (Physics.Raycast(ray, out RaycastHit hit, shootingDistance))
    {
      hitPoint = hit.point;
      // Hit fella
      if (hit.transform.gameObject.TryGetComponent<CheckShooted>(out CheckShooted c))
      {
        c.SetShooted();
      }
    }
    else
    {
      hitPoint = fireOrigin.position + fireOrigin.forward * shootingDistance;
    }

    if (muzzleFlashPrefab)
    {
      GameObject flash = Instantiate(muzzleFlashPrefab, fireOrigin.transform.position, fireOrigin.transform.rotation);
      Destroy(flash, 0.1f);
    }

    if (smokeQuadPrefab)
    {
      GameObject smoke = Instantiate(smokeQuadPrefab);
      LineRenderer rend = smoke.GetComponent<LineRenderer>();
      rend.positionCount = 2;
      rend.SetPosition(0, fireOrigin.transform.position);
      rend.SetPosition(1, hitPoint);

      SmokeFadeQuad fader = smoke.AddComponent<SmokeFadeQuad>();
      fader.Init(smokeLifetime, smokeFadeTime);
    }
  }
}
