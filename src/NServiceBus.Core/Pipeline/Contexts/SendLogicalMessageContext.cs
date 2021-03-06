﻿namespace NServiceBus.Pipeline.Contexts
{
    using System.Collections;
    using System.Collections.Generic;
    using Unicast;
    using Unicast.Messages;

    internal class SendLogicalMessageContext : BehaviorContext
    {
        public SendLogicalMessageContext(BehaviorContext parentContext, SendOptions sendOptions, LogicalMessage message)
            : base(parentContext)
        {
            Set(sendOptions);
            Set(message);
        }

        public SendOptions SendOptions
        {
            get { return Get<SendOptions>(); }
        }

        public LogicalMessage MessageToSend
        {
            get
            {
                return Get<LogicalMessage>();
            }
        }

        public TransportMessage IncomingMessage
        {
            get
            {
                TransportMessage message;

                parentContext.TryGet(out message);

                return message;
            }
        }
    }
}