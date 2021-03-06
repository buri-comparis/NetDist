﻿using System;
using System.Collections.Generic;

namespace NetDist.Server.XDomainObjects
{
    [Serializable]
    public class JobScriptFile
    {
        public string Hash { get; private set; }
        public bool ParsingFailed { get; private set; }
        public string ErrorMessage { get; private set; }
        public List<string> CompilerLibraries { get; set; }
        public List<string> Dependencies { get; set; }
        public string PackageName { get; set; }
        public string JobScript { get; set; }

        public JobScriptFile(string hash)
        {
            CompilerLibraries = new List<string>();
            Dependencies = new List<string>();
            Hash = hash;
        }

        public void SetError(string errorMessage)
        {
            ParsingFailed = true;
            ErrorMessage = errorMessage;
        }
    }
}
