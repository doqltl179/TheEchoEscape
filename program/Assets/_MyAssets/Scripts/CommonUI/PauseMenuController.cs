using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour {
    [SerializeField] private CanvasGroup canvasGroup;
    public CanvasGroup CanvasGroup { get { return canvasGroup; } }
    public float Alpha {
        get => canvasGroup.alpha;
        set => canvasGroup.alpha = value;
    }



    #region Action
    public void OnClickContinue() {
        SoundManager.Instance.PlayOneShot(SoundManager.SoundType.ButtonClick);

        UtilObjects.Instance.SetActivePauseMenu(false);
    }

    public void OnClickSettings() {
        SoundManager.Instance.PlayOneShot(SoundManager.SoundType.ButtonClick);

        UtilObjects.Instance.SetActiveSettings(true);
    }

    public void OnClickKeyGuide() {
        SoundManager.Instance.PlayOneShot(SoundManager.SoundType.ButtonClick);

        UtilObjects.Instance.SetActiveKeyGuide(true);
    }

    public void OnClickExit() {
        SoundManager.Instance.PlayOneShot(SoundManager.SoundType.ButtonClick);

        UtilObjects.Instance.InitConfirmNotice(
            "GoToMain",
            "No",
            () => {
                UtilObjects.Instance.SetActiveConfirmNotice(false);
            },
            "Yes",
            () => {
                SoundManager.Instance.StopBGM(SoundManager.SoundType.Game, 0.5f);

                SceneLoader.Instance.LoadScene(SceneLoader.SceneType.Main);

                UtilObjects.Instance.ResetPages();
            });
        UtilObjects.Instance.SetActiveConfirmNotice(true);
    }
    #endregion
}
