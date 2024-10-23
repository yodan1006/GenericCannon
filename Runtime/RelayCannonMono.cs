using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RelayCannonMono : MonoBehaviour
{
    [Range(-1, 1)]
    [SerializeField] float m_percentHorizontalAxis;
    [Range(-1, 1)]
    [SerializeField] float m_percentVerticalAxis;

    public UnityEvent<float> m_onHorizontalChanged;
    public UnityEvent<float> m_onVerticalChanged;
    public UnityEvent m_onFireRequested;


    [ContextMenu("Test Random Input")]
    public void TestRandomInput() {

        SetCannonHorizontalPercent11(Random.value);
        SetCannonVerticalPercent11(Random.value);
    }

    public void SetCannonHorizontalPercent11(float percent)
    {
        percent = Mathf.Clamp(percent, -1f, 1f);
        if (percent != m_percentHorizontalAxis) {

            m_percentHorizontalAxis = percent;
            m_onHorizontalChanged.Invoke(percent);
        }
    }
    public void SetCannonVerticalPercent11(float percent)
    {
        percent = Mathf.Clamp(percent, -1f, 1f);
        if (percent != m_percentVerticalAxis)
        {

            m_percentVerticalAxis = percent;
            m_onVerticalChanged.Invoke(percent);
        }
    }

    public void FireBulletWithCannon() {
        m_onFireRequested.Invoke();
    }


}
