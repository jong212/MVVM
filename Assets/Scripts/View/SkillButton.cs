using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillButton : MonoBehaviour
{
  public void OnClick_LevelUpDouble()
    {
        GameLogicManager.Inst.RequestLevelUpDouble();
    }
}
