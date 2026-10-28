
using UnityEngine;

public sealed class PlatformInfo : MonoBehaviour
{
    [SerializeField] private GameObject mobileControls;

    private void Start()
    {
        Debug.Log($"Platform={Application.platform}, Editor={Application.isEditor}");
        Debug.Log($"Version={Application.version}, Data={Application.dataPath}");
        Debug.Log($"Save={Application.persistentDataPath}");

        // 모바일과 Unity Editor에서는 터치 UI를 표시합니다.
        mobileControls.SetActive(
            Application.isMobilePlatform || Application.isEditor);
    }
}

