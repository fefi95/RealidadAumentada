/*==============================================================================
Copyright (c) 2013-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Qualcomm Connected Experiences, Inc.
==============================================================================*/


using UnityEngine;
using Vuforia;

/// <summary>
/// A default event handler that handles reconstruction events for a ReconstructionFromTarget
/// It uses a single Prop template that is used for every newly created prop, 
/// and a surface template that is used for the primary surface
/// </summary>
public class SmartTerrainEventHandler : MonoBehaviour
{
    #region PRIVATE_MEMBERS

    private ReconstructionBehaviour mReconstructionBehaviour;
    

    #endregion // PRIVATE_MEMBERS


    #region PUBLIC_MEMBERS

    public PropBehaviour PropTemplate;
    public PropBehaviour PropTemplate2;
    public SurfaceBehaviour SurfaceTemplate;
    
    #endregion // PUBLIC_MEMBERS



    #region UNTIY_MONOBEHAVIOUR_METHODS

    void Start()
    {
        mReconstructionBehaviour = GetComponent<ReconstructionBehaviour>();
        if (mReconstructionBehaviour)
        {
            mReconstructionBehaviour.RegisterPropCreatedCallback(OnPropCreated);
            mReconstructionBehaviour.RegisterSurfaceCreatedCallback(OnSurfaceCreated);
            mReconstructionBehaviour.RegisterPropUpdatedCallback(OnPropUpdated);
        }
    }

    void OnDestroy()
    {
        if (mReconstructionBehaviour)
        {
            mReconstructionBehaviour.UnregisterPropCreatedCallback(OnPropCreated);
            mReconstructionBehaviour.UnregisterSurfaceCreatedCallback(OnSurfaceCreated);
            mReconstructionBehaviour.UnregisterPropUpdatedCallback(OnPropUpdated);
        }
    }

    #endregion // UNTIY_MONOBEHAVIOUR_METHODS



    #region RECONSTRUCTION_CALLBACKS

    /// <summary>
    /// Called when a prop has been created
    /// </summary>
    public void OnPropCreated(Prop prop)
    {
        if (mReconstructionBehaviour)
        {
            if (prop.LocalPosition.y < 0)
            {
                mReconstructionBehaviour.AssociateProp(PropTemplate2, prop);
            }
            else
            {
                mReconstructionBehaviour.AssociateProp(PropTemplate, prop);
            }

            PropAbstractBehaviour behaviour;
            if (mReconstructionBehaviour.TryGetPropBehaviour(prop, out behaviour))
            {
                behaviour.gameObject.name = "Prop " + prop.ID;
            }

        }
    }

    /// <summary>
    /// Called when a prop has been updated
    /// </summary>
    public void OnPropUpdated(Prop prop)
    {
        if (mReconstructionBehaviour)
        {
            PropAbstractBehaviour behaviour;
            if (mReconstructionBehaviour.TryGetPropBehaviour(prop, out behaviour))
            {
                Transform BoundingBox = behaviour.transform.FindChild("BoundingBoxCollider");
                BoxCollider collider = BoundingBox.GetComponent<BoxCollider>();
                Transform Mountain = behaviour.transform.FindChild("mountain");
                //Mountain.Translate(new Vector3(prop.LocalPosition.x/2, 0, prop.LocalPosition.z/2));
                Mountain.position = new Vector3(prop.BoundingBox.Center.x, 0, prop.BoundingBox.Center.z);
                Mountain.localScale = collider.bounds.size;
            }

        }
    }

    /// <summary>
    /// Called when a surface has been created
    /// </summary>
    public void OnSurfaceCreated(Surface surface)
    {
        if (mReconstructionBehaviour)
        {
            mReconstructionBehaviour.AssociateSurface(SurfaceTemplate, surface);
            SurfaceAbstractBehaviour behaviour;
            if (mReconstructionBehaviour.TryGetSurfaceBehaviour(surface, out behaviour))
            {
                behaviour.gameObject.name = "Surface " + surface.ID;
            }
            //GlobalVariables.JuegoEnCurso = true;
            //print("ahhhhhh" + GlobalVariables.JuegoEnCurso);
        }
    }

    #endregion // RECONSTRUCTION_CALLBACKS

    #region PUBLIC_METHODS

    public void ShowPropClones()
    {
        mReconstructionBehaviour.Reconstruction.Stop();
        PropAbstractBehaviour[] props = GameObject.FindObjectsOfType(typeof(PropAbstractBehaviour)) as PropAbstractBehaviour[];

        foreach (PropAbstractBehaviour prop in props)
        {
            Transform BoundingBox = prop.transform.FindChild("BoundingBoxCollider");
            BoxCollider collider = BoundingBox.GetComponent<BoxCollider>();
            //collider.isTrigger = false;
            Destroy(BoundingBox);
            
            prop.SetAutomaticUpdatesDisabled(true);
            Renderer propRenderer = prop.GetComponent<MeshRenderer>();
            if (propRenderer != null)
            {
                Destroy(propRenderer);
            }
        }
        GlobalVariables.ActiveSmartTerrain = true;
    }
    #endregion
}