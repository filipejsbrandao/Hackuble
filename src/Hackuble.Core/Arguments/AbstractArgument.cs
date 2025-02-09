﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Hackuble.Arguments
{

    public abstract class AbstractArgument<T> : IAbstractArgument
    {
        public AbstractArgument(string prompt, string description, T defaultValue)
        {
            this.Prompt = prompt;
            this.Description = description;
            this.DefaultValue = defaultValue;
            this.CurrentValue = defaultValue;
        }
        public T CurrentValue { get; set; }

        public T DefaultValue { get; set; }
        public string Prompt { get; set; }
        public string Description { get; set; }

        public object DefaultValueUntyped => this.DefaultValue;

        public bool GetData<T1>(ref T1 data)
        {
            if (typeof(T1) == typeof(T))
            {
                var temoObj = (object)this.CurrentValue;
                data = (T1)temoObj;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool TryPushValue(object data)
        {
            try
            {
                var temp = (T)data;
                if (temp != null) this.CurrentValue = temp;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public abstract void RenderArgumentInput();
    }


}
