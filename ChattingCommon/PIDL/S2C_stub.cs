




// Generated by PIDL compiler.
// Do not modify this file, but modify the source .pidl file.

using System;
using System.Net;	     

namespace S2C
{
	internal class Stub:Nettention.Proud.RmiStub
	{
public AfterRmiInvocationDelegate AfterRmiInvocation = delegate(Nettention.Proud.AfterRmiSummary summary) {};
public BeforeRmiInvocationDelegate BeforeRmiInvocation = delegate(Nettention.Proud.BeforeRmiSummary summary) {};

		public delegate bool NotifyChatDelegate(Nettention.Proud.HostID remote,Nettention.Proud.RmiContext rmiContext, string userName, string str);  
		public NotifyChatDelegate NotifyChat = delegate(Nettention.Proud.HostID remote,Nettention.Proud.RmiContext rmiContext, string userName, string str)
		{ 
			return false;
		};
		public delegate bool SystemChatDelegate(Nettention.Proud.HostID remote,Nettention.Proud.RmiContext rmiContext, string str);  
		public SystemChatDelegate SystemChat = delegate(Nettention.Proud.HostID remote,Nettention.Proud.RmiContext rmiContext, string str)
		{ 
			return false;
		};
		public delegate bool ResponseLoginDelegate(Nettention.Proud.HostID remote,Nettention.Proud.RmiContext rmiContext, ChattingCommon.User user);  
		public ResponseLoginDelegate ResponseLogin = delegate(Nettention.Proud.HostID remote,Nettention.Proud.RmiContext rmiContext, ChattingCommon.User user)
		{ 
			return false;
		};
		public delegate bool ResponseLogoutDelegate(Nettention.Proud.HostID remote,Nettention.Proud.RmiContext rmiContext, ChattingCommon.User user);  
		public ResponseLogoutDelegate ResponseLogout = delegate(Nettention.Proud.HostID remote,Nettention.Proud.RmiContext rmiContext, ChattingCommon.User user)
		{ 
			return false;
		};
	public override bool ProcessReceivedMessage(Nettention.Proud.ReceivedMessage pa, Object hostTag) 
	{
		Nettention.Proud.HostID remote=pa.RemoteHostID;
		if(remote==Nettention.Proud.HostID.HostID_None)
		{
			ShowUnknownHostIDWarning(remote);
		}

		Nettention.Proud.Message __msg=pa.ReadOnlyMessage;
		int orgReadOffset = __msg.ReadOffset;
        Nettention.Proud.RmiID __rmiID = Nettention.Proud.RmiID.RmiID_None;
        if (!__msg.Read( out __rmiID))
            goto __fail;
					
		switch(__rmiID)
		{
case Common.NotifyChat:
	{
		Nettention.Proud.RmiContext ctx=new Nettention.Proud.RmiContext();
		ctx.sentFrom=pa.RemoteHostID;
		ctx.relayed=pa.IsRelayed;
		ctx.hostTag=hostTag;
		ctx.encryptMode = pa.EncryptMode;
		ctx.compressMode = pa.CompressMode;
			
		string userName; ChattingCommon.Marshaler.Read(__msg,out userName);	
string str; ChattingCommon.Marshaler.Read(__msg,out str);	
core.PostCheckReadMessage(__msg, RmiName_NotifyChat);
		if(enableNotifyCallFromStub==true)
		{
			string parameterString="";
			parameterString+=userName.ToString()+",";
parameterString+=str.ToString()+",";
			NotifyCallFromStub(Common.NotifyChat, RmiName_NotifyChat,parameterString);
		}
			
		if(enableStubProfiling)
		{
			Nettention.Proud.BeforeRmiSummary summary = new Nettention.Proud.BeforeRmiSummary();
			summary.rmiID = Common.NotifyChat;
			summary.rmiName = RmiName_NotifyChat;
			summary.hostID = remote;
			summary.hostTag = hostTag;
			BeforeRmiInvocation(summary);
		}
			
		long t0 = Nettention.Proud.PreciseCurrentTime.GetTimeMs();
			
		// Call this method.
		bool __ret=NotifyChat (remote,ctx , userName, str );
			
		if(__ret==false)
		{
			// Error: RMI function that a user did not create has been called. 
			core.ShowNotImplementedRmiWarning(RmiName_NotifyChat);
		}
			
		if(enableStubProfiling)
		{
			Nettention.Proud.AfterRmiSummary summary = new Nettention.Proud.AfterRmiSummary();
			summary.rmiID = Common.NotifyChat;
			summary.rmiName = RmiName_NotifyChat;
			summary.hostID = remote;
			summary.hostTag = hostTag;
			summary.elapsedTime = Nettention.Proud.PreciseCurrentTime.GetTimeMs()-t0;
			AfterRmiInvocation(summary);
		}
	}
	break;
case Common.SystemChat:
	{
		Nettention.Proud.RmiContext ctx=new Nettention.Proud.RmiContext();
		ctx.sentFrom=pa.RemoteHostID;
		ctx.relayed=pa.IsRelayed;
		ctx.hostTag=hostTag;
		ctx.encryptMode = pa.EncryptMode;
		ctx.compressMode = pa.CompressMode;
			
		string str; ChattingCommon.Marshaler.Read(__msg,out str);	
core.PostCheckReadMessage(__msg, RmiName_SystemChat);
		if(enableNotifyCallFromStub==true)
		{
			string parameterString="";
			parameterString+=str.ToString()+",";
			NotifyCallFromStub(Common.SystemChat, RmiName_SystemChat,parameterString);
		}
			
		if(enableStubProfiling)
		{
			Nettention.Proud.BeforeRmiSummary summary = new Nettention.Proud.BeforeRmiSummary();
			summary.rmiID = Common.SystemChat;
			summary.rmiName = RmiName_SystemChat;
			summary.hostID = remote;
			summary.hostTag = hostTag;
			BeforeRmiInvocation(summary);
		}
			
		long t0 = Nettention.Proud.PreciseCurrentTime.GetTimeMs();
			
		// Call this method.
		bool __ret=SystemChat (remote,ctx , str );
			
		if(__ret==false)
		{
			// Error: RMI function that a user did not create has been called. 
			core.ShowNotImplementedRmiWarning(RmiName_SystemChat);
		}
			
		if(enableStubProfiling)
		{
			Nettention.Proud.AfterRmiSummary summary = new Nettention.Proud.AfterRmiSummary();
			summary.rmiID = Common.SystemChat;
			summary.rmiName = RmiName_SystemChat;
			summary.hostID = remote;
			summary.hostTag = hostTag;
			summary.elapsedTime = Nettention.Proud.PreciseCurrentTime.GetTimeMs()-t0;
			AfterRmiInvocation(summary);
		}
	}
	break;
case Common.ResponseLogin:
	{
		Nettention.Proud.RmiContext ctx=new Nettention.Proud.RmiContext();
		ctx.sentFrom=pa.RemoteHostID;
		ctx.relayed=pa.IsRelayed;
		ctx.hostTag=hostTag;
		ctx.encryptMode = pa.EncryptMode;
		ctx.compressMode = pa.CompressMode;
			
		ChattingCommon.User user; ChattingCommon.Marshaler.Read(__msg,out user);	
core.PostCheckReadMessage(__msg, RmiName_ResponseLogin);
		if(enableNotifyCallFromStub==true)
		{
			string parameterString="";
			parameterString+=user.ToString()+",";
			NotifyCallFromStub(Common.ResponseLogin, RmiName_ResponseLogin,parameterString);
		}
			
		if(enableStubProfiling)
		{
			Nettention.Proud.BeforeRmiSummary summary = new Nettention.Proud.BeforeRmiSummary();
			summary.rmiID = Common.ResponseLogin;
			summary.rmiName = RmiName_ResponseLogin;
			summary.hostID = remote;
			summary.hostTag = hostTag;
			BeforeRmiInvocation(summary);
		}
			
		long t0 = Nettention.Proud.PreciseCurrentTime.GetTimeMs();
			
		// Call this method.
		bool __ret=ResponseLogin (remote,ctx , user );
			
		if(__ret==false)
		{
			// Error: RMI function that a user did not create has been called. 
			core.ShowNotImplementedRmiWarning(RmiName_ResponseLogin);
		}
			
		if(enableStubProfiling)
		{
			Nettention.Proud.AfterRmiSummary summary = new Nettention.Proud.AfterRmiSummary();
			summary.rmiID = Common.ResponseLogin;
			summary.rmiName = RmiName_ResponseLogin;
			summary.hostID = remote;
			summary.hostTag = hostTag;
			summary.elapsedTime = Nettention.Proud.PreciseCurrentTime.GetTimeMs()-t0;
			AfterRmiInvocation(summary);
		}
	}
	break;
case Common.ResponseLogout:
	{
		Nettention.Proud.RmiContext ctx=new Nettention.Proud.RmiContext();
		ctx.sentFrom=pa.RemoteHostID;
		ctx.relayed=pa.IsRelayed;
		ctx.hostTag=hostTag;
		ctx.encryptMode = pa.EncryptMode;
		ctx.compressMode = pa.CompressMode;
			
		ChattingCommon.User user; ChattingCommon.Marshaler.Read(__msg,out user);	
core.PostCheckReadMessage(__msg, RmiName_ResponseLogout);
		if(enableNotifyCallFromStub==true)
		{
			string parameterString="";
			parameterString+=user.ToString()+",";
			NotifyCallFromStub(Common.ResponseLogout, RmiName_ResponseLogout,parameterString);
		}
			
		if(enableStubProfiling)
		{
			Nettention.Proud.BeforeRmiSummary summary = new Nettention.Proud.BeforeRmiSummary();
			summary.rmiID = Common.ResponseLogout;
			summary.rmiName = RmiName_ResponseLogout;
			summary.hostID = remote;
			summary.hostTag = hostTag;
			BeforeRmiInvocation(summary);
		}
			
		long t0 = Nettention.Proud.PreciseCurrentTime.GetTimeMs();
			
		// Call this method.
		bool __ret=ResponseLogout (remote,ctx , user );
			
		if(__ret==false)
		{
			// Error: RMI function that a user did not create has been called. 
			core.ShowNotImplementedRmiWarning(RmiName_ResponseLogout);
		}
			
		if(enableStubProfiling)
		{
			Nettention.Proud.AfterRmiSummary summary = new Nettention.Proud.AfterRmiSummary();
			summary.rmiID = Common.ResponseLogout;
			summary.rmiName = RmiName_ResponseLogout;
			summary.hostID = remote;
			summary.hostTag = hostTag;
			summary.elapsedTime = Nettention.Proud.PreciseCurrentTime.GetTimeMs()-t0;
			AfterRmiInvocation(summary);
		}
	}
	break;
		default:
			 goto __fail;
		}
		return true;
__fail:
	  {
			__msg.ReadOffset = orgReadOffset;
			return false;
	  }
	}
// RMI name declaration.
// It is the unique pointer that indicates RMI name such as RMI profiler.
const string RmiName_NotifyChat="NotifyChat";
const string RmiName_SystemChat="SystemChat";
const string RmiName_ResponseLogin="ResponseLogin";
const string RmiName_ResponseLogout="ResponseLogout";
       
const string RmiName_First = RmiName_NotifyChat;
		public override Nettention.Proud.RmiID[] GetRmiIDList { get{return Common.RmiIDList;} }
		
	}
}

