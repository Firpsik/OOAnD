using Scriban;

namespace SpaceBattle;

public class Adapter : IBuilder
{
    private readonly Type _objType;
    private readonly Type _adapterInterfaceType;

    public Adapter(Type objType, Type typeNew)
    {
        _objType = objType;
        _adapterInterfaceType = typeNew;
    }
    public string Build()
    {
        var targetProperties = _adapterInterfaceType.GetProperties().ToList();

        var templateString = @"public class {{adapter_interface_name}}Adapter : {{adapter_interface_name}} {
        {{obj_type_name}} _obj;
    
        public {{adapter_interface_name}}Adapter({{obj_type_name}} obj) => _obj = obj;
    {{for property in (target_properties)}}
    public {{property.property_type.name}} {{property.name}}
    {
    {{if property.can_read}}
        get
        {
            return IoC.Resolve<{{property.property_type.name}}>(""Get.Property"", ""{{property.name}}"", _obj);
        }{{end}}
    {{if property.can_write}}
        set
        {
            return IoC.Resolve<ICommand>(""Set.Property"", ""{{property.name}}"", _obj, value).Execute();
        }{{end}}
    }
    {{end}}
    }";
        var template = Template.Parse(templateString);
        var result = template.Render(new
        {
            obj_type_name = _objType.Name,
            adapter_interface_name = _adapterInterfaceType.Name,
            target_properties = targetProperties,
        });
        return result;
    }
}
