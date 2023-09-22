using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.XR.Management;
#else
using UnityEngine.XR.Management;
#endif

namespace Unity.Template.MR
{
    internal class XRPlatformControllerSetup : MonoBehaviour
    {
        [SerializeField]
        GameObject m_LeftController;

        [SerializeField]
        GameObject m_RightController;
        
        [SerializeField]
        GameObject m_LeftControllerOculusPackage;

        [SerializeField]
        GameObject m_RightControllerOculusPackage;

        void Start()
        {
#if UNITY_EDITOR
            var loaders = XRGeneralSettingsPerBuildTarget.XRGeneralSettingsForBuildTarget(BuildTargetGroup.Standalone).Manager.activeLoaders;
#else
            var loaders = XRGeneralSettings.Instance.Manager.activeLoaders;
#endif
            
            foreach (var loader in loaders)
            {
                if (loader.name.Equals("Oculus Loader"))
                {
                    m_RightController.SetActive(false);
                    m_LeftController.SetActive(false);
                    m_RightControllerOculusPackage.SetActive(true);
                    m_LeftControllerOculusPackage.SetActive(true);
                }
            }
        }
    }
}
