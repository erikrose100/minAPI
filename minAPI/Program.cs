using System.Text;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

static string ReverseString(string input)
{
    return new string( input.ToCharArray().Reverse().ToArray() );
}

static string EncodeBase64String(string input)
{
    return Convert.ToBase64String(Encoding.UTF8.GetBytes(input));
}

static string ValidateLength(string input)
{
    return (input.Length < 129) ? input : throw new Exception("String too long.");
}

app.MapGet("/", () => "Hello World!");

app.MapGet("/reverse/{text}", (string text) => ReverseString(ValidateLength(text)) );

app.MapGet("/base64/{text}", (string text) => EncodeBase64String(ValidateLength(text)));

app.MapGet("/base64/reverse/{text}", (string text) => EncodeBase64String(ReverseString(ValidateLength(text))));

app.Run();
