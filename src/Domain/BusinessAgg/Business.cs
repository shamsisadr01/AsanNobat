using System;
using System.Collections.Generic;
using System.Text;

namespace AsanNobat.Domain.BusinessAgg;

public class Business : Aggregate
{
    public string Name { get; private set; } = null!;
    public string UrlSlug { get; private set; } = null!;
    public string? Description { get; private set; }
    public string PhoneNumber { get; private set; } = null!;
    public string Address { get; private set; } = null!;

    private Business()
    {
        
    }

    private Business(string name, string urlSlug, string? description, string phoneNumber, string address)
    {
        Name = name;
        UrlSlug = urlSlug;
        Description = description;
        PhoneNumber = phoneNumber;
        Address = address;
    }

    public static Business Create(string name, string urlSlug, string? description, string phoneNumber, string address)
    {
        return new Business(name, urlSlug, description, phoneNumber, address);
    }
}
