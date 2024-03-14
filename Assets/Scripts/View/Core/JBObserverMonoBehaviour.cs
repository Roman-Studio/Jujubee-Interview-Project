using System.Collections;
using NaughtyAttributes;
using UnityEngine;

namespace Jujubee.View.Core
{
    public abstract class JBObserverMonoBehaviour<TObservedType> : JBObserverMonoBehaviour
    {
        [field: SerializeField, ReadOnly]
        public TObservedType ObservedObject { get; protected set; }

        public virtual void Set(TObservedType newObservedObject)
        {
            if (Equals(ObservedObject, newObservedObject))
            {
                return;
            }
            
            if (ObservedObject != null)
            {
                UnregisterEvents();
            }

            ObservedObject = newObservedObject;
            OnReactToChanges();
            RegisterEvents();
        }

        protected virtual void OnDestroy()
        {
            if (ObservedObject != null)
            {
                UnregisterEvents();
            }
        }

        protected abstract void RegisterEvents();
        protected abstract void UnregisterEvents();
    }

    public abstract class JBObserverMonoBehaviour : MonoBehaviour
    {
        protected bool RequestedUpdateInThisFrame;
        
        protected virtual void OnDisable()
        {
            RequestedUpdateInThisFrame = false;
        }
        
        protected void ReactToChanges()
        {
            if (RequestedUpdateInThisFrame)
            {
                return;
            }

            RequestedUpdateInThisFrame = true;

            if (gameObject.activeInHierarchy)
            {
                StartCoroutine(ReactToChangesCoroutine());
            }
            else
            {
                OnReactToChanges();
                RequestedUpdateInThisFrame = false;
            }
        }

        private IEnumerator ReactToChangesCoroutine()
        {
            yield return null;
            OnReactToChanges();
            RequestedUpdateInThisFrame = false;
        }

        protected abstract void OnReactToChanges();
    }
}