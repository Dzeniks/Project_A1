#if UNITY_ANDROID
using System;
using UnityEngine;

namespace Unity.Services.Mediation.Platform
{
    class AndroidInitializationListener : AndroidJavaProxy, IAndroidInitializationListener
    {
        IAndroidInitializationListener m_Listener;
        public AndroidInitializationListener(IAndroidInitializationListener listener) : base("com.unity3d.mediation.IInitializationListener")
        {
            m_Listener = listener;
        }

        public void onInitializationComplete()
        {
            ThreadUtil.Post(state => m_Listener.onInitializationComplete());
        }

        public void onInitializationFailed(AndroidJavaObject errorCode, String msg)
        {
            ThreadUtil.Post(state => m_Listener.onInitializationFailed(errorCode, msg));
        }
    }
}
#endif
