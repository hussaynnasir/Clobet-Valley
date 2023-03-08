using UnityEngine;

namespace UiViewController
{
    public abstract class BaseUiView<BaseUiViewRefs> :  MonoBehaviour, IBaseView
    {
        #region private variables
        private IUiViewDataModel _uiViewData;
        #endregion

        #region protected variables
        protected BaseUiViewRefs _ViewRefs;
        #endregion

        #region private methods
        private void Awake()
        {
            _ViewRefs = GetComponent<BaseUiViewRefs>();
        }
        
        void IBaseView.SetModel(IUiViewDataModel model)
        {
            this._uiViewData = model;
        }
        
        void IBaseView.UpdateView()
        {
            // Handle view updates here
        }
        #endregion

        #region protected methods
        protected virtual void Show(BaseUiViewDataModel model)
        {
            
        }
        #endregion
    }
}