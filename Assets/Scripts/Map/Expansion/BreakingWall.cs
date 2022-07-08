using UnityEngine;

[RequireComponent(typeof(Animator))]
public class BreakingWall : MonoBehaviour, IBreakable
{
    [SerializeField] private Animator _wreck_anim;
    public void Break(Wall wall)
    {
        transform.SetPositionAndRotation(wall.transform.position, wall.transform.rotation);
        gameObject.SetActive(true);
        Instantiate(MapConfig.BrokenWall, transform.position, transform.rotation);
        Destroy(wall.gameObject); //wall.gameObject.SetActive(false);
        _wreck_anim.SetBool("wrecking", true);
        Invoke(nameof(RestoreAfterWrecking), 4f);
    }

    private void RestoreAfterWrecking()
    {
        gameObject.SetActive(false);
        _wreck_anim.SetBool("wrecking", false);
    }
}