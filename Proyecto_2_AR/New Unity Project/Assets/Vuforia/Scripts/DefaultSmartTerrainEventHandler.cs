/*==============================================================================
Copyright (c) 2013-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Protected under copyright and other laws.
==============================================================================*/


using UnityEngine;

namespace Vuforia
{
    /// <summary>
    /// A default event handler that handles reconstruction events for a ReconstructionFromTarget
    /// It uses a single Prop template that is used for every newly created prop, 
    /// and a surface template that is used for the primary surface
    /// </summary>
    public class DefaultSmartTerrainEventHandler : MonoBehaviour
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
            }
        }

        void OnDestroy()
        {
            if (mReconstructionBehaviour)
            {
                mReconstructionBehaviour.UnregisterPropCreatedCallback(OnPropCreated);
                mReconstructionBehaviour.UnregisterSurfaceCreatedCallback(OnSurfaceCreated);
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
                Debug.Log("---Created Smart Terrain Prop");
                //if (prop.LocalPosition.y < 0)
                if (prop.BoundingBox.HalfExtents.y > 2)
                {
                    Debug.Log("PropTemplate");
                    mReconstructionBehaviour.AssociateProp(PropTemplate, prop);
                }
                else
                {
                    Debug.Log("PropTemplate2");
                    mReconstructionBehaviour.AssociateProp(PropTemplate2, prop);
                }
            }
                
        }

        /// <summary>
        /// Called when a surface has been created
        /// </summary>
        public void OnSurfaceCreated(Surface surface)
        {
            if (mReconstructionBehaviour)
                mReconstructionBehaviour.AssociateSurface(SurfaceTemplate, surface);
        }

        #endregion // RECONSTRUCTION_CALLBACKS
    }
}



