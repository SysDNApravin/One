namespace One.CustomControls;

public partial class OutlinedEntryControl : Grid
{
	public OutlinedEntryControl()
	{
		InitializeComponent();
	}

	public static readonly BindableProperty TextProperty = BindableProperty.Create(
		propertyName: nameof(Text),
		returnType: typeof(string),
		declaringType: typeof(OutlinedEntryControl),
		defaultValue:null,
		defaultBindingMode: BindingMode.TwoWay);
		

		public string Text
	{
		get =>(string)GetValue( TextProperty );
		set { SetValue(TextProperty, value); }
	}


    public static readonly BindableProperty PlacholderProperty = BindableProperty.Create(
        propertyName: nameof(Placeholder),
        returnType: typeof(string),
        declaringType: typeof(OutlinedEntryControl),
        defaultValue: null,
        defaultBindingMode: BindingMode.OneWay);


    public string Placeholder
    {
        get => (string)GetValue(PlacholderProperty);
        set { SetValue(PlacholderProperty, value); }
    }


	private async void  txtEntry_Focused(object sender, FocusEventArgs e)
	{


            lblPlaceholder.TextColor = Colors.Blue;
            lblPlaceholder.FontSize = 16;
            await lblPlaceholder.TranslateTo(0, -27, 80, easing: Easing.Linear);
            lblBorderColor.BorderColor = Colors.Blue;

          


    }
    private async void txtEntry_Unfocused(object sender, FocusEventArgs e)
    {

		if(!string.IsNullOrWhiteSpace(Text)) 
		{
            lblPlaceholder.TextColor = Colors.Blue;
            lblPlaceholder.FontSize = 16;
           await lblPlaceholder.TranslateTo(0, -27, 80, easing: Easing.Linear);
            lblBorderColor.BorderColor = Colors.Blue;
        }
		else
		{
            lblPlaceholder.TextColor = Colors.Gray;
            lblPlaceholder.FontSize = 15;
           await lblPlaceholder.TranslateTo(0, 0, 80, easing: Easing.Linear);
            lblBorderColor.BorderColor = Colors.Gray;
        }
       
    }
}