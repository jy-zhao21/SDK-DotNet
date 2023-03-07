namespace NovelCraft.Sdk.Client;

internal class Client : IClient {
  public event EventHandler<NovelCraft.Sdk.Messages.IMessage>? MessageReceived;


  public Client(string host, string port) {
    throw new NotImplementedException();
  }


  public void Send(NovelCraft.Sdk.Messages.IMessage message) {
    throw new NotImplementedException();
  }
}