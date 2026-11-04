using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(Button))]
public class NavigationButton : MonoBehaviour
{
    public Scenes scene;

    [Inject]
    ScenesController scenesController;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => scenesController.LoadScene(scene));
    }
}
