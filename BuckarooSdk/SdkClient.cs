using System;
using BuckarooSdk.Logging;
using BuckarooSdk.Base;

namespace BuckarooSdk
{
	/// <summary>
	/// 
	///    @Copyright 2017, Buckaroo B.V.
	/// 
	///	   This file is part of the Buckaroo SDK
	/// 
	///    The Buckaroo SDK is free software: you can redistribute it and/or modify
	///    it under the terms of the GNU General Public License as published by
	///    the Free Software Foundation, either version 3 of the License, or
	///    (at your option) any later version.
	///
	///    This program is distributed in the hope that it will be useful,
	///    but WITHOUT ANY WARRANTY; without even the implied warranty of
	///    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
	///    GNU General Public License for more details.
	///
	///    You should have received a copy of the GNU General Public License
	///    along with this program.  If not, see http://www.gnu.org/licenses/
	/// 
	/// </summary>
	public class SdkClient
	{
		private PushHandler PushHandler { get; set; }

		private Func<ILogger> LoggerFactory { get; set; }

		/// <summary>
		/// Default constructor. The standard logger will be used by this instance, if none is provided when creating a request.
		/// </summary>
		public SdkClient()
		{
			this.LoggerFactory = () => new StandardLogger();
		}

		/// <summary>
		/// Constructor where a custom logger factory can be set, for creating custom implemented loggers.
		/// </summary>
		/// <param name="loggerFactory">A locally stored function, e.g. () => new CustomImplementationLogger() </param>
		public SdkClient(Func<ILogger> loggerFactory)
		{
			if (loggerFactory == null)
			{
				throw new ArgumentNullException(nameof(loggerFactory));
			}
			this.LoggerFactory = loggerFactory ;
		}

		/// <summary>
		/// Create request function that returns a new request.
		/// </summary>
		/// <returns></returns>
		public Request CreateRequest()
		{
			return new Request(this.LoggerFactory());
		}

		/// <summary>
		/// Create request function that returns a new request. A ILogger implementations can be provided. If omitted, the Logger
		/// instance will be provided by the LoggerFactory.
		/// </summary>
		/// <param name="logger"></param>
		/// <returns></returns>
		public Request CreateRequest(ILogger logger)
		{
			return new Request(logger);
		}

		/// <summary>
		/// Create request function that returns a new request. A StandardLogger implementations can be provided. If omitted, the Logger
		/// instance will be provided by the LoggerFactory.
		/// </summary>
		/// <param name="logger"></param>
		/// <returns></returns>
		public Request CreateRequest(StandardLogger logger)
		{
			return new Request(logger);
		}

		/// <summary>
		/// Create request function that returns a new request. A ExtensiveLogger implementations can be provided. If omitted, the Logger
		/// instance will be provided by the LoggerFactory.
		/// </summary>
		/// <param name="logger"></param>
		/// <returns></returns>
		public Request CreateRequest(ExtensiveLogger logger)
		{
			return new Request(logger);
		}

		/// <summary>
		/// Returns a Buckaroo push handler, that can be used to process push messages.
		/// </summary>
		/// <returns></returns>
		public PushHandler GetPushHandler()
		{
			return this.PushHandler ?? (this.PushHandler = new PushHandler());
		}
	}
}
