
using System;
using System.Threading.Tasks;

public sealed class ClickToSend : Component
{

	protected override void OnFixedUpdate()
	{
		if (IsProxy) return;

		if (Input.Pressed("attack1"))
		{
			StaticWithRPCs<int>.DoSendMessage();
		}
	}

}


public class StaticWithRPCs<T> where T : unmanaged
{

	public static void DoSendMessage()
	{
		using (Rpc.FilterExclude(Connection.Host))
		{
			SendMessage(Guid.NewGuid());
		}
	}

	[Broadcast]
	public static void SendMessage(Guid someGuid)
	{
		Log.Info($"Got message: {someGuid}");
	}
}
