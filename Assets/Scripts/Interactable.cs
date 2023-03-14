using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{

    public class Interactable: MonoBehaviour
    {
        private Rigidbody rigidBody;
        private Renderer selectionRenderer;
        [SerializeField] private float selectionTime;
        [SerializeField] private Material defaultMat;
        [SerializeField] private Material selectedMat;
        [SerializeField] private Material lookAtMat;

        private float currentTime;
        private bool isSelected;
        private bool isLookedAt;
        public bool IsSelected => this.isSelected;


        private void Start()
        {
            this.selectionRenderer = GetComponent<Renderer>();
            this.rigidBody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
                
        }
        
        public void OnLook(Transform lookPos, float interactionDistance)
        {
            this.currentTime += Time.deltaTime;
            if (this.currentTime > this.selectionTime && !this.isSelected)
            {
                this.isSelected = true;
                this.selectionRenderer.material = this.selectedMat;
                Invoke(nameof(ResetObject),5f);
            }

            if (this.isSelected)
            {
                if(this.rigidBody!=null)
                    this.rigidBody.isKinematic = true;
                this.transform.position = Vector3.Lerp(this.transform.position,lookPos.transform.position +
                                          lookPos.forward * interactionDistance, Time.deltaTime*50f);
            }
        }

        public void OnLookEnter()
        {
            this.selectionRenderer.material = this.lookAtMat;
        }
        
        public void OnLookExit()
        {
            this.ResetObject();
        }

        private void ResetObject()
        {
            this.isSelected = false;
            this.rigidBody.isKinematic = false;
            this.currentTime = 0;
            this.selectionRenderer.material = this.defaultMat;
        }
    }
}