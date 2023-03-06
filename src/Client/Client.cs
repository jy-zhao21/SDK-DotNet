namespace NovelCraft.Sdk.Client;

public class Client : IClient {
  public event EventHandler<NovelCraft.Sdk.Messages.IMessage>? MessageReceivedEvent;

  public void Connect() {
    throw new NotImplementedException();
  }

  public void Disconnect() {
    throw new NotImplementedException();
  }

  public void Send(NovelCraft.Sdk.Messages.IMessage message) {
    throw new NotImplementedException();
  }
}