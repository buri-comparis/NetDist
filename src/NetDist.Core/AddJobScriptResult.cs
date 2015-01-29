﻿using System;

namespace NetDist.Core
{
    public class AddJobScriptResult
    {
        public bool HasError { get; set; }
        public AddJobScriptErrorReason ErrorReason { get; set; }
        public string ErrorMessage { get; set; }
        public Guid HandlerId { get; set; }
        public string PackageName { get; set; }
        public string HandlerName { get; set; }
        public string JobName { get; set; }
        public AddJobScriptUpdateType UpdateType { get; set; }

        public void SetUpdated(AddJobScriptUpdateType updateType, Guid handlerId)
        {
            HandlerId = handlerId;
            UpdateType = updateType;
        }

        public void SetError(AddJobScriptErrorReason errorReason, string errorMessage)
        {
            HasError = true;
            ErrorMessage = errorMessage;
            ErrorReason = errorReason;
        }
    }
}
