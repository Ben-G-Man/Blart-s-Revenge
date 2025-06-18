using UnityEngine;
public class ClosingAnimController : MonoBehaviour
{
  public static ClosingAnimController instance;
  public static bool readyToGo = false;

  public UnityEngine.UI.Image top;
  public UnityEngine.UI.Image bottom;
  public float travelDistance;
  public float moveSpeed;
  public float yCenter;
  public AudioClip shutterNoise;

  [HideInInspector]
  public bool animPlaying = false;

  private float animProgress = 0;
  private float targetAnimProgress = 1;

  void Start()
  {
    if (instance)
    {
      Debug.LogWarning("Warning! Multiple closing anim controllers in scene!");
    }
    else
    {
      instance = this;
    }

    instance.Open();
  }

  void Update()
  {
    top.transform.position = new Vector2(top.transform.position.x, yCenter + animProgress * travelDistance);
    bottom.transform.position = new Vector2(bottom.transform.position.x, yCenter - animProgress * travelDistance);

    if (animProgress > targetAnimProgress)
    {
      animProgress -= Time.deltaTime * moveSpeed;
      animProgress = Mathf.Clamp01(animProgress);
    }
    else if (animProgress < targetAnimProgress)
    {
      animProgress += Time.deltaTime * moveSpeed;
      animProgress = Mathf.Clamp01(animProgress);
    }
    else
    {
      animPlaying = false;
    }
  }

  public void Open()
  {
    PlayAnimHelper();
    targetAnimProgress = 1f;
  }

  public void Close()
  {
    PlayAnimHelper();
    targetAnimProgress = 0f;
  }

  private void PlayAnimHelper()
  {
    animPlaying = true;
    BlartSounds.instance.source.PlayOneShot(shutterNoise);
    UIController.CloseClipboard();
  }
}