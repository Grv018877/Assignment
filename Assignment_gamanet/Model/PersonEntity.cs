using Assignment_gamanet.Common;

public class PersonEntity : PropertyChangedBase
{
    // Private backing fields
    private string _name = string.Empty;
    private string _country = string.Empty;
    private string _address = string.Empty;
    private string _postalZip = string.Empty;
    private string _email = string.Empty;
    private string _phone = string.Empty;

    /// <summary>
    /// Gets or sets the full name of the person.
    /// </summary>
    public string Name
    {
        get => _name;
        set => SetField(ref _name, value);
    }

    /// <summary>
    /// Gets or sets the country where the person resides.
    /// </summary>
    public string Country
    {
        get => _country;
        set => SetField(ref _country, value);
    }

    /// <summary>
    /// Gets or sets the street address of the person.
    /// </summary>
    public string Address
    {
        get => _address;
        set => SetField(ref _address, value);
    }

    /// <summary>
    /// Gets or sets the postal or ZIP code of the person's address.
    /// </summary>
    public string PostalZip
    {
        get => _postalZip;
        set => SetField(ref _postalZip, value);
    }

    /// <summary>
    /// Gets or sets the email address of the person.
    /// </summary>
    public string Email
    {
        get => _email;
        set => SetField(ref _email, value);
    }

    /// <summary>
    /// Gets or sets the phone number of the person.
    /// </summary>
    public string Phone
    {
        get => _phone;
        set => SetField(ref _phone, value);
    }
}
