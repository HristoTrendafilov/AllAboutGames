﻿namespace AllAboutGames.Core
{
    public class CheckResult
    {
        private readonly List<string> errors;

        public CheckResult()
        {
            this.errors = new List<string>();
        }

        public bool IsFailed => this.errors.Count > 0;

        public bool Success => this.errors.Count == 0;

        public void AddError(string errorMessage)
        {
            this.errors.Add(errorMessage);
        }

        public string GetErrors(string separator = "\n")
        {
            return string.Join(separator, this.errors);
        }
    }
}
