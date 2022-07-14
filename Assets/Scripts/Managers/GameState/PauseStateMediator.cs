using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PauseStateMediator
{
    private readonly GameStateSwitcher _stateSwitcher;
    public PauseStateMediator(GameStateSwitcher stateSwitcher, Button pause, Button resume)
    {
        _stateSwitcher = stateSwitcher;
        pause.onClick.AddListener(_stateSwitcher.SetPause);
        resume.onClick.AddListener(_stateSwitcher.Resume);
    }
}
