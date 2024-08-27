using System.Text.Json.Serialization;

public class Employee {
    public string Id { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    public decimal Salary { get; set; }

    [JsonPropertyName("dept")]
    public string Department { get; set; } = string.Empty;
}