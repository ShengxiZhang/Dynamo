﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Autodesk.DesignScript.Interfaces;
using System.IO;
using Dynamo.Models;

namespace DynamoWebServer.Messages
{
    /// <summary>
    /// The class that represents calculated result for a node
    /// </summary>
    [DataContract]
    public class ExecutedNode
    {
        /// <summary>
        /// Guid of the specified node
        /// </summary>
        [DataMember]
        public string NodeID { get; private set; }

        /// <summary>
        /// State of the node after executing
        /// </summary>
        [DataMember]
        public string State { get; private set; }

        /// <summary>
        /// State description. It is empty when state has Active or Dead value
        /// </summary>
        [DataMember]
        public string StateMessage { get; private set; }

        /// <summary>
        /// String representing of the result object
        /// </summary>
        [DataMember]
        public string Data { get; private set; }

        /// <summary>
        /// Indicates whether the result object should be drawn on the canvas
        /// </summary>
        [DataMember]
        public bool ContainsGeometryData { get; private set; }

        public ExecutedNode(NodeModel node, string data)
        {
            this.NodeID = node.GUID.ToString();
            this.State = node.State.ToString();
            this.StateMessage = node.ToolTipText;
            this.Data = data;
            this.ContainsGeometryData = node.HasRenderPackages;
        }
    }
}