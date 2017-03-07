using UnityEngine;
using System.Collections;

public interface IState
{

    void UpdateState();

    void ToGoUseState();

    void ToUseState();

    void ToWanderState();

}
