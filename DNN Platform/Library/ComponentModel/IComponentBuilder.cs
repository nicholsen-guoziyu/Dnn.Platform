﻿// 
// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
// 
namespace DotNetNuke.ComponentModel
{
    public interface IComponentBuilder
    {
        string Name { get; }

        object BuildComponent();
    }
}
