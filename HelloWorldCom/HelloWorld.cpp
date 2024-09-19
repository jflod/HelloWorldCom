// HelloWorld.cpp : Implementation of CHelloWorld

#include "pch.h"
#include "HelloWorld.h"


// CHelloWorld
STDMETHODIMP CHelloWorld::Start(BSTR name, BSTR* result)
{
    if (!result)
        return E_POINTER;

    // Create a greeting message, for example "Hello, <name>"
    CComBSTR greeting(L"Hello, ");
    greeting.AppendBSTR(name);

    // Return the greeting message
    *result = greeting.Detach();

    return S_OK;
}

