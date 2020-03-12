public class PropertyChangedBase : INotifyPropertyChanged
{
	public event PropertyChangedEventHandler PropertyChanged;

	protected virtual void OnPropertyChanged(string name)
	{
		if (PropertyChanged != null)
			PropertyChanged(this, new PropertyChangedEventArgs(name));
	}
}
