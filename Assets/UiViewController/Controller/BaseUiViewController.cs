namespace UiViewController
{
    public class BaseUiViewController
    {
        private IBaseView _baseViewInterface;
        private BaseUiView<BaseUiViewRefs> _baseUiView;
        private BaseUiViewDataModel _viewModel;

        public BaseUiViewController(BaseUiView<BaseUiViewRefs> view, BaseUiViewDataModel model)
        {
            this._viewModel = model;
            this._baseViewInterface = view;
        }
        
        public void SetScore(int score)
        {
            _viewModel.Score = score;
        }
    }
}