namespace HerreraSierraVargasAppApuntes2.Views;

public partial class CardView : ContentView
{
    public CardView()
    {
        InitializeComponent();
        BindingContext = this;
    }

    public static readonly BindableProperty CardTitleProperty =
        BindableProperty.Create(nameof(CardTitle), typeof(string), typeof(CardView), string.Empty);

    public static readonly BindableProperty CardDeporteProperty =
        BindableProperty.Create(nameof(CardDeporte), typeof(string), typeof(CardView), string.Empty);

    public static readonly BindableProperty IconImageSourceProperty =
        BindableProperty.Create(nameof(IconImageSource), typeof(ImageSource), typeof(CardView), default(ImageSource));

    public static readonly BindableProperty BorderColorProperty =
        BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(CardView), Colors.Gray);

    public static readonly BindableProperty AgeProperty =
    BindableProperty.Create(nameof(Age), typeof(string), typeof(CardView), string.Empty);

    public string Age
    {
        get => (string)GetValue(AgeProperty);
        set => SetValue(AgeProperty, value);
    }

    public string CardTitle
    {
        get => (string)GetValue(CardTitleProperty);
        set => SetValue(CardTitleProperty, value);
    }

    public string CardDeporte
    {
        get => (string)GetValue(CardDeporteProperty);
        set => SetValue(CardDeporteProperty, value);
    }

    public ImageSource IconImageSource
    {
        get => (ImageSource)GetValue(IconImageSourceProperty);
        set => SetValue(IconImageSourceProperty, value);
    }

    public Color BorderColor
    {
        get => (Color)GetValue(BorderColorProperty);
        set => SetValue(BorderColorProperty, value);
    }
}