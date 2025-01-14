﻿using System.Reflection;

namespace Microsoft.JSInterop;

public static class IJSRuntimeExtensions
{
    public static ValueTask ApplyBodyElementClasses(this IJSRuntime jsRuntime, List<string> cssClasses, Dictionary<string, string> cssVariables)
    {
        return jsRuntime.InvokeVoidAsync("App.applyBodyElementClasses", cssClasses, cssVariables);
    }


    public static bool IsInitialized(this IJSRuntime jsRuntime)
    {
        var type = jsRuntime.GetType();

        if (type.Name is not "RemoteJSRuntime") return true; // Blazor WASM/Hybrid

        return (bool)type.GetProperty("IsInitialized")!.GetValue(jsRuntime)!;
    }
}
