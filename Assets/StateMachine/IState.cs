using UnityEngine;
using System.Collections;

public interface IState
{

    void UpdateState();

    void ToGoSleepState();

    void ToSleepState();

    void ToGoOutState();

    void ToOutState();

    void ToGoUseState();

    void ToUseState();

}
