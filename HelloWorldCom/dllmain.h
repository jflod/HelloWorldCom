// dllmain.h : Declaration of module class.

class CHelloWorldComModule : public ATL::CAtlDllModuleT< CHelloWorldComModule >
{
public :
	DECLARE_LIBID(LIBID_HelloWorldComLib)
	DECLARE_REGISTRY_APPID_RESOURCEID(IDR_HELLOWORLDCOM, "{b4dc28cc-1430-457c-8e67-616712e1db0a}")
};

extern class CHelloWorldComModule _AtlModule;
