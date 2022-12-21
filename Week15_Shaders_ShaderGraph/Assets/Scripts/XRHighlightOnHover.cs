using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRHighlightOnHover : MonoBehaviour
{
    public Material hoverMaterial = null;

    XRBaseInteractable m_interactable = null;
    Renderer m_renderer = null;
    Material[] m_currentMaterials = null;

    void Awake()
    {
        m_renderer = GetComponent<Renderer>();
        m_interactable = GetComponent<XRBaseInteractable>();
    }

  
    private void OnEnable()
    {
        if(m_interactable != null)
        {
            m_interactable.hoverExited.AddListener(SwapInMaterial);
            m_interactable.hoverExited.AddListener(SwapOutMaterial);
        }
        Debug.Log("OnEnable");
    }

    private void SwapOutMaterial (HoverExitEventArgs arg0)
    {
        throw new NotImplementedException();
    }

    private void SwapInMaterial(HoverExitEventArgs arg0)
    {
        throw new NotImplementedException();
    }



    private void OnDisable()
    {
        if (m_interactable != null)
        {
            m_interactable.hoverExited.RemoveListener(SwapInMaterial);
            m_interactable.hoverExited.RemoveListener(SwapOutMaterial);
        }
        Debug.Log("OnDisable");
    }
    void SwapInMaterial(XRBaseInteractor interactor)
    {
        m_currentMaterials = m_renderer.materials;
        Material[] hoverMats = new Material[m_currentMaterials.Length];
        for(int i = 0; i < m_currentMaterials.Length; ++i)
        {
            hoverMats[i] = hoverMaterial;
        }
        m_renderer.materials = hoverMats;
        Debug.Log("SwapInMaterial)");
    }
    void SwapOutMaterial(XRBaseInteractor interactor)
    {
        m_renderer.materials = m_currentMaterials;
        m_currentMaterials = null;
        Debug.Log("SwapOutMaterial)");
    }
}
