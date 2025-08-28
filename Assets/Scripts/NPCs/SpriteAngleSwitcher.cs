using UnityEngine;

public class SpriteAngleSwitcher : MonoBehaviour
{
  public Sprite[] directionalSprites;
  public Transform cameraTransform;
  public SpriteRenderer spriteRenderer;
  public int directionCount = 4;

  void Update()
  {
    spriteRenderer.transform.forward = cameraTransform.forward;

    Vector3 toCamera = cameraTransform.position - transform.position;

    toCamera.y = 0;
    toCamera.Normalize();

    Vector3 forward = transform.forward;
    forward.y = 0;
    forward.Normalize();

    // Calculate signed angle
    float angle = Vector3.SignedAngle(forward, toCamera, Vector3.up);
    if (angle < 0) angle += 360f;

    float sectorSize = 360f / directionCount;
    int index = Mathf.FloorToInt(angle / sectorSize) % directionCount;

    spriteRenderer.sprite = directionalSprites[index];
  }
}
