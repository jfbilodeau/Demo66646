using Microsoft.Identity.Client;

Console.WriteLine("Starting MSAL Demo...");

// YUK!!!!
var tenantId = "14f08b43-3b8c-4f1c-87c5-71e2bb2177f3";
var clientId = "89775e56-afb6-4c3e-88b9-476a957566dc";

var app = PublicClientApplicationBuilder.Create(clientId)
    .WithAuthority(AzureCloudInstance.AzurePublic, tenantId)
    .WithRedirectUri("http://localhost")
    .Build();

var scopes = new[] { "user.read" };

var result = await app.AcquireTokenInteractive(scopes).ExecuteAsync();

var idToken = result.IdToken;

Console.WriteLine($"Id Token: {idToken}");

Console.WriteLine("Done!");