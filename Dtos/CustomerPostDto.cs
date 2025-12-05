namespace api.Dtos;

public class CustomerPostDto
{
    public string Name { get; set; }="";
    public int StoreNumber { get; set; }
    public string AddressLine { get; set; }="";
    public string PostalCode { get; set; }="";
    public string City { get; set; }="";
}
