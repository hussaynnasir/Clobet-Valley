using JetBrains.Annotations;

namespace UiViewController
{
    public interface IBaseView
    {
         protected abstract void UpdateView();
         protected abstract void SetModel(IUiViewDataModel model);
    }
}