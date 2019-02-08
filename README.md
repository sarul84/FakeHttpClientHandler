# FakeHttpClientHandler
This is one of the way to fake http response

If there is a need to mock external API response and improve code coverage with unit test, the below example shows how to achieve that,

```
public class User
{
    [JsonProperty("loginId")]
    public string LoginId { get; set; }
    [JsonProperty("password")]
    public string Password { get; set; }
    [JsonProperty("isSuccess")]
    public bool IsSuccess { get; set; }
    [JsonProperty("errorMessage")]
    public string ErrorMessage { get; set; }
}

//Arrange
var fakeHttpMessageHandler = new FakeHttpClientHandler(new HttpResponseMessage()
{
    StatusCode = HttpStatusCode.OK,
    Content = new StringContent(JsonConvert.SerializeObject(this.IsValidUser(name, pwd)), Encoding.UTF8, "application/json")
});
var fakeHttpClient = new HttpClient(fakeHttpMessageHandler)
{
    BaseAddress = new Uri("https://test.io/")
};

httpClientFactoryMock.Setup(x => x.CreateClient(It.IsAny<string>())).Returns(fakeHttpClient);
```

method that returns mock data based on the input
```
private User IsValidUser(string name, string pwd)
{
    User user = null;
    switch(pwd)
    {
        case "wrong":
           user = new User
           {
              LoginId = name,
              Password = pwd,
              IsSuccess = false,
              ErrorMessage = "Please enter valid credentials"
           }
           break;
         case "correct":
           user = new User
           {
              LoginId = name,
              Password = pwd,
              IsSuccess = true,
              ErrorMessage = string.Empty
           }
           break;
    }
    return user;
}
```
With above logic, no need to mock service / business method or even if the api consumption logic is in private method, the test method works fine and returns expected output.

