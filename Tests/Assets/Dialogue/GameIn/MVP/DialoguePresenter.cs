using System.Linq;

public class DialoguePresenter
{
    private readonly IDialogueView _view;
    private readonly DialogueModel _model;

    public DialoguePresenter(IDialogueView _view)
    {
        this._view = _view;
        _model = new DialogueModel();

        _model.OnChangeNode += (s) =>
        {
            UpdateText(s);
            UpdateOptions(s);
        };

        _view.OnOptionClick = (_option) =>
        {
            _model.OnChangeNode.Invoke(_model.CurrentDialogue.Nodes
                .FirstOrDefault(s => s.Index == _option.Connect.ConnectIndexes[0]));
        };

        _view.OnClick = () => _model.SkipNode();
        _view.Open = (_asset, _eventController) => _model.SetDialogue(_asset, _eventController);
    }

    private void UpdateText(SettingNode _node)
    {
        _view.NameText = _node.Name;
        _view.PhraseText = _node.Phrase;
    }
 
    private void UpdateOptions(SettingNode _node)
    {
        SettingNode[] _connectNodes = _model.CurrentDialogue.Nodes
                                          .Where(s =>
                                          {
                                              return _node.Connect.ConnectIndexes != null &&
                                                     _node.Connect.ConnectIndexes.Contains(s.Index);
                                          })
                                          .ToArray();
        
        _view.UpdateOptionsState(_connectNodes);
    }
}
